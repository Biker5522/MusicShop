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
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        [ValidateNever]
        public Album Album { get; set; }
       
        [Range(1,100,ErrorMessage = " Enter a value 1-100")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [NotMapped]
        public double Price { get; set; }
    }
}
