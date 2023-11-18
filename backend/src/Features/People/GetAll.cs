namespace Double.Partners.Features.People;

public class GetPersonsResponse
{
    public string FullName { get; init; }
    public string FullDocument { get; init; }
    public string Email { get; init; }
    public string CreatedAt {  get; init; }
}

public class GetPersonsUseCase
{
    private readonly IDbConnection _dbConnection;
    public GetPersonsUseCase(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<IEnumerable<GetPersonsResponse>> ExecuteAsync()
    {
        var persons = await _dbConnection
            .QueryAsync<GetPersonsResponse>("get_persons", commandType: CommandType.StoredProcedure);

        return persons;
    }
}
