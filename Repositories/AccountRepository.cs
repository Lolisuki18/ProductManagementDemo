using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDAO accountDAO;

        public AccountRepository()
        {
            accountDAO = new AccountDAO();
        }

        public AccountMember GetAccountById(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentNullException(nameof(accountId));
            }
            return AccountDAO.GetAccountById(accountId);
        }
    }
}
