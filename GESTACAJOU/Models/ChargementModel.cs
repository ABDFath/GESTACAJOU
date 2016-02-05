using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTACAJOU.Models
{
    public class ChargementModel
    {
        public int ID_AUTO { get; set; }
        public string INTITULE { get; set; }
        public int PRIX_TOTAL_ACHAT { get; set; }
        public int QTE_TOTAL_ACHAT { get; set; }
        public int QTE_TOTAL_SORTI { get; set; }
        public int QTE_TOTAL_VENDU { get; set; }
        public int PRIX_REVIENT { get; set; }
        public DateTime DATE_OPERATION { get; set; }
        public int ID_ZONE { get; set; }
        public int ID_UTILISATEUR { get; set; }
        public string ZONE { get; set; }
        public string UTILISATEUR { get; set; }

        public List<ChargementDetailsModel> DETAILS { get; set; }

        public ChargementModel()
        {
            DETAILS = new List<ChargementDetailsModel>();
        }

    }
}