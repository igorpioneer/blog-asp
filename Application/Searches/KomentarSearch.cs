using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class KomentarSearch : PagedSearch
    {
        public string Vrednost { get; set; }
        public int AuthorId { get; set; }
        public int UserId { get; set; }
    }
}
