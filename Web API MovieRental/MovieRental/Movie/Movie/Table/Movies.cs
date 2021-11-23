using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRental;

namespace MovieRental.Table
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public int FacilitiesID { get; set; }
        

    }
}