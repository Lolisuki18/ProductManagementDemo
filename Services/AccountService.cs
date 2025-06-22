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
        private readonly IAccountRepositorycs iAccountRepository;
        public AccountMember GetAccountById(string accountID)
        {
            return iAccountRepository.GetAccountById(accountID);
        }
    }
}
