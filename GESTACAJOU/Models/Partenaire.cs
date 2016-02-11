using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Globalization;

namespace GESTACAJOU.Models
{
    public class Partenaire
    {

        public int ID_AUTO { get; set; }

        [Required]
        public string NOM { get; set; }

        [Required]
        public string PRENOM { get; set; }

        [Required]
        public string CONTACT { get; set; }

        public List<Vente> Ventes { get; set; }

        public Partenaire()
        {
            Ventes = new List<Vente>(); 
        }
        public override string ToString()
        {
            return NOM + " " + PRENOM;
        }
    }
}