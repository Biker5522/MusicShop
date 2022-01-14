using System.ComponentModel.DataAnnotations;

namespace MusicS.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }  
        public string Band { get; set;}
        public string Genre { get; set; }
        public int Year { get; set; }
    }
}
