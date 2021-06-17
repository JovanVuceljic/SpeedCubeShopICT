using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Domain
{
    public class UserCase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserUserCase> UserUserCases { get; set; }
    }
}
