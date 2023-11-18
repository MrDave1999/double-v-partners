namespace Double.Partners.Features.People;

public class CreatePersonRequest
{
    public string Names { get; init; }
    public string LastNames { get; init; }
    public string Document { get; init; }
    public DocumentType DocumentType { get; init; }
    public string Email { get; init; }

    public Person MapToPerson() => new()
    {
        Names        = Names,
        LastNames    = LastNames,
        Document     = Document,
        DocumentType = DocumentType,
        Email        = Email,
        FullName     = LastNames + " " + Names,
        FullDocument = DocumentType.AsString(EnumFormat.Description) + " " + Document
    };
}

public class CreatePersonValidator : AbstractValidator<CreatePersonRequest>
{
    public CreatePersonValidator()
    {
        RuleFor(request => request.Names).NotEmpty();
        RuleFor(request => request.LastNames).NotEmpty();
        RuleFor(request => request.Document).NotEmpty();
        RuleFor(request => request.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(request => request.DocumentType)
            .NotEmpty()
            .IsInEnum();
    }
}

public class CreatePersonUseCase
{
    private readonly DbContext _context;
    public CreatePersonUseCase(DbContext context) => _context = context;

    public async Task<Result> ExecuteAsync(CreatePersonRequest request)
    {
        ValidationResult result = new CreatePersonValidator().Validate(request);
        if (result.IsFailed())
            return Result.Invalid(result.AsErrors());

        var person = request.MapToPerson();
        _context.Add(person);
        await _context.SaveChangesAsync();
        return Result.CreatedResource();
    }
}
