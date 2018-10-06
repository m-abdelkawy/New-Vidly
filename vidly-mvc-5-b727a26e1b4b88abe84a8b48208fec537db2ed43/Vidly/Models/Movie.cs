
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        public Genre Genre { get; set; }

        [ForeignKey("Genre")]
        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Column(TypeName ="DateTime2")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
    }
}