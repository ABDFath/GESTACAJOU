using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTACAJOU.Models
{
    public class Utilisateur
    {
 

        public int ID_AUTO { get; set; }
        
        public string NOM { get; set; }


        public string PRENOM { get; set; }

        public string CONTACT { get; set; }

        public string PWD { get; set; }
        

        public int ID_GROUP { get; set; }


        public string _GROUP { get; set; }
    }
}