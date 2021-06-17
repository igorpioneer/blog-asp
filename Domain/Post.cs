using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Slika { get; set; }
        public virtual ICollection<Ocena> Ocene { get; set; } = new HashSet<Ocena>();
        public virtual ICollection<Komentar> Komentars { get; set; } = new HashSet<Komentar>();
    }
}
