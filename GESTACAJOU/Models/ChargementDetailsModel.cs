using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTACAJOU.Models
{
    public class ChargementDetailsModel
    {
        public int ID_AUTO { get; set; }
        public int PRIX_UNIT { get; set; }
        public int QTE { get; set; }
        public int TOTAL { get; set; }
        public int ID_PISTEUR { get; set; }
        public int ID_CHARGEMENT { get; set; }
        public string PISTEUR { get; set; }
        public string CHARGEMENT { get; set; }

        public ChargementDetailsModel()
        { 
        
        }
    }
}