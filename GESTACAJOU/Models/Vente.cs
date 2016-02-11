using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GESTACAJOU.Models
{
    public class Vente
    {
        public int ID_AUTO { get; set; }

        [Required]
        public int ID_PARTENAIRE { get; set; }

        [Required]
        public int MONTANT_TOTAL { get; set; }

        [Required]
        public int QTE_TOTAL { get; set; }

        [Required]
        public DateTime DATE_OPERATION { get; set; }

        public string PARTENAIRE { get; set; }

        public List<Vente_Details> VENTE_DETAILS { get; set; }

        public IEnumerable<SelectListItem> _list2 { get; set; }

        public Vente()
        {
            VENTE_DETAILS = new List<Vente_Details>();
        }
    }
}