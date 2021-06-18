using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Domain
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Message { get; set; }
    }
}
