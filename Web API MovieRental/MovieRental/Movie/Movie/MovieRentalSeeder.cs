using MovieRental.Table;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{
    public class MovieRentalSeeder
    {
        private readonly MovieRentalDbContext _dbContext;


        public MovieRentalSeeder(MovieRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Seed()
        {
            if (_dbContext.Database.CanConnect()) //³aczenie z baza danych 
            {
                if (!_dbContext.Facilities.Any()) //czy tablea jest pusta 
                {
                    var facilities = GetFacilities();
                    _dbContext.Facilities.AddRange(facilities);
                    _dbContext.SaveChanges(); // zapisanie zmian
                }
            }
        }
        private IEnumerable<Facilities> GetFacilities() //dodawanie danych do tabeli Facilities
        {
            var facilities = new List<Facilities>()
            {
            new Facilities()
            {
                //Id dodaje sie z automatu z klucza
                Name = "Dobre Kino",
                Description = "Wypozyczalnia filmów, na styl lat 90'.",
                OpenHours = "Pn-Pt 8-16",
                ContacEmail = "dobrekino@wp.pl",
                ContactNumber = "555-345-136",
                Movies = new List<Movies>() // jeden do wielu dodajemy przez liste
                {
                    new Movies()
                    {
                        Title= "Terminator",
                        Description = "Tytu³owy Terminator (Arnold Schwarzenegger) w pierwszej czêœci serii jest androidem, który zosta³ wys³any w przesz³oœæ w celu zlikwidowania Sary Connor (Linda Hamilton), matki przywódcy rebeliantów, nielicznych ludzi, którzy walcz¹ w przysz³oœci z cyborgami o przetrwanie.",
                        Price = 15.99M,
                    },
                    new Movies()
                    {
                    Title= "Dirty Dancig",
                    Description = "Dirty Dancing – dramatyczny romans taneczny produkcji amerykañskiej z roku 1987 wyre¿yserowany przez Emile Ardolino, w rolach g³ównych wyst¹pili Patrick Swayze, Jennifer Grey i Jerry Orbach",
                    Price = 9.99M,
                    },
                    new Movies()
                     {
                         Title = "Titanic",
                         Description = "Titanic – film fabularny produkcji amerykañskiej z 1997 roku, oparty na historycznym wydarzeniu – zatoniêciu „Titanica” w 1912 roku. Zdoby³ jedenaœcie Oscarów, w tym za najlepszy film. Titanic jest trzeci na liœcie najbardziej kasowych filmów w historii kina. Jako pierwszy przekroczy³ barierê 1 mld USD przychodów.",
                         Price = 19.99M,
                     }

                },
                Adress = new Adress()
                {
                    City = "Kraków",
                    Street = "Krótka 12",
                    PostaCode = " 02-236",
                },
                Customers = new List<Customers>
                {
                    new Customers()
                    {
                        Name = "Jan",
                        SecondName = "Kowalski",
                        Description = "Fan kina akcji",
                        RentedMovies =3,
                        FacilitiesID =1,
                    },
                    new Customers()
                    {
                        Name= "Ewa",
                        SecondName= "Nowakowska",
                        Description = "Preferuje komedie romantyczne",
                        RentedMovies = 1,
                        FacilitiesID =1,
                    }

                }



            },
            new Facilities()
            {
                //Id dodaje sie z automatu z klucza
                Name = "BajkowyŒwiat",
                Description = "Wypozyczalnia filmów animowanych.",
                OpenHours = "pon-sbt od 10-22 ",
                ContacEmail = "bajkowyswiat@wp.pl",
                ContactNumber = "523-987-664",
                Movies = new List<Movies>() // jeden do wielu dodajemy przez liste
                {
                    new Movies()
                    {
                        Title= "Król Lew",
                        Description = "Król Lew – film animowany ze studia Walta Disneya, wydany w 1994. W historii tej wytwórni by³ to 32. pe³nometra¿owy film. Fabu³a filmu pokazuje losy Simby – m³odego lwa, który poznaje swoje miejsce w „Wielkim krêgu ¿ycia” i pokonuje szereg przeszkód, by zostaæ królem Lwiej Ziemi",
                        Price = 14.99M,
                    },
                    new Movies()
                    {
                    Title= "Shrek",
                    Description = "Pierwszy film serii o Shreku. Wyprodukowany zosta³ przez DreamWorks Animation. Œwiatowa premiera mia³a miejsce 22 kwietnia 2001 r., a polska premiera 13 lipca 2001 r. Film ten osi¹gn¹³ niesamowity sukces",
                    Price = 19.99M,
                    },
                    new Movies()
                     {
                         Title = "Kung Fu Panda",
                         Description = "Amerykañski film animowany studia DreamWorks z 2008 roku opowiadaj¹cy o pandzie Po, którego marzeniem jest opanowanie sztuki walki kung-fu",
                         Price = 13.99M,
                     }

                },
                Adress = new Adress()
                {
                    City = "Warszawa",
                    Street = "Komornicza 23b",
                    PostaCode = " 03-765",
                },
                Customers = new List<Customers>
                {
                    new Customers()
                    {
                        Name = "Adam",
                        SecondName = "Kowalski",
                        Description = "Uwielba produkcje DreamWorks.",
                        RentedMovies =2,
                        FacilitiesID =2,
                    },
                    new Customers()
                    {
                        Name= "Aleksandra",
                        SecondName= "Stark",
                        Description = "Fanka starych animacji.",
                        RentedMovies =1,
                        FacilitiesID =2,
                    }

                }

            }

            };
            return facilities;




        }
    }
    }
   

