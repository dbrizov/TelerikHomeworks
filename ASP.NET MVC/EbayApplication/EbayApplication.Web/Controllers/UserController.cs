namespace EbayApplication.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using EbayApplication.Repositories;
    using EbayApplication.Web.Models.UserModels;
    using EbayApplication.Models;

    public class UserController : Controller
    {
        private readonly IUnitOfWorkData db;

        public UserController()
        {
            this.db = new UnitOfWorkData();
        }

        public UserController(IUnitOfWorkData db)
        {
            this.db = db;
        }
       

        // GET: /User/
        public ActionResult Index()
        {
            return View(db.Users.All().Select(UserViewModel.FromUser).ToList());
        }

        //// GET: /User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userviewmodel = UserViewModel.CreateFromUser(db.Users.GetById(id));
            if (userviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(userviewmodel);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(UserViewModel.CreateFromViewModel(userviewmodel));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userviewmodel);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userviewmodel = UserViewModel.CreateFromUser(db.Users.GetById(id));
            if (userviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(userviewmodel);
        }

        // POST: /User/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(userviewmodel).State = EntityState.Modified;
                var user = UserViewModel.CreateFromViewModel(userviewmodel);
                this.db.Users.Update(user);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userviewmodel);
        }

        //// GET: /User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userviewmodel =UserViewModel.CreateFromUser( db.Users.GetById(id));
            if (userviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(userviewmodel);
        }

        //// POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser userviewmodel = db.Users.GetById(id);
            db.Users.Delete(userviewmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
