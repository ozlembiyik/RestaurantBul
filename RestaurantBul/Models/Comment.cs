using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantBul.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Display(Name = "Yorum İçeriği")]
        public string CommentContent { get; set; }
        [Display(Name = "Fotoğraf")]
        public string CommentPhoto { get; set; }
        [Display(Name = "Puan")]
        public string CommentPoint{ get; set; }

        //bir yorum bir kullanıcıya ait
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        //bir yorum bir mekana ait
        public int? PlaceId { get; set; }
        public virtual Place Place { get; set; }

    }
}