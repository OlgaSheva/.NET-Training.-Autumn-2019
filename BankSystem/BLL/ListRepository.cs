using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL
{
    // фкйковый репозиторий для тестирования
    class ListRepository : IAccountRepository
    {
        private List<Account> accounts = new List<Account>();

        public void Create(Account item)
        {
            accounts.Add(item);
        }

        public Account Read(string number)
        {
            throw new NotImplementedException();
            // contains
        }

        // ?
        public void Update(Account item)
        {
            throw new NotImplementedException();
            // находим и обновляем
        }
    }
}
