using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static RestaurantBul.Enums.Enums;

namespace RestaurantBul.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Kategori Adı")]
        public CategoryName CategoryName { get; set; }
        public virtual ICollection<CatPlace> CatPlace { get; set; }
        

    }
}