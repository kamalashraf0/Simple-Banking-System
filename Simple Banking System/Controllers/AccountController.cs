using Application.Services.AccountService;
using Core.DTOs;
using Core.DTOs.Response;
using Core.Features.Commands.AccountCommands;
using Core.Features.Queries.AccountQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Simple_Banking_System.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;
        private readonly ILogger<AccountController> logger;
        private readonly IMediator mediator;


        public AccountController(IAccountService _accountService,
            ILogger<AccountController> _logger,
            IMediator _mediator)
        {
            accountService = _accountService;
            logger = _logger;
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAllAccounts()
        {


            logger.LogInformation("Fetching all accounts");
            var accounts = await accountService.GetAllAccountsAsync();
            logger.LogInformation("Successfully fetching accounts");
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccountById(int id)
        {

            var query = new GetAccountByIdQuery(id);
            var account = await mediator.Send(query);
            GenericResponse genericResponse = new GenericResponse();
            if (account == null)
            {
                genericResponse.isSuccess = false;
                genericResponse.message = $"The ID {id} is not Exists";
            }
            else
            {

                genericResponse.isSuccess = true;
                genericResponse.Data = account;
                genericResponse.message = "Data Retrieved Successfully";
            }
            return Ok(genericResponse);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccountByCustomerId(int id)
        {


            var account = await accountService.GetAccountsByCustomerIdAsync(id);
            GenericResponse genericResponse = new GenericResponse();
            if (account == null)
            {
                genericResponse.isSuccess = false;
                genericResponse.message = $"The ID {id} is not Exists";
            }
            else
            {

                genericResponse.isSuccess = true;
                genericResponse.Data = account;
                genericResponse.message = "Data Retrieved Successfully";
            }
            return Ok(genericResponse);

        }


        [HttpPost]
        public async Task<ActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {

            try
            {
                var accountId = await mediator.Send(command);
                if (accountId == 0)
                {
                    return BadRequest(new GenericResponse
                    {
                        isSuccess = false,
                        message = "Customer ID does not exist."
                    });
                }

                return Ok(new GenericResponse
                {
                    isSuccess = true,
                    message = "Account created successfully.",
                    Data = new { AccountId = accountId }
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new GenericResponse
                {
                    isSuccess = false,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GenericResponse
                {
                    isSuccess = false,
                    message = "An unexpected error occurred.",
                    Data = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditAccount([FromRoute] int id, [FromBody] UpdateAccountCommand command)
        {
            command.AccountId = id;
            var account = await mediator.Send(command);
            if (account)
                return Ok(new GenericResponse { isSuccess = true, message = "Account updated successfully" });

            return NotFound(new GenericResponse { isSuccess = false, message = "Account not found" });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            var account = await accountService.GetAccountByIdAsync(id);
            if (account == null)
            {

                return NotFound(new GenericResponse { isSuccess = false, message = "Account not found" });
            }

            await accountService.DeleteAccountAsync(id);

            return Ok(new GenericResponse { isSuccess = true, message = "Account Deleted successfully" });
        }

    }
}
