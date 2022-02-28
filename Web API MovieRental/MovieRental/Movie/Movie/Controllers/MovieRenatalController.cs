using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Movie.Services;
using MovieRental.Table;
using System.Collections.Generic;

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
        [HttpPut ("Change/{id}")]
        public ActionResult Change([FromBody]ChangeCustomerDTO dto, [FromRoute]int id)
        {
          

            _facilitiesService.Change(id, dto);
         
            
            return Ok();

        }

        [HttpGet("All")]
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



       


            return facilitiesDTO;
        }

        [HttpGet("Customer")]

        public ActionResult<Customers> GetCustomers()
        {

            var customerDTO = _facilitiesService.GetCustomers();

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
            _facilitiesService.Delete(id);

           

            return NotFound();
        }
     

    }
}

