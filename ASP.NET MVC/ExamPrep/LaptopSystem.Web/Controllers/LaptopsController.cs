using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using LaptopSystem.Web.Models;
using LaptopSystem.Models;
using Microsoft.AspNet.Identity;
using Kendo.Mvc.UI;

namespace LaptopSystem.Web.Controllers
{
    public class LaptopsController : BaseController
    {
        public LaptopsController()
            : base()
        {
        }

        public ActionResult Details(int id)
        {
            string userId = this.User.Identity.GetUserId();

            var laptop = this.data.Laptops.All()
                .Include("Comments")
                .Include("Votes")
                .Include("Manufacturer")
                .Where(lap => lap.Id == id)
                .Select(lap => new LaptopDetailsViewModel()
                {
                    AdditionalParts = lap.AdditionalParts,
                    Comments = lap.Comments.Select(comment => new CommentViewModel()
                        {
                            AuthorName = comment.Author.UserName,
                            Content = comment.Content
                        }),
                    Description = lap.Description,
                    HardDiskSize = lap.HardDiskSize,
                    Id = lap.Id,
                    ImageUrl = lap.ImageUrl,
                    ManufacturerName = lap.Manufacturer.Name,
                    Model = lap.Model,
                    MonitorSize = lap.MonitorSize,
                    Price = lap.Price,
                    RamSize = lap.RamSize,
                    Votes = lap.Votes.Count(),
                    Weight = lap.Weight,
                    UserHasVoted = lap.Votes.Any(x => x.VotedById == userId)
                })
                .FirstOrDefault();

            return View(laptop);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult PostComment(PostCommentModel postCommentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                var newComment = new Comment()
                {
                    AuthorId = userId,
                    Content = postCommentModel.Comment,
                    LaptopId = postCommentModel.LaptopId
                };

                this.data.Comments.Add(newComment);
                this.data.SaveChanges();

                var viewModel = new CommentViewModel()
                {
                    AuthorName = username,
                    Content = postCommentModel.Comment
                };

                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult VoteOnLaptop(int laptopId)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var newVote = new Vote()
                {
                    LaptopId = laptopId,
                    VotedById = userId
                };

                this.data.Votes.Add(newVote);
                this.data.SaveChanges();

                var existingLaptop = this.data.Laptops.GetById(laptopId);
                int votesCount = existingLaptop.Votes.Count();

                return Content(votesCount.ToString());
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [Authorize]
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Search(SubmitSearchModel searchModel)
        {
            var result = this.data.Laptops.All();

            if (!string.IsNullOrEmpty(searchModel.ModelQuery))
            {
                result = result.Where(
                    lap => lap.Model.ToLower().Contains(searchModel.ModelQuery.ToLower()));
            }

            if (searchModel.ManufacturerQuery != "All")
            {
                result = result.Where(
                    lap => lap.Manufacturer.Name.ToLower().Contains(searchModel.ManufacturerQuery.ToLower()));
            }

            if (searchModel.PriceQuery != 0)
            {
                result = result.Where(
                    lap => lap.Price <= searchModel.PriceQuery);
            }

            var endResult = result.Select(LaptopViewModel.FromLaptop).ToList();

            return View(endResult);
        }

        public JsonResult ReadLaptops([DataSourceRequest] DataSourceRequest request)
        {
            var laptops = this.data.Laptops.All()
                .Select(LaptopViewModel.FromLaptop);

            return Json(laptops.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLaptopsModelData(string text)
        {
            var models = this.data.Laptops.All()
                .Where(lap => lap.Model.ToLower().Contains(text.ToLower()))
                .Select(lap => new
                {
                    Model = lap.Model
                });

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLaptopsManufacturerData()
        {
            var manufacturers = this.data.Laptops.All()
                .Select(lap => new
                {
                    ManufacturerName = lap.Manufacturer.Name
                })
                .Distinct();

            return Json(manufacturers, JsonRequestBehavior.AllowGet);
        }
    }
}