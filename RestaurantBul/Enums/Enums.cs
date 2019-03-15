using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantBul.Enums
{
    public class Enums
    {
        public enum CategoryName
        {
            [Description("Kahvaltı")]
            [Display(Name = "Kahvaltı")]
            Kahvalti,
            [Description("Eğlenceye Çık")]
            [Display(Name = "Eğlenceye Çık")]
            EglenceyeCik,
            [Description("Ye ve Kalk")]
            [Display(Name = "Ye ve Kalk")]
            YeveKalk,
            [Description("Kafeye Git")]
            [Display(Name = "Kafeye Git")]
            CafeyeGit,
            [Description("Yemek")]
            [Display(Name = "Yemek")]
            Yemek
        }
    }
}