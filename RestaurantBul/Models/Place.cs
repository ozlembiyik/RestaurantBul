﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static RestaurantBul.Enums.Enums;

namespace RestaurantBul.Models
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        [Display(Name = "Mekan Adı")]
        public string PlaceName { get; set; }

        [Display(Name = "Kategori Adı")]
        public CategoryName CategoryName { get; set; }

        [Display(Name = "Menü Fotoğrafı")]
        public string MenuPic { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Adres")]
        public string Adress { get; set; }
        [Display(Name = "İlçe")]
        public string County { get; set; }
        [Display(Name = "İl")]
        public string City { get; set; }
        [Display(Name = "Açılış Saati")]
        public string OpenTime { get; set; }

        [Display(Name = "Kapanış Saati")]
        public string CloseTime { get; set; }

        [Display(Name = "Ortalama Tutar")]
        public decimal AvgPrice { get; set; }
      
        //bir mekanın birden fazla yorumu olabilir.
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<AdditionalPlace> AdditionalPlaces { get; set; }

    }
}