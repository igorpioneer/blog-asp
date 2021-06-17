using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Entity
    {
        public int Id { get; set; }
    }
    public class Category : Entity
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }
}
