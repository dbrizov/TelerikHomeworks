using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AspNetMvcExam.Models;

namespace AspNetMvcExam.Web.Controllers
{
    public class CommentsAdminController : AdminController
    {
        public CommentsAdminController()
            : base()
        {
        }

        // GET: /CommentsAdmin/
        public ActionResult Index()
        {
            var comments = this.data.Comments.All().Include(c => c.Ticket).Include(c => c.User);
            return View(comments.ToList());
        }

        // GET: /CommentsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.data.Comments.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: /CommentsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.data.Comments.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            ViewBag.TicketId = new SelectList(this.data.Tickets.All(), "Id", "AuthorId", comment.TicketId);
            ViewBag.UserId = new SelectList(this.data.Users.All(), "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // POST: /CommentsAdmin/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                this.data.Comments.Update(comment);
                this.data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketId = new SelectList(this.data.Tickets.All(), "Id", "AuthorId", comment.TicketId);
            ViewBag.UserId = new SelectList(this.data.Users.All(), "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: /CommentsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.data.Comments.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /CommentsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = this.data.Comments.GetById(id);
            this.data.Comments.Delete(comment);
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
