using MoviesApplication.Models;
using MoviesApplication.Repositories;
using MoviesApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesApplication.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IRepository<Movie> movieRepository;
        private readonly DbContext dbContext;

        public MoviesController()
        {
            this.dbContext = new ApplicationDbContext();
            this.movieRepository = new EfRepository<Movie>(this.dbContext);
        }

        [HttpPost]
        public ActionResult Create(Movie model)
        {
            this.movieRepository.Add(model);
            var movies = this.movieRepository
                .GetAll()
                .Select(MovieViewModel.FromMovieEntity);

            return PartialView("_AllMoviesPartial", movies);
        }

        [HttpGet]
        public ActionResult All()
        {
            var movies = this.movieRepository
                .GetAll()
                .Select(MovieViewModel.FromMovieEntity);

            return View(movies);
        }

        [HttpGet]
        public ActionResult Single(int id)
        {
            var movieEntity = this.movieRepository.GetById(id);
            var movieModel = MovieViewModel.CreateFromMovieEntity(movieEntity);

            return View(movieModel);
        }

        public ActionResult Update(Movie model)
        {
            this.movieRepository.Update(model);

            return PartialView("_SingleBookPartial", MovieViewModel.CreateFromMovieEntity(model));
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("Invalid movie");
            }

            this.movieRepository.Delete((int)id);

            var movies = this.movieRepository
                .GetAll()
                .Select(MovieViewModel.FromMovieEntity);

            return RedirectToAction("All", movies);
        }
    }
}