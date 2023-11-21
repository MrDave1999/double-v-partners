namespace Double.Partners.Features.Users;

public class CreateUserRequest
{
    public string UserName { get; init; }
    public string Password { get; init; }
}

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(request => request.UserName).NotEmpty();
        RuleFor(request => request.Password).NotEmpty();
    }
}

public class CreateUserUseCase
{
    private readonly DbContext _context;
    public CreateUserUseCase(DbContext context) => _context = context;

    public async Task<Result> ExecuteAsync(CreateUserRequest request)
    {
        ValidationResult result = new CreateUserValidator().Validate(request);
        if(result.IsFailed())
            return result.Invalid();

        bool userExists = await _context.Set<User>()
            .Where(u => u.Name == request.UserName)
            .AnyAsync();

        if(userExists)
            return Result.Conflict(Messages.UserAlreadyExists);

        var passwordHash = PasswordHasher.HashPassword(request.Password);
        var user = new User
        {
            Name     = request.UserName,
            Password = passwordHash
        };

        _context.Add(user);
        await _context.SaveChangesAsync();
        return Result.CreatedResource();
    }
}
