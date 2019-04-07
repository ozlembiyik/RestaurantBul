using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static RestaurantBul.Enums.Enums;

namespace RestaurantBul.Models.ViewModel
{
    public class PlaceAdditionalViewModel
    {

        [Display(Name = "Mekan Adı")]
        public string PlaceName { get; set; }

        public int PlaceId { get; set; }

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

        public bool Otopark { get; set; }
        [Display(Name = "Deniz Kenarı")]
        public bool DenizKenari { get; set; }

        [Display(Name = "Dış Mekan")]
        public bool DisMekan { get; set; }

        [Display(Name = "İç Mekan")]
        public bool İcMekan { get; set; }

        [Display(Name = "Terası Var")]
        public bool TerasiVar { get; set; }

        [Display(Name = "Alkol Servis")]
        public bool AlkolServis { get; set; }

        [Display(Name = "Wifi")]
        public bool Wifi { get; set; }

        [Display(Name = "Online Rezervasyon")]
        public bool OnlineRezervasyon { get; set; }

        [Display(Name = "Kahvaltı")]
        public bool Kahvalti { get; set; }

        [Display(Name = "Gel Al")]
        public bool GelAl { get; set; }

        [Display(Name = "Hayvan Dostu")]
        public bool HayvanDostu { get; set; }

        [Display(Name = "Sigara Alanı")]
        public bool SigaraAlanı { get; set; }

        [Display(Name = "Paket Servis")]
        public bool PaketServis { get; set; }

        [Display(Name = "Tatlı ve Pasta")]
        public bool TatlivePasta { get; set; }

        [Display(Name = "Canlı Müzik")]
        public bool CanliMuzik { get; set; }
        public string CommentContent { get; set; }
        [Display(Name = "Fotoğraf")]
        public string CommentPhoto { get; set; }
        [Display(Name = "Puan")]
        public int CommentPoint { get; set; }
    }
}