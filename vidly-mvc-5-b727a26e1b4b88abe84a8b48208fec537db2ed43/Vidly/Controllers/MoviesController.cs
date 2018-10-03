﻿using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Validation;
using System;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _ctx;
        public MoviesController()
        {
            _ctx = new ApplicationDbContext();
        }
        public ViewResult Index()
        {
            //var movies = GetMovies();
            //Deferred Execution
            IEnumerable<Movie> movies = _ctx.Movies.Include(m => m.Genre).ToList();

            return View(movies);    
        }

        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie { Id = 1, Name = "Shrek" },
        //        new Movie { Id = 2, Name = "Wall-e" }
        //    };
        //}

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        public ActionResult MovieDetails(int id)
        {
            Movie movie = _ctx.Movies.Include(c => c.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            IEnumerable<Genre> genres = _ctx.Genres;
            MovieFormViewModel movieViewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", movieViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _ctx.Movies.Add(movie);
            else
            {
                Movie movieInDB = _ctx.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
            }

            _ctx.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            Movie movie = _ctx.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            MovieFormViewModel movieViewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _ctx.Genres.ToList()
            };
            return View("MovieForm", movieViewModel);
        }
    }
}