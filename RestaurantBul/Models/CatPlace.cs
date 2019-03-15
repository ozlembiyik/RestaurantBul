using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantBul.Models
{
    public class CatPlace
    {
        [Key]
        public int CatPlaceId { get; set; }
        public int PlaceId { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }
        public virtual Place Place{ get; set; }
    }
}