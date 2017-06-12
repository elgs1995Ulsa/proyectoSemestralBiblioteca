using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace proyectoSemestralBiblioteca.Controllers
{
    public class LocalizacionController : Controller
    {
        private Models.bibliotecaEntites db = new Models.bibliotecaEntites();

        // GET: Localizacion
        public ActionResult Index()
        {
            return View(db.Geolocalizacion.ToList());

        }

        public ActionResult Search(string Location)
        {

            var result = db.Geolocalizacion.Where(x => x.nombreLocalizacion.Contains(Location)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Localizacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Localizacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Localizacion/Create
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

        // GET: Localizacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Localizacion/Edit/5
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

        // GET: Localizacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Localizacion/Delete/5
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
