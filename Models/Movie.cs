using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesManager.Models
{
    public class Movie
    {
        [Display(Name = "Identificador")]
        public int ID { get; set; }
        
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Fecha de Estreno")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Genero")]
        public string Genre { get; set; }

        [Display(Name = "Precio")]        
        public decimal Price { get; set; }
    }
}