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
using Movie.Services;

namespace MovieRental.Controllers
{

    [Route("API/MovieRental")] //mapowanie zapytania + sciezka 
    public class MovieRentalController : ControllerBase

    {



        private readonly IFacilitiesService _facilitiesService;


        public MovieRentalController(IFacilitiesService facilitiesService)
        {
            _facilitiesService = facilitiesService;
        }

        [HttpGet("AllCustomers")]
        public ActionResult<IEnumerable<FacilitiesDTO>> GetAll()
        {
            var facilitiesDTO = _facilitiesService.GetAll();

            return Ok(facilitiesDTO);
        }
        [HttpPost]
        //      akcja         nazwa       paramter pobierany   model na podstawie ktorego twozymy restauracje 
        public ActionResult CreateFacilities([FromBody] CreateFacilitiesDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _facilitiesService.Create(dto);

            return Created($"/API/MovieRental/{id}", null);
        }
        [HttpGet("Facilities/{id}")]
        public ActionResult<FacilitiesDTO> GetId([FromRoute] int id)
        {
            var facilitiesDTO = _facilitiesService.GetById(id);



            if (facilitiesDTO is null)
            {
                return NotFound();
            }


            return facilitiesDTO;
        }

        [HttpGet("Customer")]

        public ActionResult<Customers> GetCustomers()
        {

            var customerDTO = _facilitiesService.GetAll();

            return Ok(customerDTO);
        }


        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _facilitiesService.Delete(id);

            if (isDeleted)
            {
                return NoContent();

            }

            return NotFound();
        }

    }
}

