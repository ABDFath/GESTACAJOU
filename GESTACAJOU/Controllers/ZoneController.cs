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
                _list.Add(zones);
            }

            return View(_list);
        }

   
        //
        // GET: /Zone/Create

        public ActionResult Create()
        {
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
                _zone.CONTROLEUR = zonesToCreate.CONTROLEUR;
                _zone.Save();
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Zone/Edit/5
 
        public ActionResult Edit(int id)
        {
            Zone zones = new Zone();
            ZONE _zone = new ZONE();
            _zone.LoadId(id);
            zones.NOM = _zone.NOM;
            zones.CONTROLEUR = _zone.CONTROLEUR;
            return View(zones);
        }

        //
        // POST: /Zone/Edit/5

        [HttpPost]
        public ActionResult Edit(Zone zones)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                ZONE _zone = new ZONE();
                _zone.NOM = zones.NOM;
                _zone.CONTROLEUR = zones.CONTROLEUR;
                _zone.SetId(zones.ID_AUTO);
                _zone.Save();
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Zone/Delete/5
 
        public ActionResult Delete(int id)
        {
            Zone zones = new Zone();
            ZONE _zone = new ZONE();
            _zone.LoadId(id);
            zones.NOM = _zone.NOM;
            zones.ID_AUTO = _zone.ID_AUTO;
            return View(zones);
        }

        //
        // POST: /Zone/Delete/5

        [HttpPost]
        public ActionResult Delete(Zone zones)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                ZONE _zone = new ZONE();
                _zone.SetId(zones.ID_AUTO);
                _zone.Delete();
                return RedirectToAction("../Home/Index");//reafficher l liste
            }
            catch
            {
                return View();
            }
        }
    }
}
