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
using Movie.Models;

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

        [HttpGet("AllFacilities")]
        public ActionResult<IEnumerable<FacilitiesDTO>> GetAll()
        {
            var facilities = _dbContext
                .Facilities
                .ToList();

            return Ok(facilities);
        }
        [HttpPost]
        //      akcja         nazwa       paramter pobierany   model na podstawie ktorego twozymy restauracje 
        public ActionResult CreateFacilities([FromBody] CreateFacilitiesDTO dto)
        {
            var facilities = _mapper.Map<Facilities>(dto);
            _dbContext.Facilities.Add(facilities);
            _dbContext.SaveChanges();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created($"/API/MovieRental/{facilities.Id}", null);
        }
        [HttpGet("Facilities/{id}")]
        public ActionResult<FacilitiesDTO> GetId([FromRoute] int id)
        {
            var facilities = _dbContext
                 .Facilities
                 .Include(r => r.Adress)
                 .Include(t => t.Movies)
                 .FirstOrDefault(r => r.Id == id);

            if (facilities is null) return null;

            var result = _mapper.Map<FacilitiesDTO>(facilities);
            return result;
        } 

        [HttpGet("Customer")]

        public ActionResult<Customers> GetCustomers()
        {

         var customer = _dbContext
         .Customers
          .ToList();
        var customersDTOs = _mapper.Map<List<CustomersDTO>>(customer);
            return  Ok(customersDTOs);
        }


[HttpGet("version")]
public string Version()
{
    return "Version 1.0.0";
}

}
}

