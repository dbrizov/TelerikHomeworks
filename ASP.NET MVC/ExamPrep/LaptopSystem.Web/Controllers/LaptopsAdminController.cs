using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LaptopSystem.Models;

namespace LaptopSystem.Web.Controllers
{
    public class LaptopsAdminController : AdminController
    {
        // GET: /LaptopsAdmin/
        public ActionResult Index()
        {
            var laptops = this.data.Laptops.All().Include(l => l.Manufacturer);
            return View(laptops.ToList());
        }

        // GET: /LaptopsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = this.data.Laptops.GetById(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // GET: /LaptopsAdmin/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(this.data.Manufacturers.All(), "Id", "Name");
            return View();
        }

        // POST: /LaptopsAdmin/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                this.data.Laptops.Add(laptop);
                this.data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(this.data.Manufacturers.All(), "Id", "Name", laptop.ManufacturerId);
            return View(laptop);
        }

        // GET: /LaptopsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = this.data.Laptops.GetById(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(this.data.Manufacturers.All(), "Id", "Name", laptop.ManufacturerId);
            return View(laptop);
        }

        // POST: /LaptopsAdmin/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                this.data.Laptops.Update(laptop);
                this.data.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerId = new SelectList(this.data.Manufacturers.All(), "Id", "Name", laptop.ManufacturerId);
            return View(laptop);
        }

        // GET: /LaptopsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = this.data.Laptops.GetById(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: /LaptopsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int id)
        {
            Laptop laptop = this.data.Laptops.GetById(id);
            this.data.Laptops.Delete(laptop);
            this.data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.data.Dispose();
            base.Dispose(disposing);
        }
    }
}
