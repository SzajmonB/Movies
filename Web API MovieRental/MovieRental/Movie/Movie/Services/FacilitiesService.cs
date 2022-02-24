using System.Collections.Generic;
using System.Linq;
using MovieRental.Table;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie.Models;
using MovieRental;
using Microsoft.Extensions.Logging;

namespace Movie.Services
{
    /* public interface IFacilitiesService
     {
         FacilitiesDTO GetById(int id);
         IEnumerable<CustomersDTO> GetAll();
         void Create(CreateFacilitiesDTO dto);

     }*/
    public class FacilitiesService : IFacilitiesService

    {
        private MovieRentalDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<FacilitiesService> _logger;

        public FacilitiesService(MovieRentalDbContext dbContext, IMapper mapper, ILogger<FacilitiesService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public bool Change(int id, ChangeCustomerDTO dto)
        {
          
            _logger.LogError($"Customers with id {id} Change parameters WARNING");
            var customers = _dbContext
              .Customers
              .FirstOrDefault(r => r.Id == id);

            if (customers is null) return false;

            customers.Name = dto.Name;
            customers.SecondName = dto.SecondName;
            customers.Description = dto.Description;
            customers.RentedMovies = dto.RentedMovies;
            _dbContext.SaveChanges();
            return true;

        }
      
        public FacilitiesDTO GetById(int id)
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
        public IEnumerable<FacilitiesDTO> GetAll()
        {
            var facilities = _dbContext
              .Facilities
              .Include(r => r.Adress)
              .Include(t => t.Movies)
               .ToList();


            var facilitiesDTO = _mapper.Map<List<FacilitiesDTO>>(facilities);
            return facilitiesDTO;
        }
        public IEnumerable<CustomersDTO> GetCustomers()
        {
            var customers = _dbContext
              .Customers
               .ToList();


            var customersDTO = _mapper.Map<List<CustomersDTO>>(customers);
            return customersDTO;
        }

        public int Create(CreateFacilitiesDTO dto)
        {
            var facilities = _mapper.Map<Facilities>(dto);
            _dbContext.Facilities.Add(facilities);
            _dbContext.SaveChanges();

            return facilities.Id;
        }
        public bool Delete (int id)
        {
            
            
            var facilities = _dbContext
               .Facilities
              
               .FirstOrDefault(r => r.Id == id);

            if (facilities is null) return false;

            _dbContext.Facilities.Remove(facilities);
            _dbContext.SaveChanges();
            return true;

        }
    }
}