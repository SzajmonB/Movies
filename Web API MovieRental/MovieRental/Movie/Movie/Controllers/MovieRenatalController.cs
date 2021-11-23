using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Table;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace MovieRental.Controllers
{
    
    [Route("API/MovieRental")] //mapowanie zapytania + sciezka 
   
    public class MovieRentalController : ControllerBase

    {
      
        private readonly MovieRentalDbContext _dbContext;
        private IMapper _mapper;

        public MovieRentalController(MovieRentalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<FacilitiesDTO>>Get()
        {
            var facilities = _dbContext
                .Facilities
              // .Include(r => Adress)
              //  .Include(r=>Movies)
                .ToList();


            var facilitiesDTO =_mapper.Map<List<FacilitiesDTO>>(facilities) ; 
            return Ok();
        }

     
        [HttpGet("Customer")]
       
        public ActionResult<Customers> GetAll()
        {
            var customer = _dbContext
                .Customers
                .ToList();

            return Ok(customer);
        }

       [HttpGet("Facilities/{id}")]
        public ActionResult<Facilities> Get([FromRoute] int id)
          {
            var facilities = _dbContext
                .Facilities
                .FirstOrDefault(r=>r.Id ==id);
            if(facilities is null)
            {
                return NotFound();
            }
            return Ok(facilities);
          }
    
        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }
    }
}
        