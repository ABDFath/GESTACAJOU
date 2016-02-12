using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESTACAJOU.Models
{
    public class Vente_Details
    {
        public int ID_AUTO { get; set; }

        [Required]
        public int ID_VENTE { get; set; }

        [Required]
        public int ID_CHARGEMENT { get; set; }

        [Required]
        public int PRIX_UNITAIRE { get; set; }

        [Required]
        public int QTE { get; set; }

        [Required]
        public int TOTAL { get; set; }

        public string VENTE { get; set; }
        public string CHARGEMENT { get; set; }
    }
}