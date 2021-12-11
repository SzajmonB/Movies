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
using MovieRental;

namespace Movie.Services
{
    public class FacilitiesService

    {
        private MovieRentalDbContext _dbContext;
        private readonly IMapper _mapper;

        public FacilitiesService(MovieRentalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public FacilitiesDTO GetById(int id)
        {
            var facilities = _dbContext
               .Facilities
               .Include(r=> r.Adress)
               .Include(t=>t.Movies)
               .FirstOrDefault(r => r.Id == id);

            if (facilities is null) return null;
      
            var result = _mapper.Map<FacilitiesDTO>(facilities);
            return result;
        }
        public IEnumerable<CustomersDTO> GetAll()
        {
            {
                var facilities = _dbContext
                    .Facilities
                  .Include(r => r.Adress)
                  .Include(r => r.Movies)
                    .ToList();


                var facilitiesDTO = _mapper.Map<List<FacilitiesDTO>>(facilities);
                return (IEnumerable<CustomersDTO>)facilitiesDTO;
            }
        }
            public void Create(CreateFacilitiesDTO dto)
        {
            var facilities = _mapper.Map<Facilities>(dto);
            _dbContext.Facilities.Add(facilities);
            _dbContext.SaveChanges();
        }
    }
}