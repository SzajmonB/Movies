using MovieRental.Table;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRental;

namespace MovieRental
{
    public class Facilities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OpenHours { get; set; }
        public string ContacEmail { get; set; }

        public string ContactNumber { get; set; }

        public int AdressId { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual List<Movies> Movies { get; set; }
       public virtual List<Customers> Customers { get; set; }

    }


}