using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class KomentarDto : Entity
    {
        public string Vrednost { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
