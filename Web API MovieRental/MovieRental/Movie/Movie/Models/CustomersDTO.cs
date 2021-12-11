using System.Runtime.InteropServices;
using MovieRental.Table;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace MovieRental.Table
{
    public class CustomersDTO
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Description { get; set; }

        public int RentedMovies { get; set; }
    }
}
