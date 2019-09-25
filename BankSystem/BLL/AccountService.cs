using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL
{
    public class AccountService : IAccountService
    {
        private IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public void Active(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void Close(Account account)
        {
            throw new System.NotImplementedException();
        }

        public Account Create(AccountOwner owner, IAccountNumberGenerator generator)
        {
            //return repository.Create(owner, generator);
        }

        public void Deposit(Account account, decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public void Freeze(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void Withdraw(Account account, decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
