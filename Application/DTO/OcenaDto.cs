using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class OcenaDto : Entity
    {
        public int Vrednost { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }
    }
}
