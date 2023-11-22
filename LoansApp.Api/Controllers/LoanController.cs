using LoansApp.Domain.Dtos.Loan;
using LoansApp.Domain.Etities;
using LoansApp.Domain.UseCases.Loan;
using LoansApp.Shared.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoansApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ICreateLoanRequest _createLoanRequest;
        private readonly IGetLoans _getLoans;

        public LoanController(
            ICreateLoanRequest createLoanRequest,
            IGetLoans getLoans
        )
        {
            _createLoanRequest = createLoanRequest;
            _getLoans = getLoans;
        }

        [HttpPost("new/request")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<LoanEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Result<object>))]
        public async Task<ActionResult<Result<LoanEntity>>> Create([FromBody] CreateLoanRequestInputDTO input)
        {
            try
            {
                UserEntity? user = HttpContext.Items["User"] as UserEntity;
                Result<LoanEntity> newLoan = await _createLoanRequest.Execute(
                    input,
                    user is not null ? user.Id : string.Empty
                );
                return StatusCode(GetHttpStatusCode.Get(newLoan.Status), newLoan);
            }
            catch (Exception exc)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    Result<object>.InternalError(message: exc.Message, content: null)
                );
            }
        }

        [HttpGet()]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<IList<LoanEntity>>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Result<object>))]
        public ActionResult<Result<IList<LoanEntity>>> GetAll()
        {
            try
            {
                UserEntity? user = HttpContext.Items["User"] as UserEntity;
                Result<IList<LoanEntity>> loans = _getLoans.Execute(
                    user is not null ? user.Id : string.Empty
                );
                return StatusCode(GetHttpStatusCode.Get(loans.Status), loans);
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