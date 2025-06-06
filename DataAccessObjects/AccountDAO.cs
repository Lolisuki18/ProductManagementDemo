using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string accountID)
        {
            AccountMember accountMember = new AccountMember();
            if (accountID.Equals("PS0001"))
            {
                accountMember.memberId = accountID;
                accountMember.memberPassword = "@1";
                accountMember.memberRole = 1;
            }
            return accountMember;
        }
    }
}
