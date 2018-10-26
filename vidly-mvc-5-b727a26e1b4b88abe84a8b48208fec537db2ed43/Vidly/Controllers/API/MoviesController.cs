using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _ctx;
        public MoviesController()
        {
            _ctx = new ApplicationDbContext();
        }

        //GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _ctx.Movies.Include(m => m.Genre).Select(AutoMapper.Mapper.Map<Movie, MovieDto>);
        }

        //public MovieDto GetMovieById(int id)
        //{
        //    Movie movie = _ctx.Movies.SingleOrDefault(m => m.Id == id);

        //    if (movie == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return AutoMapper.Mapper.Map<Movie, MovieDto>(movie);
        //}

        //GET /api/movies/1
        public IHttpActionResult GetMovieById(int id)
        {
            Movie movie = _ctx.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(AutoMapper.Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Movie movie = AutoMapper.Mapper.Map<MovieDto, Movie>(movieDto);
            _ctx.Movies.Add(movie);
            _ctx.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //public MovieDto CreateMovie(MovieDto movieDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }
        //    Movie movie = AutoMapper.Mapper.Map<MovieDto, Movie>(movieDto);
        //    _ctx.Movies.Add(movie);
        //    _ctx.SaveChanges();
        //    movieDto.Id = movie.Id;
        //    return movieDto;
        //}

        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Movie movieInDb = _ctx.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            AutoMapper.Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);

            _ctx.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            Movie movieInDb = _ctx.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _ctx.Movies.Remove(movieInDb);
            _ctx.SaveChanges();
        }
    }
}
