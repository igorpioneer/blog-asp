using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserUserCase : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int UseCaseId { get; set; }
    }
}
