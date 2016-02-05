using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTACAJOU.Models
{
    public class TypeChargeModel
    {
        public int ID_AUTO { get; set; }
        public string NOM { get; set; }

        public TypeChargeModel(string nom)
        {
            NOM = nom;
        }

        public static TypeChargeModel Create(string nom)
        {
            return new TypeChargeModel(nom);
        }
    }
}