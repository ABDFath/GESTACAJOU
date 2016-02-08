using GESTACAJOU.Models;
using GESTACAJOU.SQLENGINE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GESTACAJOU.Controllers
{
    public class VenteDetailsController : Controller
    {
        //
        // GET: /VenteDetails/

        public ActionResult Index(int idVente, int idChargement)
        {
            VENTE_DETAILS _venteDetails = new VENTE_DETAILS();

            List<Vente_Details> _list = new List<Vente_Details>(); ;
            foreach (VENTE_DETAILS item in VENTE_DETAILS.GetListByVente(idVente,idChargement))
            {
                Vente_Details ventesDetails = new Vente_Details();
                ventesDetails.CHARGEMENT = item.CHARGERMENT;
                ventesDetails.ID_AUTO = item.ID_AUTO;
                ventesDetails.ID_CHARGEMENT = item.ID_CHARGEMENT;
                ventesDetails.ID_VENTE = item.ID_VENTE;
                ventesDetails.PRIX_UNITAIRE= item.PRIX_UNITAIRE;
                ventesDetails.QTE = item.QTE;
                ventesDetails.TOTAL = item.TOTAL;
                _list.Add(ventesDetails);
            }

            return View(_list);
        }

      
        //
        // GET: /VenteDetails/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /VenteDetails/Create

        [HttpPost]
        public ActionResult Create(Vente_Details VenteDetailsToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                VENTE_DETAILS _venteDetails = new VENTE_DETAILS();
                _venteDetails.ID_CHARGEMENT = VenteDetailsToCreate.ID_CHARGEMENT;
                _venteDetails.ID_VENTE = VenteDetailsToCreate.ID_VENTE;
                _venteDetails.PRIX_UNITAIRE = VenteDetailsToCreate.PRIX_UNITAIRE;
                _venteDetails.QTE = VenteDetailsToCreate.QTE;
                _venteDetails.TOTAL = VenteDetailsToCreate.TOTAL;
               
                _venteDetails.Save();
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /VenteDetails/Edit/5
 
        public ActionResult Edit(int id)
        {
            Vente_Details ventesDetails = new Vente_Details();
            VENTE_DETAILS _venteDetails = new VENTE_DETAILS();
            _venteDetails.LoadId(id);
            ventesDetails.ID_CHARGEMENT = _venteDetails.ID_CHARGEMENT;
            ventesDetails.ID_VENTE = _venteDetails.ID_VENTE;
            ventesDetails.PRIX_UNITAIRE = _venteDetails.PRIX_UNITAIRE;
            ventesDetails.QTE = _venteDetails.QTE;
            ventesDetails.TOTAL = _venteDetails.TOTAL;
            return View(ventesDetails);
        }

        //
        // POST: /VenteDetails/Edit/5

        [HttpPost]
        public ActionResult Edit(Vente_Details ventesDetails)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                VENTE_DETAILS _venteDetails = new VENTE_DETAILS();
                _venteDetails.TOTAL = ventesDetails.TOTAL;
                _venteDetails.PRIX_UNITAIRE = ventesDetails.PRIX_UNITAIRE;
                _venteDetails.QTE = ventesDetails.QTE;
                _venteDetails.ID_VENTE = ventesDetails.ID_VENTE;
                _venteDetails.ID_CHARGEMENT = ventesDetails.ID_CHARGEMENT;
                _venteDetails.SetId(ventesDetails.ID_AUTO);
                _venteDetails.Save();
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }

        }

        //
        // GET: /VenteDetails/Delete/5
 
        public ActionResult Delete(int id)
        {
            Vente_Details ventesDetails = new Vente_Details();
            VENTE_DETAILS _venteDetails = new VENTE_DETAILS();
            _venteDetails.LoadId(id);
            ventesDetails.TOTAL = _venteDetails.TOTAL;
            ventesDetails.QTE = _venteDetails.QTE;
            ventesDetails.PRIX_UNITAIRE = _venteDetails.PRIX_UNITAIRE;
            ventesDetails.ID_VENTE = _venteDetails.ID_VENTE;
            ventesDetails.ID_CHARGEMENT = _venteDetails.ID_CHARGEMENT;
            return View(ventesDetails);
        }

        //
        // POST: /VenteDetails/Delete/5

        [HttpPost]
        public ActionResult Delete(Vente_Details VenteDetailsToDel)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                VENTE_DETAILS _venteDetails = new VENTE_DETAILS();
                _venteDetails.SetId(VenteDetailsToDel.ID_AUTO);
                _venteDetails.Delete();
                return RedirectToAction("../Home/Index");//reafficher l liste
            }
            catch
            {
                return View();
            }
        }
    }
}
