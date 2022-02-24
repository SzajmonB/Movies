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
        bool Delete(int id);

        bool Change(int id, ChangeCustomerDTO dto);
    }
}