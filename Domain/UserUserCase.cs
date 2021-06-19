using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Domain
{
    public class UserUserCase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserCaseId { get; set; }
        public virtual User User { get; set; }
        public virtual UserCase UserCase { get; set; }
    }
}
