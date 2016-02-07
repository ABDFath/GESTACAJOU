using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GESTACAJOU.Models;

namespace GESTACAJOU.Controllers
{
    public class PisteurController : Controller
    {
        //
        // GET: /Pisteur/

        public ActionResult Index()
        {
            return View();
        }

        private void InitAjoutView()
        {
            //List<> _listDept = DbFactory.GetListDepartement();
            //List<SelectListItem> li = new List<SelectListItem>();
            //li.Add(new SelectListItem { Text = "Selectionner...", Value = "0" });
            //foreach (DepartementModel item in _listDept)
            //{
            //    li.Add(new SelectListItem { Text = item.NAME_D, Value = item.ID.ToString() });
            //}

            ViewData["ID_ZONE"] = new List<SelectListItem>();
           
           
        }

        public ActionResult Ajout()
        {
            PisteurModel pist = new PisteurModel();
            pist.GetList();
            InitAjoutView();
            return View(pist);
        }

        //
        // GET: /Pisteur/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Pisteur/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Pisteur/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Pisteur/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pisteur/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pisteur/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Pisteur/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
