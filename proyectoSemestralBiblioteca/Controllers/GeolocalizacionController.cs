using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyectoSemestralBiblioteca.Models;

namespace proyectoSemestralBiblioteca.Controllers
{
    public class GeolocalizacionController : Controller
    {
        private bibliotecaEntites db = new bibliotecaEntites();

        // GET: Geolocalizacion
        public ActionResult Index()
        {
            return View(db.Geolocalizacion.ToList());
        }
        [HttpPost]
        public ActionResult Search(string Location)
        {

            var result = db.Geolocalizacion.Where(x => x.nombreLocalizacion.StartsWith(Location)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Geolocalizacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Geolocalizacion geolocalizacion = db.Geolocalizacion.Find(id);
            if (geolocalizacion == null)
            {
                return HttpNotFound();
            }
            return View(geolocalizacion);
        }

        // GET: Geolocalizacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Geolocalizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLocalizacion,nombreLocalizacion,latitudLocalizacion,longitudLocalizacion")] Geolocalizacion geolocalizacion)
        {
            if (ModelState.IsValid)
            {
                db.Geolocalizacion.Add(geolocalizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(geolocalizacion);
        }

        // GET: Geolocalizacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Geolocalizacion geolocalizacion = db.Geolocalizacion.Find(id);
            if (geolocalizacion == null)
            {
                return HttpNotFound();
            }
            return View(geolocalizacion);
        }

        // POST: Geolocalizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLocalizacion,nombreLocalizacion,latitudLocalizacion,longitudLocalizacion")] Geolocalizacion geolocalizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geolocalizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(geolocalizacion);
        }

        // GET: Geolocalizacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Geolocalizacion geolocalizacion = db.Geolocalizacion.Find(id);
            if (geolocalizacion == null)
            {
                return HttpNotFound();
            }
            return View(geolocalizacion);
        }

        // POST: Geolocalizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Geolocalizacion geolocalizacion = db.Geolocalizacion.Find(id);
            db.Geolocalizacion.Remove(geolocalizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
