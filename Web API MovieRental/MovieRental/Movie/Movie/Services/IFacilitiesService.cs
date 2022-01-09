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
        FacilitiesDTO GetById(int id);
        bool Delete(int id);
    }
}