using GESTACAJOU.Models;
using GESTACAJOU.SQLENGINE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GESTACAJOU.Controllers
{
    public class VenteController : Controller
    {
        //
        // GET: /Vente/

        public ActionResult Index()
        {
            VENTE _vente = new VENTE();
            List<Vente> _list = new List<Vente>(); ;
            foreach (VENTE item in VENTE.GetList())
            {
                Vente ventes = new Vente();
                ventes.DATE_OPERATION = item.DATE_OPERATION;
                ventes.ID_PARTENAIRE = item.ID_PARTENAIRE;
                ventes.MONTANT_TOTAL= item.MONTANT_TOTAL;
                ventes.PARTENAIRE = item.PARTENAIRE;
                ventes.QTE_TOTAL = item.QTE_TOTAL;
                _list.Add(ventes);
            }

            return View(_list);
        }

       
        //
        // GET: /Vente/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Vente/Create

        [HttpPost]
        public ActionResult Create(Vente VenteToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                VENTE _vente = new VENTE();
                _vente.DATE_OPERATION = VenteToCreate.DATE_OPERATION;
                _vente.ID_PARTENAIRE = VenteToCreate.ID_PARTENAIRE;
                _vente.MONTANT_TOTAL = VenteToCreate.MONTANT_TOTAL;
                _vente.SetPARTENAIRE(VenteToCreate.PARTENAIRE);
                _vente.QTE_TOTAL = VenteToCreate.QTE_TOTAL;
                _vente.Save();
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Vente/Edit/5
 
        public ActionResult Edit(int id)
        {
            Vente ventes = new Vente();
            VENTE _vente = new VENTE();
            _vente.LoadId(id);
            ventes.DATE_OPERATION = _vente.DATE_OPERATION;
            ventes.ID_PARTENAIRE = _vente.ID_PARTENAIRE;
            ventes.MONTANT_TOTAL = _vente.MONTANT_TOTAL;
            ventes.PARTENAIRE=_vente.PARTENAIRE;
            ventes.QTE_TOTAL = _vente.QTE_TOTAL;
            return View(ventes);
        }

        //
        // POST: /Vente/Edit/5

        [HttpPost]
        public ActionResult Edit(Vente ventes)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                VENTE _vente = new VENTE();
                _vente.DATE_OPERATION = ventes.DATE_OPERATION;
                _vente.ID_PARTENAIRE = ventes.ID_PARTENAIRE;
                _vente.MONTANT_TOTAL = ventes.MONTANT_TOTAL;
                _vente.SetPARTENAIRE(ventes.PARTENAIRE);
                _vente.QTE_TOTAL = ventes.QTE_TOTAL;
                _vente.SetId(ventes.ID_AUTO);
                _vente.Save();
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }

        }

        //
        // GET: /Vente/Delete/5
 
        public ActionResult Delete(int id)
        {
            Vente ventes = new Vente();
            VENTE _vente = new VENTE();
            _vente.LoadId(id);
            ventes.DATE_OPERATION = _vente.DATE_OPERATION;
            ventes.ID_PARTENAIRE = _vente.ID_PARTENAIRE;
            ventes.MONTANT_TOTAL = _vente.MONTANT_TOTAL;
            ventes.PARTENAIRE=_vente.PARTENAIRE;
            ventes.QTE_TOTAL = _vente.QTE_TOTAL;
            return View(ventes);
        }

        //
        // POST: /Vente/Delete/5

        [HttpPost]
        public ActionResult Delete(Vente VenteToDel)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                VENTE _vente = new VENTE();
                _vente.SetId(VenteToDel.ID_AUTO);
                _vente.Delete();
                return RedirectToAction("../Home/Index");//reafficher l liste
            }
            catch
            {
                return View();
            }
        }
    }
}
