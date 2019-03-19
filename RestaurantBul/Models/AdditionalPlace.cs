using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantBul.Models
{
    public class AdditionalPlace
    {
        [Key]
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public int AdditionalId { get; set; }
        public virtual Additional Additional { get; set; }
        public virtual Place Place { get; set; }
    }
}