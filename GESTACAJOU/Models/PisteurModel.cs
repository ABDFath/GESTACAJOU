using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTACAJOU.Models
{
    public class PisteurModel
    {
        public int ID_AUTO { get; set; }
        public string NOM { get; set; }
        public string PRENOM { get; set; }
        public string TEL { get; set; }
        public string VILLAGE { get; set; }
        public int ID_ZONE { get; set; }
        public string ZONE { get; set; }

        public PisteurModel(string nom, string prenom, string tel, string village, int id_zone)
        {
            NOM = nom;
            prenom = PRENOM;
            TEL = tel;
            VILLAGE = village;
            ID_ZONE = id_zone;
        }

        public static PisteurModel Create(string nom, string prenom, string tel, string village, int id_zone)
        {
            return new PisteurModel(nom,prenom,tel,village,id_zone);
        }
    }
}