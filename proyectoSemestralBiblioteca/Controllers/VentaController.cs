﻿using System;
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
    public class VentaController : Controller
    {
        private bibliotecaEntites db = new bibliotecaEntites();

        // GET: Venta
        public ActionResult Index()
        {
            var venta = db.Venta.Include(v => v.AspNetUsers).Include(v => v.Libro);
            return View(venta.ToList());
        }

        // GET: Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.idLibro = new SelectList(db.Libro, "idLibro", "tituloLibro");
            return View();
        }

        // POST: Venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVenta,idLibro,fechaVenta,idUsuario,totalVenta")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.AspNetUsers, "Id", "Email", venta.idUsuario);
            ViewBag.idLibro = new SelectList(db.Libro, "idLibro", "tituloLibro", venta.idLibro);
            return View(venta);
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.AspNetUsers, "Id", "Email", venta.idUsuario);
            ViewBag.idLibro = new SelectList(db.Libro, "idLibro", "tituloLibro", venta.idLibro);
            return View(venta);
        }

        // POST: Venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVenta,idLibro,fechaVenta,idUsuario,totalVenta")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.AspNetUsers, "Id", "Email", venta.idUsuario);
            ViewBag.idLibro = new SelectList(db.Libro, "idLibro", "tituloLibro", venta.idLibro);
            return View(venta);
        }

        // GET: Venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Venta.Find(id);
            db.Venta.Remove(venta);
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
