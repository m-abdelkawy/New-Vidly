using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }

        //public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        /*---------------------To Solve Initialization problem of some properties*/
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }


        [ForeignKey("Genre")]
        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Column(TypeName = "DateTime2")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }
    }
}