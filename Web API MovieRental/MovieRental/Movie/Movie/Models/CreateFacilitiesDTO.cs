using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Movie.Models
{
    public class CreateFacilitiesDTO
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string OpenHours { get; set; }
        [EmailAddress]
        public string ContacEmail { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        [MaxLength(25)]
        public string City { get; set; }
        [Required]
        [MaxLength(25)]
        public string Street { get; set; }
        public string PostaCode { get; set; }
    }
}