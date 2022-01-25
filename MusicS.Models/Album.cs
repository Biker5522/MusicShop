using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicS.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Title { get; set; }
        [Required]
        public string Band{ get; set;}
        [Required]

        public  int Year { get; set;}
        [Range(1, 10000)]
        [Required]
        [Display(Name = "ListPrice")]
        public double ListPrice { get; set; }
        [Range(1,10000)]
        [Required]

        public double Price { get; set; }
        [Range(1, 10000)]
        [Required]
        [Display(Name = "Price for 3+")]
        public double Price3 { get; set; }
       
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Genre")]
        [ValidateNever]
        public int GenreId  { get; set; }
        [ForeignKey("GenreId")]
        [ValidateNever]
        public Genre Genre { get; set; }
    }

}
