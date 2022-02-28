using System;
using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Movie.Services;
using MovieRental.Table;
using System.Collections.Generic;

namespace Movie.Controllers
{
    [Route ("API/facialities/{FacialitiesID}/Movies")]
    [ApiController]

    public class MovieControler : ControllerBase

    {
        private readonly IMovieService _movieservices;

        public MovieControler (IMovieService movieService)
        {
            _movieservices = movieService;
        }

        [HttpPost]

        public ActionResult Post([FromRoute] int FacialitiesID ,[FromBody] CreatMovieDTO dto)
        {
           var newMovieID = _movieservices.Create(FacialitiesID, dto);

            return Created($"api/{FacialitiesID}/movie/{newMovieID}", null);

        }
    }

}