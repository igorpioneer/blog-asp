using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class PostDto : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Image { get; set; }

        public IEnumerable<OcenaDto> Ocenas { get; set; } = new List<OcenaDto>();
        public IEnumerable<KomentarDto> Komentars { get; set; } = new List<KomentarDto>();
    }
}
