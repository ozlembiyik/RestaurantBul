using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int CommentPoint{ get; set; }

        //bir yorum bir kullanıcıya ait
        public string UserId { get; set; }
        public  ApplicationUser ApplicationUser { get; set; }  
        //bir yorum bir mekana ait
        public int? PlaceId { get; set; }
        public virtual Place Place { get; set; }
        [NotMapped]
        public virtual Place Places { get; set; }
       
      

    }
}