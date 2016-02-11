using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GESTACAJOU.Models;
using GESTACAJOU.Models.Business;
using GESTACAJOU.SQLENGINE;

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
            List<ZONE> _listPist = ZONE.GetList();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Selectionner...", Value = "0" });
            foreach (ZONE item in _listPist)
            {
                li.Add(new SelectListItem { Text = item.NOM, Value = item.ID_AUTO.ToString() });
            }

            ViewData["ID_ZONE"] = li;
           
           
        }

        public ActionResult Ajout(string id)
        {
            try
            {
                Session["ID"] = null;
                InitAjoutView();
                ViewBag.IsCompleted = false;
                PisteurModel pist = new PisteurModel();
                if (!string.IsNullOrEmpty(id))
                {
                    int _id = Convert.ToInt32(id);
                    pist = DbFactory.FindPisteur(_id);
                    Session["ID"] = pist.ID_AUTO;
                }
                pist.GetList();
                return View(pist);
            }
            catch (Exception ex)
            {
              string message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += ex.InnerException.Message;
                }
                message += ex.StackTrace;
                message += ex.GetType().ToString();
                Session["ErrorHandle"] = message;
                return Redirect("Account/GeneralFailure");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ajout(PisteurModel _pisteur, string returnUrl)
        {
            //if (Session["UserConnected"] == null) return Redirect("/LoginSk/_loginSkinned");
            PisteurModel pisteur;

            try
            {
                
                if (ModelState.IsValid)
                {
                    if (Session["ID"] != null) _pisteur.ID_AUTO = (int)Session["ID"];
                    //string userName = WebSecurity.CurrentUserName;
                    DbFactory.SavePisteur(_pisteur);
                    ViewBag.IsCompleted = true;
                    InitAjoutView();
                    ViewBag.IsCompleted = true;
                    ModelState.Clear();
                    pisteur = new PisteurModel();
                    pisteur.GetList();
                    return View(pisteur);
                }
                else
                {
                    InitAjoutView();
                    _pisteur.GetList();
                    return View(_pisteur);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += ex.InnerException.Message;
                }
                message += ex.StackTrace;
                message += ex.GetType().ToString();
                Session["ErrorHandle"] = message;
                return Redirect("/LoginSk/GeneralFailure");
            }


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
