using LoansApp.Domain.Dtos.User;
using LoansApp.Domain.Etities;
using LoansApp.Domain.UseCases.User;
using LoansApp.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LoansApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISignUp _signUp;
        private readonly ISignIn _signIn;

        public UserController(ISignUp signUp, ISignIn signIn)
        {
            _signUp = signUp;
            _signIn = signIn;
        }

        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<UserEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Result<object>))]
        public async Task<ActionResult<Result<UserEntity>>> SignUp([FromBody] SignUpInputDTO input)
        {
            try
            {
                Result<UserEntity> newUser = await _signUp.Execute(input);
                return StatusCode(GetHttpStatusCode.Get(newUser.Status), newUser);
            }
            catch (Exception exc)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    Result<object>.InternalError(message: exc.Message, content: null)
                );
            }
        }

        [HttpPost("signin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<SignInOutputDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Result<object>))]
        public async Task<ActionResult<Result<SignInOutputDTO>>> SignIn([FromBody] SignInInputDTO input)
        {
            try
            {
                Result<SignInOutputDTO> credentials = await _signIn.Execute(input);
                return StatusCode(GetHttpStatusCode.Get(credentials.Status), credentials);
            }
            catch (Exception exc)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    Result<object>.InternalError(message: exc.Message, content: null)
                );
            }
        }
    }
}