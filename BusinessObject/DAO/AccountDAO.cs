using BusinessObject;
using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DAO
{
    public class AccountDAO
    {
        //Using Singleton Pattern
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        //---------------------------------------
        public IEnumerable<Account> GetAccountList()
        {
            var staffList = new List<Account>();
            try
            {
                using var context = new CinemaDbContext();
                staffList = context.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staffList;
        }

        //-------------------------------------
        public Account GetAccountByID(int accId)
        {
            Account staff1 = null;
            try
            {
                using var context = new CinemaDbContext();
                staff1 = context.Accounts.SingleOrDefault(c => c.AccountId == accId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staff1;
        }
        //---------------------------------------
        public void AddNew(Account acc)
        {
            try
            {
                Account _acc = GetAccountByID(acc.AccountId);
                if (_acc == null)
                {
                    using var context = new CinemaDbContext();
                  //  acc.Password = BCrypt.Net.BCrypt.HashPassword(acc.Password);
                    context.Accounts.Add(acc);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The account is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------------------------------------------
        public void Update(Account acc)
        {
            try
            {
                Account _acc = GetAccountByID(acc.AccountId);
                if (_acc != null)
                {
                    using var context = new CinemaDbContext();
                    context.Accounts.Update(acc);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The account is not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //----------------------------------------
        public void Remove(int accId)
        {
            try
            {
                Account sta = GetAccountByID(accId);
                if (sta != null)
                {
                    using var context = new CinemaDbContext();
                    context.Accounts.Remove(sta);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The account is not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
