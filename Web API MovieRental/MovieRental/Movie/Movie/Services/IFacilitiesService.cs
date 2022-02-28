using Movie.Models;
using MovieRental;
using MovieRental.Table;
using System.Collections.Generic;

namespace Movie.Services
{
    public interface IFacilitiesService
    {
        int Create(CreateFacilitiesDTO dto);
        IEnumerable<FacilitiesDTO> GetAll();
        IEnumerable<CustomersDTO> GetCustomers();
        FacilitiesDTO GetById(int id);
        void Delete(int id);

        void Change(int id, ChangeCustomerDTO dto);
    }
}