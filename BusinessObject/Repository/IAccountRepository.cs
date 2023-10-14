using BusinessObject;
using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccountById(int accId);
        void InsertAccount(Account acc);
        void DeleteAccount(int accId);
        void UpdateAccount(Account acc);
    }
}
