using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyExerciseOne.Models;

namespace VidlyExerciseOne.ViewModels
{
    public class MoviesViewModel
    {
        //public List<Movie> MoviesList { get; set; }
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Movie> MoviesList { get; internal set; }
    }
}