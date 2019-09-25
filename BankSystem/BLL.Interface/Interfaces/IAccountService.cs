using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        Account Create(AccountOwner owner, IAccountNumberGenerator generator);
        void Close(Account account);
        void Freeze(Account account);
        void Active(Account account);
        void Deposit(Account account, decimal amount);
        void Withdraw(Account account, decimal amount);
    }
}
