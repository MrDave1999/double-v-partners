namespace Double.Partners.Features.Users;

[TranslateResultToActionResult]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<Result> Create([FromBody]CreateUserRequest request, CreateUserUseCase useCase)
        => await useCase.ExecuteAsync(request);

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<Result<UserLoginResponse>> Login([FromBody]UserLoginRequest request, UserLoginUseCase useCase)
        => await useCase.ExecuteAsync(request);
}
