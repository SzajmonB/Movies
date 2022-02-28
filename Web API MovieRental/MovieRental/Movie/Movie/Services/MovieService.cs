using System.Collections.Generic;
using System.Linq;
using MovieRental.Table;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie.Models;
using MovieRental;
using Microsoft.Extensions.Logging;
using Movie.Exceptions;

namespace Movie.Services

{
    public interface IMovieService
    {
        int Create(int facialitiesID, CreatMovieDTO dto);
    }
    public class MovieServices : IMovieService
    {
        private readonly MovieRentalDbContext _context;
        private readonly IMapper _mapper;
        public MovieServices (MovieRentalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int facialitiesID, CreatMovieDTO dto)
        {
            var facialities = _context.Facilities.FirstOrDefault(r => r.Id == facialitiesID);
            if (facialities is null)
                throw new NotFoundException("Ni ma takiej restarante amigo");

            var movieEntity = _mapper.Map<Movies>(dto);

            _context.Movies.Add(movieEntity);
            _context.SaveChanges();

            return movieEntity.Id;
            


        }
    }
}