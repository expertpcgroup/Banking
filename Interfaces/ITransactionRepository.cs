namespace Banking.Interfaces
{
    using Banking.Models;
    using Banking.Response;
    public interface ITransactionRepository
    {
        public IResponse<Transaction> GetTransactions();
        public IResponse<Transaction> AddNewTransaction(Transaction tran);
        public IResponse<Transaction> UpdateTransaction(Transaction tran);
        public IResponse<Transaction> GetTransactionById(int id);
        public IResponse<Transaction> DeleteTransactionById(int id);
        public IResponse<Transaction> AccountTransaction(string account_number);
    }
}
