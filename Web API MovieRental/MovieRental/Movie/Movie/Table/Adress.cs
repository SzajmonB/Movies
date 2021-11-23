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
    public class Adress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostaCode { get; set; }
        public virtual Facilities Facilities{ get; set; }

    }

}