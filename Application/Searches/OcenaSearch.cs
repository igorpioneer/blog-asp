using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class OcenaSearch : PagedSearch
    {
        public int Vrednost { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
