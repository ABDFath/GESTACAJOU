using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GESTACAJOU.Models.Business;

namespace GESTACAJOU.Models
{
    public class PisteurModel
    {
        public int ID_AUTO { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string NOM { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string PRENOM { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Merci de saisir un numéro de téléphone valide")]
        [Required(ErrorMessage = "Le téléphone est obligatoire")]
        public string TEL { get; set; }

        public string VILLAGE { get; set; }

        [Required(ErrorMessage = "La zone  est obligatoire")]
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

        public PisteurModel(int Id, string nom, string prenom, string tel, string village, int id_zone)
        {
            ID_AUTO = Id;
            NOM = nom;
            PRENOM = prenom;
            TEL = tel;
            VILLAGE = village;
            ID_ZONE = id_zone;
           
        }

        public static PisteurModel Create(int id, string nom, string prenom, string tel, string village, int id_zone)
        {
            return new PisteurModel(id, nom,prenom,tel,village,id_zone);
        }

        public List<PisteurModel> GetList()
        {

            //ListPisteurs = new List<PisteurModel>();
            _list = DbFactory.GetListPisteur();
            //_list.Add(PisteurModel.Create("ABALO", "Paul", "66324567", "OPKARA", 1));
            return _list;
        }
    }
}