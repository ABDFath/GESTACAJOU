using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESTACAJOU.Models
{
    public class Zone
    {
        public int ID_AUTO { get; set; }

        [Required]
        public string NOM { get; set; }


        public string CONTROLEUR { get; set; }

        [Required]
        public int ID_CONT { get; set; }
    }
}