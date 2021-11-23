using System.Collections.Generic;

namespace MovieRental.Table
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Description { get; set; }

        public int  RentedMovies { get; set; }
        public int FacilitiesID { get; set; }
        public virtual List<Movies> Movies { get; set; }

    }
}