using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LaptopSystem.Web.Models;

namespace LaptopSystem.Web.Controllers
{
    public class CommentsAdminController : AdminController
    {
        public CommentsAdminController()
            : base()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadComments([DataSourceRequest] DataSourceRequest request)
        {
            var commentModels = this.data.Comments.All()
                .Select(CommentViewModel.FromComment);

            return Json(commentModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult UpdateComment([DataSourceRequest] DataSourceRequest request, CommentViewModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var existingComment = this.data.Comments.GetById(commentModel.Id);
                existingComment.Content = commentModel.Content;

                this.data.Comments.Update(existingComment);
                this.data.SaveChanges();
            }

            return Json(new[] { commentModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult DeleteComment([DataSourceRequest] DataSourceRequest request, CommentViewModel commentModel)
        {
            this.data.Comments.Delete(commentModel.Id);
            this.data.SaveChanges();

            return Json(new[] { commentModel }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}