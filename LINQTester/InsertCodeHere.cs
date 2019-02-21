using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQTester
{
    class InsertCodeHere
    {

        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            List<Movie> movies = new List<Movie>() 
            {
                new Movie{Title ="Se7en", Year = 1995, DurationInMins = 127, StudioName="New Line Cinema"},
                new Movie{Title = "Alien", Year = 1979, DurationInMins = 117, StudioName="20th Century Fox"},
                new Movie{Title = "Forrest Gump", Year = 1994, DurationInMins = 142, StudioName="Paramount Pictures"},
                new Movie{Title = "True Grit", Year = 2010, DurationInMins = 110, StudioName="Paramount Pictures"},
                new Movie{Title = "Dark City", Year = 1998, DurationInMins = 111, StudioName="New Line Cinema"},
                
            };

            List<Studio> studios = new List<Studio>()
            {
                new Studio{StudioName = "New Line Cinema", HQCity = "Boston", NoOfEmployees = 4000},
                new Studio{StudioName = "20th Century Fox", HQCity = "New York", NoOfEmployees = 2500},
                new Studio{StudioName = "Paramount Pictures", HQCity = "New York", NoOfEmployees = 8000}

            };

            //Example 1
            // The Three Parts of a LINQ Query:
            //  1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery = from num in numbers
                where (num % 2) == 0
                select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }

            // Selection – single property


            Console.WriteLine("Selection – single property \n");
            IEnumerable<string> titles = from m in movies
                select m.Title;

            foreach (var element in titles)
            {
                Console.WriteLine(element);
            }

            // Selection – several properties

            Console.WriteLine("\nSelection – several properties\n");
            var titlesAndYears = from m in movies
                select new { m.Title, m.Year };


            foreach (var element in titlesAndYears)
            {
                Console.WriteLine(element.Title + " made in " + element.Year);
            }

            Console.WriteLine("\nSelection – several properties with explicit specification of properties\n");

            var titlesAndYears2 = from m in movies
                select new
                {
                    Summary = m.Title + " made by " + m.StudioName,
                    m.Year
                };

            foreach (var element in titlesAndYears2)
            {
                Console.WriteLine(element.Summary + " " + element.Year);
            }

            Console.WriteLine("\nSelection – collections containing collections\n");

            movies[0].Actors= new List<Actor>()  { new Actor() {Name="Dustin Hoffmann"}, new Actor() { Name = "Denzel Washington" } };
            movies[1].Actors = new List<Actor>() { new Actor() { Name = "Meryl Streep" }, new Actor() { Name = "Jack Nicholson" } };
            movies[2].Actors = new List<Actor>() { new Actor() { Name = "Ralph Fiennes" }, new Actor() { Name = "Sigourney Weaver" } };
            movies[3].Actors = new List<Actor>() { new Actor() { Name = "Robert De Niro" }, new Actor() { Name = "Al Pacino" } };
            movies[4].Actors = new List<Actor>() { new Actor() { Name = "Dustin Hoffmann" }, new Actor() { Name = " Jack Nicholson" } };

            var titlesAndActors = from m in movies
                select new { m.Title, m.Actors };

            foreach (var element in titlesAndActors)
            {
                Console.Write(element.Title + " actors :" );
                foreach (var actor in element.Actors)
                {
                    Console.Write(actor.Name + ", ");
                }
                Console.WriteLine();
            }

            //Filtering
            Console.WriteLine("\nFiltering\n");

            var titlesAndYears3 = from m in movies
                where (m.Year < 1996 && m.Year > 1980)
                select new { m.Title, m.Year };

            foreach (var element in titlesAndYears3)
            {
                Console.WriteLine(element.Title + " " + element.Year);
            }

            // Ordering
            Console.WriteLine("\nOrdering\n");

            //var titlesAndYears4 = from m in movies
            //                      where (m.Year < 1996 && m.Year > 1980)
            //                      orderby m.Year
            //                      select new { m.Title, m.Year };

            var titlesAndYears4 = from m in movies
                where (m.Year < 1996 && m.Year > 1980)
                orderby m.Year, m.Title
                select new { m.Title, m.Year };

            foreach (var element in titlesAndYears4)
            {
                Console.WriteLine(element.Title + " " + element.Year);
            }

            //Aggregation functions
            Console.WriteLine("\nAggregation functions\n");

            IEnumerable<string> titles2 = from m in movies
                select m.Title;
            
            // This is fine
            Console.WriteLine(titles2.Count());

            // This is also fine
            Console.WriteLine((from m in movies select m.Title).Count());

            Console.WriteLine((from m in movies select m.Year).Average());

            //Doesn't make sense
            //Console.WriteLine((from m in movies select m.Title).Average());

            Console.WriteLine((from m in movies select m.Title).Max());

            // Joining
            Console.WriteLine("\nJoining\n");

            var joinTitleStudio = from m in movies
                join s in studios
                    on m.StudioName equals s.StudioName
                where s.HQCity == "New York"
                select m.Title;

            foreach (var element in joinTitleStudio)
            {
                Console.WriteLine(element);
            }



            var movies95to98 = from m in movies
                where m.Year >= 1995 && m.Year <= 1998
                select new
                {
                    MyTitle = m.Title,
                    m.Year,
                    NumberOfActorsThatStartWithD = (from a in m.Actors
                        where a.Name.StartsWith("D")
                        select a).Count()
                };

            foreach (var element in movies95to98)
            {
                Console.WriteLine(element);
            }
            // Deferred evaluation
            Console.WriteLine("\nDeferred evaluation\n");

            List<Movie> movies2 = new List<Movie>();

            // Enter two objects
            movies2.Add(new Movie("Se7en", 1995, 127, "New Line Cinema"));
            movies2.Add(new Movie("Alien", 1979, 117, "20th Century Fox"));

            // Define the query
            IEnumerable<string> titles3 = from m in movies2
                select m.Title;

            // Enter two objects
            movies2.Add(new Movie("Forrest Gump", 1994, 142, "Paramount Pictures"));
            movies2.Add(new Movie("True Grit", 2010, 110, "Paramount Pictures"));
            movies2.Add(new Movie("Dark City", 1998, 111, "New Line Cinema"));

            
            // Iterate over the query result
            foreach (var element in titles3)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Define the query combining LINQ and Lambda expressions");
            // Define the query combining LINQ and Lambda expressions
            IEnumerable<string> titles4 = from m in movies2.FindAll(m => m.Year > 1979)
                select m.Title;

            foreach (var element in titles4)
            {
                Console.WriteLine(element);
            }

            //List movies der er lavet fra et filmselskab fra New York
            Console.WriteLine("List movies der er lavet fra et filmselskab fra New York");
            var moviesNewYork = from m in movies
                join s in studios
                    on m.StudioName equals s.StudioName
                where s.HQCity=="New York"
                select new
                {
                    MoviesName = m.Title,
                    ProductionCity = s.HQCity,
                    numberOfActors = (from a in m.Actors
                                      where a.Name.StartsWith("R")
                                      select a).Count()
                };

            foreach (var m in moviesNewYork)         {
                Console.WriteLine($"Title {m.MoviesName}  City {m.ProductionCity} number of Actor with R {m.numberOfActors}");
            }

            // The LAST line of code should be ABOVE this line
        }
    }
}
