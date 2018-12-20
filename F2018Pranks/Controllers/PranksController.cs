using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using F2018Pranks.Models;

namespace F2018Pranks.Controllers
{
    public class PranksController : Controller
    {
        //private DbModel db = new DbModel();
        private IMockPrank db;

        private PranksController()
        {
            this.db = new EFPrank();
        }

        private PranksController(IMockPrank db)
        {
            this.db = db;
        }

        // GET: Pranks
        private ActionResult Index()
        {
            return View(db.Pranks.ToList());
        }

        // GET: Pranks/Details/5
        private ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(503, string.Format("Details id cannot be null"));
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prank prank = db.Pranks.Find(id);
            if (prank == null)
            {
                return HttpNotFound();
            }
            return View(prank);
        }

        // GET: Pranks/Create
        private ActionResult Create()
        {
            return View();
        }

        // POST: Pranks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        private ActionResult Create([Bind(Include = "PrankId,Name,Description,Photo")] Prank prank)
        {
            if (ModelState.IsValid)
            {
                db.Pranks.Add(prank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prank);
        }
    }
}
