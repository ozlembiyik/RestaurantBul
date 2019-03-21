using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantBul.Models
{
    public class Additional
    {
        public  int AdditionalId { get; set; }
        public  bool Otopark { get; set; }
        [Display(Name = "Deniz Kenarı")]
        public  bool DenizKenari { get; set; }

        [Display(Name = "Dış Mekan")]
        public bool DisMekan { get; set; }

        [Display(Name = "İç Mekan")]
        public  bool İcMekan { get; set; }

        [Display(Name = "Terası Var")]
        public  bool TerasiVar { get; set; }

        [Display(Name = "Alkol Servis")]
        public  bool AlkolServis { get; set; }

        [Display(Name = "Wifi")]
        public  bool Wifi { get; set; }

        [Display(Name = "Online Rezervasyon")]
        public  bool OnlineRezervasyon { get; set; }

        [Display(Name = "Kahvaltı")]
        public  bool Kahvalti { get; set; }

        [Display(Name = "Gel Al")]
        public  bool GelAl { get; set; }

        [Display(Name = "Hayvan Dostu")]
        public  bool HayvanDostu { get; set; }

        [Display(Name = "Sigara Alanı")]
        public  bool SigaraAlanı { get; set; }

        [Display(Name = "Paket Servis")]
        public  bool PaketServis { get; set; }

        [Display(Name = "Tatlı ve Pasta")]
        public  bool TatlivePasta { get; set; }

        [Display(Name = "Canlı Müzik")]
        public  bool CanliMuzik { get; set; }


        public virtual ICollection<AdditionalPlace> AdditionalPlaces { get; set; }

    }
}