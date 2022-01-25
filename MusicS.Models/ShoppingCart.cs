using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicS.Models
{
    public class ShoppingCart
    {
        public Album Album { get; set; }
        [Range(1,100,ErrorMessage = " Enter a value 1-100")]
        public int Count { get; set; }
    }
}
