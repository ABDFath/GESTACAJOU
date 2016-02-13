using GESTACAJOU.Models;
using GESTACAJOU.SQLENGINE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GESTACAJOU.Controllers
{
    public class ZoneController : Controller
    {
        //
        // GET: /Zone/

        public ActionResult Index()
        {
            ZONE _zone = new ZONE();
            List<Zone> _list = new List<Zone>(); ;
            foreach (ZONE item in ZONE.GetList())
            {
                Zone zones = new Zone();
                zones.NOM = item.NOM;
                zones.CONTROLEUR = item.CONTROLEUR;
                zones.ID_CONT = item.ID_CONTROLER;
                zones.ID_AUTO = item.ID_AUTO;
                _list.Add(zones);
            }

            return View(_list);
        }

        public static IEnumerable<SelectListItem> ToSelectListItems()
        {
            IList<SelectListItem> results = new List<SelectListItem>();
            foreach (SYS_UTILISATEUR item in SYS_UTILISATEUR.GetList_CONTROLEURS())
            {
                results.Add(new SelectListItem { Text = item.NOM, Value = item.ID_AUTO.ToString() });
            }
            return results;
        }
       
   
        //
        // GET: /Zone/Create

        public ActionResult Create()
        {
            ViewData["ID_CONT"] = ToSelectListItems();
            return View();
        } 

        //
        // POST: /Zone/Create

        [HttpPost]
        public ActionResult Create(Zone zonesToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                ZONE _zone = new ZONE();
                _zone.NOM = zonesToCreate.NOM;
                _zone.ID_CONTROLER = zonesToCreate.ID_CONT;
                _zone.Save();
                return RedirectToAction("../Zone/Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Zone/Edit/5
 
        public ActionResult Edit()
        {
            Zone zones = new Zone();
            ZONE _zone = new ZONE();

            int id = Int32.Parse(RouteData.Values["id"].ToString());

            _zone.LoadId(id);
            zones.NOM = _zone.NOM;
            zones.CONTROLEUR = _zone.CONTROLEUR;

            IEnumerable<SelectListItem> list = ToSelectListItems();
            list.ToList().Find(x => x.Text.Equals(zones.CONTROLEUR)).Selected = true;
           ViewData["ID_CONT"] = list;

            return View(zones);
        }

        //
        // POST: /Zone/Edit/5

        [HttpPost]
        public ActionResult Edit(Zone zones)
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());

            if (!ModelState.IsValid)
                return View();

            try
            {
                ZONE _zone = new ZONE();
                _zone.NOM = zones.NOM;
                _zone.CONTROLEUR = zones.CONTROLEUR;
                _zone.ID_CONTROLER = zones.ID_CONT;
                _zone.SetId(id);
                _zone.Save();
                return RedirectToAction("../Zone/Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Zone/Delete/5
 
        public ActionResult Delete()
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());
          
            Zone zones = new Zone();
            ZONE _zone = new ZONE();
            _zone.LoadId(id);
            zones.NOM = _zone.NOM;
            zones.ID_AUTO = _zone.ID_AUTO;
            zones.CONTROLEUR = _zone.CONTROLEUR;
            IEnumerable<SelectListItem> list = ToSelectListItems();
            list.ToList().Find(x => x.Text.Equals(zones.CONTROLEUR)).Selected = true;
            ViewData["ID_CONT"] = list;
            return View(zones);
        }

        //
        // POST: /Zone/Delete/5

        [HttpPost]
        public ActionResult Delete(Zone zones)
        {
            int id = Int32.Parse(RouteData.Values["id"].ToString());
          
            if (!ModelState.IsValid)
                return View();

            try
            {
                ZONE _zone = new ZONE();
                _zone.SetId(id);
                _zone.Delete();
                return RedirectToAction("../Zone/Index");//reafficher l liste
            }
            catch
            {
                return View();
            }
        }
    }
}
