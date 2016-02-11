using GESTACAJOU.Models;
using GESTACAJOU.SQLENGINE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace GESTACAJOU.Controllers
{
    public class PartenaireController : Controller
    {
        Partenaire PartenerToModify;
       
        //Get
        public ActionResult CreatePartenaire()
        {
            return View();
        }

        //Get
        public ActionResult ModifyPartener()
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());
            PartenerToModify = new Partenaire();
            PARTENAIRE part=new PARTENAIRE();
            part.LoadId(id);
            PartenerToModify.CONTACT = part.CONTACT;
            PartenerToModify.ID_AUTO = part.ID_AUTO;
            PartenerToModify.NOM = part.NOM;
            PartenerToModify.PRENOM = part.PRENOM;
            return View(PartenerToModify);
        }

        public ActionResult DeletePartener()
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());
            Partenaire Part  = new Partenaire();
            PARTENAIRE parts = new PARTENAIRE();
            parts.LoadId(id);
            Part.CONTACT = parts.CONTACT;
            Part.ID_AUTO = parts.ID_AUTO;
            Part.NOM = parts.NOM;
            Part.PRENOM = parts.PRENOM;
            return View(Part);
        }

        // GET: /Partenaire/

        public ActionResult IndexPartenaire()
        {
            PARTENAIRE _partenaire = new PARTENAIRE();
            List<Partenaire> _list = new List<Partenaire>(); 
            foreach (PARTENAIRE item in PARTENAIRE.GetList())
            {
                Partenaire partener=new Partenaire();
                partener.CONTACT=item.CONTACT;
                 partener.NOM=item.NOM;
                 partener.PRENOM=item.PRENOM;
                 partener.ID_AUTO=item.ID_AUTO;
                _list.Add(partener);
            }
           
            return View(_list);
        }


        // POST: /Partenaire/Create
        [HttpPost]
        public ActionResult CreatePartenaire(Partenaire PartenerToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                PARTENAIRE _partenaire = new PARTENAIRE();
                _partenaire.CONTACT = PartenerToCreate.CONTACT;
                _partenaire.NOM = PartenerToCreate.NOM;
                _partenaire.PRENOM = PartenerToCreate.PRENOM;
                _partenaire.Save();
                return RedirectToAction("../Partenaire/IndexPartenaire");
            }
            catch
            {
                return View();
            }

        }
        // POST: /Partenaire/Modify
        [HttpPost]
        public ActionResult ModifyPartener(Partenaire PartenerToModify)
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());
            if (!ModelState.IsValid)
                return View();

            try
            {
                PARTENAIRE _partenaire = new PARTENAIRE();
                _partenaire.CONTACT = PartenerToModify.CONTACT;
                _partenaire.NOM = PartenerToModify.NOM;
                _partenaire.PRENOM = PartenerToModify.PRENOM;
                _partenaire.SetId(id);
                _partenaire.Save();
                return RedirectToAction("../Partenaire/IndexPartenaire");
            }
            catch
            {
                return View();
            }

        }

        // POST: /Partenaire/del
        [HttpPost]
        public ActionResult DeletePartener(Partenaire PartenerToDel)
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());
            if (!ModelState.IsValid)
                return View();

            try
            {
                PARTENAIRE _partenaire = new PARTENAIRE();
                _partenaire.SetId(id);
                _partenaire.Delete();
                return RedirectToAction("../Partenaire/IndexPartenaire");//reafficher l liste
            }
            catch
            {
                //gerer l'exeption au cas ou on n peut supprimer cet partenaire car il est deja utilise
                return View();
            }

        }
    }
}