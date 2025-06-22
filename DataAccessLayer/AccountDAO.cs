using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        public static AccountMember? GetAccountById(string accountID)
        {
            if (accountID == "PSS0001")
            {
                return new AccountMember
                {
                    MemberId = "PSS0001",
                    MemberPassword = "@1",
                    FullName = "Admin",
                    EmailAddress = "admin@example.com",
                    MemberRole = 1
                };
            }

            return null;
        }
    }
}
