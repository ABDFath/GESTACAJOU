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
        int id = 0;
        //
        // GET: /Vente/
        List<Vente> _list;
        public ActionResult IndexVente()
        {
            VENTE _vente = new VENTE();
            _list = new List<Vente>(); ;
            foreach (VENTE item in VENTE.GetList())
            {
                Vente ventes = new Vente();
                ventes.DATE_OPERATION = item.DATE_OPERATION;
                ventes.ID_PARTENAIRE = item.ID_PARTENAIRE;
                ventes.MONTANT_TOTAL= item.MONTANT_TOTAL;
                ventes.PARTENAIRE = item.PARTENAIRE;
                ventes.QTE_TOTAL = item.QTE_TOTAL;
                ventes.ID_AUTO = item.ID_AUTO;
                _list.Add(ventes);
            }

            return View(_list);
        }

        public static IEnumerable<SelectListItem> ToSelectListItems()
        {
            IList<SelectListItem> results = new List<SelectListItem>();
            foreach (PARTENAIRE item in PARTENAIRE.GetList())
            {
                results.Add(new SelectListItem { Text = item.ToString(), Value = item.ID_AUTO.ToString()});
            }
            return results;
        }
       
        //
        // GET: /Vente/Create

        public ActionResult Create()
        {
            ViewData["ID_PARTENAIRE"] = ToSelectListItems();
            //Vente ventes = new Vente();
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
                return RedirectToAction("../Vente/IndexVente");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Vente/Edit/5
 
        public ActionResult Edit()
        {
            
            int id = Int32.Parse(RouteData.Values["id"].ToString());
            Vente ventes = new Vente();
            VENTE _vente = new VENTE();
            _vente.LoadId(id);
            ventes.DATE_OPERATION = _vente.DATE_OPERATION;
            ventes.ID_PARTENAIRE = _vente.ID_PARTENAIRE;
            ventes.MONTANT_TOTAL = _vente.MONTANT_TOTAL;
            ventes.PARTENAIRE=_vente.PARTENAIRE;
            ventes.QTE_TOTAL = _vente.QTE_TOTAL;
            ventes.ID_AUTO = _vente.ID_AUTO;

            IEnumerable<SelectListItem> list = ToSelectListItems();
            list.ToList().Find(x => x.Text.Equals(ventes.PARTENAIRE)).Selected = true;
            ViewData["ID_PARTENAIRE"] = list;

            return View(ventes);
        }

        //
        // POST: /Vente/Edit/5

        [HttpPost]
        public ActionResult Edit(Vente ventes)
        {
            id = Int32.Parse(RouteData.Values["id"].ToString());

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
                _vente.SetId(id);
                _vente.Save();
                return RedirectToAction("../Vente/IndexVente");
            }
            catch
            {
                return View();
            }

        }

        
        // GET: /Vente/Delete/5
 
        public ActionResult Delete()
        {
            
            id = Int32.Parse(RouteData.Values["id"].ToString());
          
            Vente ventes = new Vente();
            VENTE _vente = new VENTE();
            _vente.LoadId(id);
            ventes.DATE_OPERATION = _vente.DATE_OPERATION;
            ventes.ID_PARTENAIRE = _vente.ID_PARTENAIRE;
            ventes.MONTANT_TOTAL = _vente.MONTANT_TOTAL;
            ventes.PARTENAIRE=_vente.PARTENAIRE;
            ventes.QTE_TOTAL = _vente.QTE_TOTAL;
            ventes.ID_AUTO= _vente.ID_AUTO;

            IEnumerable<SelectListItem> list= ToSelectListItems();
            list.ToList().Find(x => x.Text.Equals(ventes.PARTENAIRE)).Selected=true;
            ViewData["ID_PARTENAIRE"] = list;

            return View(ventes);
        }

        //
        // POST: /Vente/Delete/5

        [HttpPost]
        public ActionResult Delete(Vente VenteToDel)
        {
            id = Int32.Parse(RouteData.Values["id"].ToString());

            if (!ModelState.IsValid)
                return View();

            try
            {
                VENTE _vente = new VENTE();
                _vente.SetId(id);
                _vente.Delete();
                return RedirectToAction("../Vente/IndexVente");//reafficher l liste
            }
            catch
            {
                return View();
            }
        }
    }
}
