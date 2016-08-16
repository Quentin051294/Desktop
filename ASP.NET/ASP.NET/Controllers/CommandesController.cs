using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET.Models;

namespace ASP.NET.Controllers
{
    public class CommandesController : Controller
    {
        private masterEntities4 db = new masterEntities4();

        // GET: Commandes
        public ActionResult Index()
        {
            var commande = db.Commande.Include(c => c.Client).Include(c => c.Materiau);
            return View(commande.ToList());
        }

        // GET: Commandes/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commande.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // GET: Commandes/Create
        public ActionResult Create()
        {
            Commande com = new Commande();
            DateTime date = DateTime.Now;
            long i = date.Second + date.Minute * 100 + date.Hour * 10000 + date.Day * 1000000 + date.Month * 100000000 + date.Year * 10000000000;
            com.idCommande = i;
            ViewBag.numeroIdentification = new SelectList(db.Client, "numeroIdentification", "nom");
            ViewBag.codeIdentification = new SelectList(db.Materiau, "codeIdentification", "libelleFrancais");
            return View(com);
        }

        // POST: Commandes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCommande,quantiteDemandee,codeIdentification,numeroIdentification")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                db.Commande.Add(commande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numeroIdentification = new SelectList(db.Client, "numeroIdentification", "nom", commande.numeroIdentification);
            ViewBag.codeIdentification = new SelectList(db.Materiau, "codeIdentification", "libelleFrancais", commande.codeIdentification);
            return View(commande);
        }

        // GET: Commandes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commande.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            ViewBag.numeroIdentification = new SelectList(db.Client, "numeroIdentification", "nom", commande.numeroIdentification);
            ViewBag.codeIdentification = new SelectList(db.Materiau, "codeIdentification", "libelleFrancais", commande.codeIdentification);
            return View(commande);
        }

        // POST: Commandes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCommande,quantiteDemandee,codeIdentification,numeroIdentification")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numeroIdentification = new SelectList(db.Client, "numeroIdentification", "nom", commande.numeroIdentification);
            ViewBag.codeIdentification = new SelectList(db.Materiau, "codeIdentification", "libelleFrancais", commande.codeIdentification);
            return View(commande);
        }

        // GET: Commandes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commande.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Commande commande = db.Commande.Find(id);
            db.Commande.Remove(commande);
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
