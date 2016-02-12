using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTACAJOU.Models
{
    public class UserModel
    {
        public int ID_AUTO { get; set; }
        public string NOM { get; set; }
        public string PRENOM { get; set; }
        public string TEL { get; set; }
        public string PWD { get; set; }
        public int ID_GROUP { get; set; }
        public string GROUP { get; set; }

        public UserModel(string nom, string prenom, string tel, string pwd, int id_group)
        {
            NOM = nom;
            prenom = PRENOM;
            TEL = tel;
            PWD = pwd;
            ID_GROUP = id_group;
        }

        public static UserModel Create(string nom, string prenom, string tel, string pwd, int id_group)
        {
            return new UserModel(nom, prenom, tel, pwd, id_group);
        }

        public override string ToString()
        {
            return NOM + ' ' + PRENOM;
        }
    }
}