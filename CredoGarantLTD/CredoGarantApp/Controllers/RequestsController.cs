using CredoGarantApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CredoGarantApp.Controllers
{
    public class RequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Requests - List all the records
        public ActionResult Requests()
        {
            return View(db.Requests.ToList());
        }
        // Create - Create a new record
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId, RequestingFirmName, LoadingAddress, LoadingDateTime, UnloadingAdress, UnloadingDateTime, EmailOfContact, PhoneOfContact")]Request requests)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(requests);
                db.SaveChanges();
                return RedirectToAction("Requests", "Requests");
            }
            return View("Requests", "Requests");
        }

        // Update - Edit and update a record

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if(request == null)
            {
                return HttpNotFound();
            }

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId, RequestingFirmName, LoadingAddress, LoadingDateTime, UnloadingAdress, UnloadingDateTime, EmailOfContact, PhoneOfContact")]Request requests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Requests", "Requests");
            }
            return View(requests);
        }

        // Delete - Delete a record

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }

            return View(request);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request requests = db.Requests.Find(id);
            db.Requests.Remove(requests);
            db.SaveChanges();
            return RedirectToAction("Requests", "Requests");
        }

        // Dispose - Disposing of unwanted memory objects after performing any of the above actions

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);

        }

    }
}