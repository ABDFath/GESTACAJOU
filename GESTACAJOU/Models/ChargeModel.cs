using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTACAJOU.Models
{
    public class ChargeModel
    {
        public int ID_AUTO { get; set; }
        public int COUT { get; set; }
        public DateTime DATE_EXECUTION { get; set; }
        public int ID_TYPE_CHARGE { get; set; }
        public int ID_CHARGEMENT { get; set; }
        public string TYPE_CHARGE { get; set; }
        public string CHARGEMENT { get; set; }

        public static ChargeModel Make(ChargementModel chargement, TypeChargeModel type)
        {
            return new ChargeModel() { COUT = 0, ID_CHARGEMENT = chargement.ID_AUTO, ID_TYPE_CHARGE = type.ID_AUTO, DATE_EXECUTION = DateTime.Now };
        }

    }
}