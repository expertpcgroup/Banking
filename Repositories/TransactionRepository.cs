namespace Banking.Repositories
{
    using Banking.Interfaces;
    using Banking.Models;
    using Banking.Response;

    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankingDBContext _dbContact;
        private IResponse<Transaction> _response;
        public TransactionRepository(BankingDBContext dbContext, IResponse<Transaction> response)
        {
            _dbContact = dbContext;
            _response = response;
        }
        public IResponse<Transaction> AddNewTransaction(Transaction tran)
        {
            if (tran == null)
            {
                _response.Result = false;
                _response.Message = "Sent NULL transaction!";
                _response.Payload = null;
            }
            else
            {

                try
                {
                    _dbContact.Transactions.Add(tran);
                    _dbContact.SaveChanges();

                    _response.Result = true;
                    _response.Message = "Transaction successful!";
                    _response.Payload = new List<Transaction> { tran };

                }
                catch
                {
                    _response.Result = false;
                    _response.Message = "The transaction failed, the transaction has not been added to account yet!";
                    _response.Payload = null;
                }
            }
            _response.TimeStamp = DateTime.UtcNow;
            return _response;
        }

        public IResponse<Transaction> DeleteTransactionById(int id)
        {
            Transaction _tran = _dbContact.Transactions.FirstOrDefault(t => t.id == id);
            try
            {
                if (_tran == null)
                {
                    _response.Result = false;
                    _response.Message = $"The transaction with the ID: {id} not found";
                    _response.Payload = null;
                }
                else
                {
                    _dbContact.Transactions.Remove(_tran);
                    _dbContact.SaveChanges();

                    _response.Result = true;
                    _response.Message = "The transaction has been deleted successful!";
                    _response.Payload = new List<Transaction> { _tran };
                }
            }
            catch
            {
                _response.Result = false;
                _response.Message = $"The transaction failed, the transaction has not removed from account yet.";
                _response.Payload = null;
            }
            _response.TimeStamp = DateTime.UtcNow;
            return _response;
        }

        public IResponse<Transaction> GetTransactionById(int id)
        {
            Transaction _tran = _dbContact.Transactions.FirstOrDefault(t => t.id == id);
            if (_tran == null)
            {
                _response.Result = false;
                _response.Message = $"The transaction with the ID: {id} not found";
                _response.Payload = null;
            }
            else
            {
                _response.Result = true;
                _response.Message = "Transaction successful!";
                _response.Payload = new List<Transaction> { _tran };
            }
            _response.TimeStamp = DateTime.UtcNow;
            return _response;
        }

        public IResponse<Transaction> GetTransactions()
        {
            _response = new Response<Transaction>
            {
                TimeStamp = DateTime.UtcNow,
                Message = "Transaction data has been load successful!",
                Result = true,
                Payload = _dbContact.Transactions.ToList()
            };

            return _response;
        }

        public IResponse<Transaction> UpdateTransaction(Transaction tran)
        {
            try
            {
                if (tran == null)
                {
                    _response.Result = false;
                    _response.Message = $"The transaction failed, the transaction has not been updated to account yet!";
                    _response.Payload = null;
                }
                else
                {
                    _dbContact.Transactions.Update(tran);
                    _dbContact.SaveChanges();
                    _response.Result = true;
                    _response.Message = $"The transaction successful, the transaction has been updated to account!";
                    _response.Payload = new List<Transaction> { tran };
                }

            }
            catch (Exception ex)
            {
                _response.Result = false;
                _response.Message = "The transaction failed, the transaction has not been updated to account yet!";
                _response.Payload = null;
            }
            _response.TimeStamp = DateTime.UtcNow;
            return _response;
        }

        public IResponse<Transaction> AccountTransaction(string account_number)
        {
            try
            {
                var _trans = _dbContact.Transactions.Where(t => t.account_number == account_number);
                if (_trans == null)
                {
                    _response.Result = false;
                    _response.Message = "The Account number not found!";
                    _response.Payload = null;
                }
                else
                {
                    _response.Result = true;
                    _response.Message = "The account has been retrieve successful!";
                    _response.Payload = _trans.ToList();
                }
            }
            catch (Exception ex)
            {
                _response.Result = false;
                _response.Message = $"The transaction failed! {ex.InnerException.Message}";
                _response.Payload = null;
            }
            _response.TimeStamp = DateTime.UtcNow;
            return _response;
        }
    }
}
