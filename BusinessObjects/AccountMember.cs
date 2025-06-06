using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public partial class AccountMember
    {
        public string memberId { get; set; }
        public string memberPassword { get; set; }
        public string fullName { get; set; }
        public string? emailAddress { get; set; }
        public int? memberRole { get; set; }
    }
}
