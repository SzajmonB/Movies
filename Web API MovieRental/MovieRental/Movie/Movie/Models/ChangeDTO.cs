using System;
using System.Linq;
using MovieRental.Table;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MovieRental

{
    public class ChangeCustomerDTO
    {
        [Required]
      
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Description { get; set; }

        public int RentedMovies { get; set; }



    }

    internal class MaxLenghtAttribute : Attribute
    {
    }
}