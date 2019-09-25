using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account item);
        Account Read(string number);
        void Update(Account item);
    }
}
