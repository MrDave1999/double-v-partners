namespace Double.Partners.Features.People;

[TranslateResultToActionResult]
[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    [HttpPost]
    public async Task<Result> Create([FromBody]CreatePersonRequest request, [FromServices]CreatePersonUseCase useCase)
        => await useCase.ExecuteAsync(request);

    [HttpGet]
    public async Task<IEnumerable<GetPersonsResponse>> GetAll([FromServices]GetPersonsUseCase useCase)
        => await useCase.ExecuteAsync();
}
