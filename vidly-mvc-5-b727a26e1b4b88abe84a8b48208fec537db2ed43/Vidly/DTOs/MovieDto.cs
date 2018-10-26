using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Genre")]
        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Column(TypeName = "DateTime2")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public GenreDto Genre { get; set; }
    }
}