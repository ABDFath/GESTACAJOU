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

        public ActionResult Index()
        {
            VENTE_DETAILS _venteDetails = new VENTE_DETAILS();

            List<Vente_Details> _list = new List<Vente_Details>(); ;
            foreach (VENTE_DETAILS item in VENTE_DETAILS.GetList())
            {
                Vente_Details ventesDetails = new Vente_Details();
                
                ventesDetails.ID_AUTO = item.ID_AUTO;
                ventesDetails.ID_CHARGEMENT = item.ID_CHARGEMENT;
                ventesDetails.ID_VENTE = item.ID_VENTE;

                VENTE vente = new VENTE();
                vente.LoadId(item.ID_VENTE);

                ventesDetails.VENTE = vente.ToString();

                CHARGERMENT charge = new CHARGERMENT();
                charge.LoadId(item.ID_CHARGEMENT);

                ventesDetails.CHARGEMENT = charge.ToString();

                ventesDetails.PRIX_UNITAIRE= item.PRIX_UNITAIRE;
                ventesDetails.QTE = item.QTE;
                ventesDetails.TOTAL = item.TOTAL;
                _list.Add(ventesDetails);
            }

            return View(_list);
        }

      
        
        public static IEnumerable<SelectListItem> ToSelectListItems()
        {
            IList<SelectListItem> results = new List<SelectListItem>();
            foreach (VENTE item in VENTE.GetList())
            {
                results.Add(new SelectListItem { Text = item.ToString(), Value = item.ID_AUTO.ToString() });
            }
            return results;
        }

        public static IEnumerable<SelectListItem> ToSelectListItems1()
        {
            IList<SelectListItem> results = new List<SelectListItem>();
            foreach (CHARGERMENT item in CHARGERMENT.GetList())
            {
                results.Add(new SelectListItem { Text = item.ToString(), Value = item.ID_AUTO.ToString() });
            }
            return results;
        }

        //
        // GET: /VenteDetails/Create

        public ActionResult Create()
        {
            ViewData["ID_VENTE"] = ToSelectListItems();
            ViewData["ID_CHARGEMENT"] = ToSelectListItems1();
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
                return RedirectToAction("../VenteDetails/Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /VenteDetails/Edit/5
 
        public ActionResult Edit()
        {
            Vente_Details ventesDetails = new Vente_Details();
            VENTE_DETAILS _venteDetails = new VENTE_DETAILS();

            int id = Int32.Parse(RouteData.Values["id"].ToString());

            _venteDetails.LoadId(id);

            ventesDetails.ID_CHARGEMENT = _venteDetails.ID_CHARGEMENT;
            ventesDetails.ID_VENTE = _venteDetails.ID_VENTE;
            ventesDetails.PRIX_UNITAIRE = _venteDetails.PRIX_UNITAIRE;
            ventesDetails.QTE = _venteDetails.QTE;
            ventesDetails.TOTAL = _venteDetails.TOTAL;
            ventesDetails.ID_AUTO = _venteDetails.ID_AUTO;

            VENTE vente = new VENTE();
            vente.LoadId(_venteDetails.ID_VENTE);

            ventesDetails.VENTE = vente.ToString();

            CHARGERMENT charge = new CHARGERMENT();
            charge.LoadId(_venteDetails.ID_CHARGEMENT);

            ventesDetails.CHARGEMENT = charge.ToString();


            IEnumerable<SelectListItem> list = ToSelectListItems();
            list.ToList().Find(x => x.Text.Equals(ventesDetails.VENTE)).Selected = true;
            ViewData["ID_VENTE"] = list;

            IEnumerable<SelectListItem> list1 = ToSelectListItems1();
            list1.ToList().Find(x => x.Text.Equals(ventesDetails.CHARGEMENT)).Selected = true;
            ViewData["ID_CHARGEMENT"] = list1;
            return View(ventesDetails);
        }

        //
        // POST: /VenteDetails/Edit/5

        [HttpPost]
        public ActionResult Edit(Vente_Details ventesDetails)
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());

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
                _venteDetails.SetId(id);
                _venteDetails.Save();
                return RedirectToAction("../VenteDetails/Index");
            }
            catch
            {
                return View();
            }

        }

        //
        // GET: /VenteDetails/Delete/5
 
        public ActionResult Delete()
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());
          
            Vente_Details ventesDetails = new Vente_Details();
            VENTE_DETAILS _venteDetails = new VENTE_DETAILS();
            _venteDetails.LoadId(id);
            ventesDetails.TOTAL = _venteDetails.TOTAL;
            ventesDetails.QTE = _venteDetails.QTE;
            ventesDetails.PRIX_UNITAIRE = _venteDetails.PRIX_UNITAIRE;
            ventesDetails.ID_VENTE = _venteDetails.ID_VENTE;
            ventesDetails.ID_CHARGEMENT = _venteDetails.ID_CHARGEMENT;

            VENTE vente = new VENTE();
            vente.LoadId(_venteDetails.ID_VENTE);

            ventesDetails.VENTE = vente.ToString();

            CHARGERMENT charge = new CHARGERMENT();
            charge.LoadId(_venteDetails.ID_CHARGEMENT);

            ventesDetails.CHARGEMENT = charge.ToString();


            IEnumerable<SelectListItem> list = ToSelectListItems();
            list.ToList().Find(x => x.Text.Equals(ventesDetails.VENTE)).Selected = true;
            ViewData["ID_VENTE"] = list;

            IEnumerable<SelectListItem> list1 = ToSelectListItems1();
            list1.ToList().Find(x => x.Text.Equals(ventesDetails.CHARGEMENT)).Selected = true;
            ViewData["ID_CHARGEMENT"] = list1;

            return View(ventesDetails);
        }

        //
        // POST: /VenteDetails/Delete/5

        [HttpPost]
        public ActionResult Delete(Vente_Details VenteDetailsToDel)
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());

            if (!ModelState.IsValid)
                return View();

            try
            {
                VENTE_DETAILS _venteDetails = new VENTE_DETAILS();
                _venteDetails.SetId(id);
                _venteDetails.Delete();
                return RedirectToAction("../VenteDetails/Index");//reafficher l liste
            }
            catch
            {
                return View();
            }
        }
    }
}
