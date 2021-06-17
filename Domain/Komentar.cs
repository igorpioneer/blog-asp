using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Komentar : Entity
    {
        [Required]
        public string Vrednost { get; set; }
       
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
