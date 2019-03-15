using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantBul.Models
{
    public class Place
    {
        public int PlaceId { get; set; }
        [Display(Name = "Mekan Adı")]
        public string PlaceName { get; set; }
        [Display(Name = "Menü Fotoğrafı")]
        public string MenuPic { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Adres")]
        public string Adress { get; set; }
        [Display(Name = "Çalışma Saatleri")]
        public TimeSpan WorkTime { get; set; } = DateTime.Now.TimeOfDay;
        [Display(Name = "Ortalama Tutar")]
        public decimal AvgPrice { get; set; }
        [Display(Name = "Ek Bilgi")]
        public string  Additional{ get; set; }
        [Display(Name = "Meşhur Şeyler")]
        public string  Famous{ get; set; }

        public virtual ICollection<CatPlace> CatPlace { get; set; }

        //bir mekanın birden fazla yorumu olabilir.
        public virtual ICollection<Comment> Comment { get; set; }

    }
}