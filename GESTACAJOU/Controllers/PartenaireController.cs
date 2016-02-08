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
        public ActionResult CreatePartener()
        {
            return View();
        }

        //Get
        public ActionResult ModifyPartener(int ID)
        {
            PartenerToModify = new Partenaire();
            PARTENAIRE part=new PARTENAIRE();
            part.LoadId(ID);
            PartenerToModify.CONTACT = part.CONTACT;
            PartenerToModify.ID_AUTO = part.ID_AUTO;
            PartenerToModify.NOM = part.NOM;
            PartenerToModify.PRENOM = part.PRENOM;
            return View(PartenerToModify);
        }

        public ActionResult DeletePartener(int ID)
        {
            Partenaire Part  = new Partenaire();
            PARTENAIRE parts = new PARTENAIRE();
            parts.LoadId(ID);
            Part.CONTACT = parts.CONTACT;
            Part.ID_AUTO = parts.ID_AUTO;
            Part.NOM = parts.NOM;
            Part.PRENOM = parts.PRENOM;
            return View(PartenerToModify);
        }

        // GET: /Partenaire/

        public ActionResult Index()
        {
            PARTENAIRE _partenaire = new PARTENAIRE();
            List<Partenaire> _list = new List<Partenaire>(); ;
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
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreatePartener(Partenaire PartenerToCreate)
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
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }

        }
        // POST: /Partenaire/Modify
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ModifyPartener(Partenaire PartenerToModify)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                PARTENAIRE _partenaire = new PARTENAIRE();
                _partenaire.CONTACT = PartenerToModify.CONTACT;
                _partenaire.NOM = PartenerToModify.NOM;
                _partenaire.PRENOM = PartenerToModify.PRENOM;
                _partenaire.SetId(PartenerToModify.ID_AUTO);
                _partenaire.Save();
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }

        }

        // POST: /Partenaire/del
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeletePartener(Partenaire PartenerToDel)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                PARTENAIRE _partenaire = new PARTENAIRE();
                _partenaire.SetId(PartenerToDel.ID_AUTO);
                _partenaire.Delete();
                return RedirectToAction("../Home/Index");//reafficher l liste
            }
            catch
            {
                return View();
            }

        }
    }
}