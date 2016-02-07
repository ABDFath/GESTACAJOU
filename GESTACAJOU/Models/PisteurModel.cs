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
        private List<PisteurModel> _list;
        public List<PisteurModel> ListPisteurs
        {
            get { return _list; }
            set { _list = value; } 
        }

        public PisteurModel()
        {
            _list = new List<PisteurModel>();
        }

        public PisteurModel(string nom, string prenom, string tel, string village, int id_zone)
        {
            NOM = nom;
            PRENOM = prenom;
            TEL = tel;
            VILLAGE = village;
            ID_ZONE = id_zone;
           
        }

        public static PisteurModel Create(string nom, string prenom, string tel, string village, int id_zone)
        {
            return new PisteurModel(nom,prenom,tel,village,id_zone);
        }

        public List<PisteurModel> GetList()
        {

            //ListPisteurs = new List<PisteurModel>();
            _list.Add(PisteurModel.Create("ABALO", "Paul", "66324567", "OPKARA", 1));
            return _list;
        }
    }
}