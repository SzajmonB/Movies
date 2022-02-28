using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models

{
    public class CreatMovieDTO
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public int FacilitiesID { get; set; }
    }
}