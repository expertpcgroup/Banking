using Microsoft.AspNetCore.Mvc;

namespace Banking.Controllers
{
    using Banking.Interfaces;
    using Banking.Models;
    using Banking.Response;

    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transaction;
        private IResponse<Transaction> _response;

        public TransactionController(ITransactionRepository transactionRepository, IResponse<Transaction> response)
        {
            _transaction = transactionRepository;
            _response = response;
        }

        [HttpGet("{id}", Name = "Get transaction data by Id")]
        public ActionResult<IResponse<Transaction>> Get(int id)
        {
            try
            {
                _response = _transaction.GetTransactionById(id);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "Get all transaction data")]
        public ActionResult<IResponse<Transaction>> Get()
        {
            _response = _transaction.GetTransactions();
            return Ok(_response);
        }

        [HttpPost(Name = "Create a transaction data")]
        public ActionResult<IResponse<Transaction>> Post(Transaction tran)
        {
            _response = _transaction.AddNewTransaction(tran);
            return Ok(_response);
        }

        [HttpPut(Name = "Update an existing transaction data")]
        public ActionResult<IResponse<Transaction>> Put(Transaction tran)
        {
            _response = _transaction.UpdateTransaction(tran);
            return Ok(_response);
        }

        [HttpDelete("{id}", Name = "Delete an existing transaction data")]
        public ActionResult<IResponse<Transaction>> Delete(int id)
        {
            _response = _transaction.DeleteTransactionById(id);
            return Ok(_response);
        }

        [HttpGet("account_number", Name = "Get the transaction record by the user account number")]
        public ActionResult<IResponse<Transaction>> GetUserAccount(string account_number)
        {
            _response = _transaction.AccountTransaction(account_number);
            return Ok(_response);
        }
    }
}
