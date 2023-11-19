namespace Double.Partners.Features.Users;

public class UserLoginRequest
{
    public string UserName { get; init; }
    public string Password { get; init; }
}

public class UserLoginResponse
{
    public string UserName { get; init; }
    public string AccessToken { get; init; }
}

public class UserLoginValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginValidator()
    {
        RuleFor(request => request.UserName).NotEmpty();
        RuleFor(request => request.Password).NotEmpty();
    }
}

public class UserLoginUseCase
{
    private readonly DbContext _context;
    public UserLoginUseCase(DbContext context) => _context = context;

    public async Task<Result<UserLoginResponse>> ExecuteAsync(UserLoginRequest request)
    {
        ValidationResult result = new UserLoginValidator().Validate(request);
        if (result.IsFailed())
            return Result.Invalid(result.AsErrors());

        var user = await _context.Set<User>()
            .Where(u => u.Name == request.UserName)
            .Select(u => new 
            { 
                u.Id,
                u.Name,
                u.Password 
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if(user is null || !PasswordHasher.Verify(request.Password, user.Password))
            return Result.Unauthorized(Messages.InvalidCredentials);

        var accessToken = new JwtGenerator().CreateToken(user.Id, user.Name);
        var response = new UserLoginResponse
        {
            UserName = request.UserName,
            AccessToken = accessToken
        };

        return Result.Success(response, Messages.LoginSuccessfully);
    }
}
