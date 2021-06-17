using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class User : Entity
    {
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public virtual ICollection<UserUserCase> UserUserCases { get; set; } = new HashSet<UserUserCase>();

        public virtual ICollection<Ocena> Ocene { get; set; } = new HashSet<Ocena>();
        public virtual ICollection<Komentar> Komentars { get; set; } = new HashSet<Komentar>();
    }
}
