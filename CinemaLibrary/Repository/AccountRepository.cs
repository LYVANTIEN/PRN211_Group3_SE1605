using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccountById(int accId) => AccountDAO.Instance.GetAccountByID(accId);

        public IEnumerable<Account> GetAccounts() => AccountDAO.Instance.GetAccountList();

        public void InsertAccount(Account acc) => AccountDAO.Instance.AddNew(acc);

        public void DeleteAccount(int accId) => AccountDAO.Instance.Remove(accId);
        public void UpdateAccount(Account acc) => AccountDAO.Instance.Update(acc);
    }
}
