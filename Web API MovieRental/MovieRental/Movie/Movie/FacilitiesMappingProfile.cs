using AutoMapper;
using MovieRental.Table;


namespace MovieRental
{
    public class FacilitiesMapiingProfile : Profile

    {
        public FacilitiesMapiingProfile()
        {
            CreateMap<Facilities, FacilitiesDTO>()
            .ForMember(m => m.City, c => c.MapFrom(s => s.Adress.City))
            .ForMember(m => m.Street, c => c.MapFrom(s => s.Adress.Street))
            .ForMember(m => m.PostaCode, c => c.MapFrom(s => s.Adress.PostaCode));


            CreateMap<Movies, MoviesDTO>(); // ?
                
                
        }
    }
}

