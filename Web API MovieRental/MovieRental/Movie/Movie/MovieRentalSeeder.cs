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
            if (_dbContext.Database.CanConnect()) //�aczenie z baza danych 
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
                Description = "Wypozyczalnia film�w, na styl lat 90'.",
                OpenHours = "Pn-Pt 8-16",
                ContacEmail = "dobrekino@wp.pl",
                ContactNumber = "555-345-136",
                Movies = new List<Movies>() // jeden do wielu dodajemy przez liste
                {
                    new Movies()
                    {
                        Title= "Terminator",
                        Description = "Tytu�owy Terminator (Arnold Schwarzenegger) w pierwszej cz�ci serii jest androidem, kt�ry zosta� wys�any w przesz�o�� w celu zlikwidowania Sary Connor (Linda Hamilton), matki przyw�dcy rebeliant�w, nielicznych ludzi, kt�rzy walcz� w przysz�o�ci z cyborgami o przetrwanie.",
                        Price = 15.99M,
                    },
                    new Movies()
                    {
                    Title= "Dirty Dancig",
                    Description = "Dirty Dancing � dramatyczny romans taneczny produkcji ameryka�skiej z roku 1987 wyre�yserowany przez Emile Ardolino, w rolach g��wnych wyst�pili Patrick Swayze, Jennifer Grey i Jerry Orbach",
                    Price = 9.99M,
                    },
                    new Movies()
                     {
                         Title = "Titanic",
                         Description = "Titanic � film fabularny produkcji ameryka�skiej z 1997 roku, oparty na historycznym wydarzeniu � zatoni�ciu �Titanica� w 1912 roku. Zdoby� jedena�cie Oscar�w, w tym za najlepszy film. Titanic jest trzeci na li�cie najbardziej kasowych film�w w historii kina. Jako pierwszy przekroczy� barier� 1 mld USD przychod�w.",
                         Price = 19.99M,
                     }

                },
                Adress = new Adress()
                {
                    City = "Krak�w",
                    Street = "Kr�tka 12",
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
                Name = "Bajkowy�wiat",
                Description = "Wypozyczalnia film�w animowanych.",
                OpenHours = "pon-sbt od 10-22 ",
                ContacEmail = "bajkowyswiat@wp.pl",
                ContactNumber = "523-987-664",
                Movies = new List<Movies>() // jeden do wielu dodajemy przez liste
                {
                    new Movies()
                    {
                        Title= "Kr�l Lew",
                        Description = "Kr�l Lew � film animowany ze studia Walta Disneya, wydany w 1994. W historii tej wytw�rni by� to 32. pe�nometra�owy film. Fabu�a filmu pokazuje losy Simby � m�odego lwa, kt�ry poznaje swoje miejsce w �Wielkim kr�gu �ycia� i pokonuje szereg przeszk�d, by zosta� kr�lem Lwiej Ziemi",
                        Price = 14.99M,
                    },
                    new Movies()
                    {
                    Title= "Shrek",
                    Description = "Pierwszy film serii o Shreku. Wyprodukowany zosta� przez DreamWorks Animation. �wiatowa premiera mia�a miejsce 22 kwietnia 2001 r., a polska premiera 13 lipca 2001 r. Film ten osi�gn�� niesamowity sukces",
                    Price = 19.99M,
                    },
                    new Movies()
                     {
                         Title = "Kung Fu Panda",
                         Description = "Ameryka�ski film animowany studia DreamWorks z 2008 roku opowiadaj�cy o pandzie Po, kt�rego marzeniem jest opanowanie sztuki walki kung-fu",
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
   

