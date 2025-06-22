using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository iAccountRepository;

        public AccountService()
        {
            iAccountRepository = new AccountRepository(); 
        }
        public AccountMember GetAccountById(string accountID)
        {
            if (string.IsNullOrEmpty(accountID))
            {
                throw new ArgumentException(nameof(accountID));
            }
            var account = iAccountRepository.GetAccountById(accountID);
            if(account == null)
            {
                throw new Exception("Account not found");
            }
            return account;
        }
    }
}
