using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantBul.Models
{
    public class User:ApplicationUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //bir kullanıcı birden fazla yorum atabilir
        public virtual ICollection<Comment>Comments { get; set; }
    }
}