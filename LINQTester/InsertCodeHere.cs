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
            #region Create List of movies
            List<Movie> movies = new List<Movie>()
            {
                new Movie{Title ="Se7en", Year = 1995, DurationInMins = 127, StudioName="New Line Cinema"},
                new Movie{Title = "Alien", Year = 1979, DurationInMins = 117, StudioName="20th Century Fox"},
                new Movie{Title = "Forrest Gump", Year = 1994, DurationInMins = 142, StudioName="Paramount Pictures"},
                new Movie{Title = "True Grit", Year = 2010, DurationInMins = 110, StudioName="Paramount Pictures"},
                new Movie{Title = "Dark City", Year = 1998, DurationInMins = 111, StudioName="New Line Cinema"},

            };
            #region Create actors
            movies[0].Actors = new List<Actor>() { new Actor() { Name = "Dustin Hoffmann" }, new Actor() { Name = "Denzel Washington" } };
            movies[1].Actors = new List<Actor>() { new Actor() { Name = "Meryl Streep" }, new Actor() { Name = "Jack Nicholson" } };
            movies[2].Actors = new List<Actor>() { new Actor() { Name = "Ralph Fiennes" }, new Actor() { Name = "Sigourney Weaver" } };
            movies[3].Actors = new List<Actor>() { new Actor() { Name = "Robert De Niro" }, new Actor() { Name = "Al Pacino" } };
            movies[4].Actors = new List<Actor>() { new Actor() { Name = "Dustin Hoffmann" }, new Actor() { Name = " Jack Nicholson" } };
            #endregion
            #endregion

            #region create list of studios
            List<Studio> studios = new List<Studio>()
            {
                new Studio{StudioName = "New Line Cinema", HQCity = "Boston", NoOfEmployees = 4000},
                new Studio{StudioName = "20th Century Fox", HQCity = "New York", NoOfEmployees = 2500},
                new Studio{StudioName = "Paramount Pictures", HQCity = "New York", NoOfEmployees = 8000}

            };
            #endregion

            #region Examples 1

            //int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            ////// 2.Query creation.
            ////// numQuery is an IEnumerable < int >
            //var numQuery = from num in numbers
            //               where (num % 2) == 0
            //               select num;

            //// 3.Query execution.
            //foreach (int num in numQuery)
            //{
            //    Console.Write($"{num} ");
            //}

            //int evenNumCount = numQuery.Count();

            #endregion

            #region Example select titles
            //IEnumerable<string> titles1 = from m in movies
            //                              select m.Title;

            //foreach (string title in titles1)
            //{
            //    Console.WriteLine(title);
            //}

            #endregion

            #region Example select title and year
            //var titlesAndYears = from m in movies
            //                     select new { m.Title, m.Year };
            //foreach (var title1 in titlesAndYears)
            //{
            //    Console.WriteLine(title1.Title + " " + title1.Year);
            //}
            #endregion

            #region Example summary and year
            //var summaryAndYears = from m in movies
            //                      select new
            //                      {
            //                          Summary = $"{m.Title} made by {m.StudioName}",
            //                          m.Year
            //                      };

            //foreach (var sumAndYear in summaryAndYears)
            //{
            //    Console.WriteLine(sumAndYear.Summary + " " + sumAndYear.Year);
            //}
            #endregion

            #region Example Movies and actors
            //var titlesAndActors = from m in movies
            //                      select new { m.Title, m.Actors };

            //foreach (var item in titlesAndActors)
            //{
            //    Console.WriteLine(item.Title);
            //    foreach (var actor in item.Actors)
            //    {
            //        Console.WriteLine("\t" + actor.Name);
            //    }
            //}
            #endregion

            #region Example filtering and ordering by year
            //var titlesAndYearsOrdered = from m in movies
            //                            where m.Year < 1996
            //                            orderby m.Year
            //                            select new { m.Title, m.Year };

            //foreach (var titlesAndYear in titlesAndYearsOrdered)
            //{
            //    Console.WriteLine(titlesAndYear.Title + " " + titlesAndYear.Year);
            //}

            #endregion

            #region Example Aggregation functions
            //IEnumerable<string> titles = from m in movies
            //                             select m.Title;
            //// This is fine
            //Console.WriteLine(titles.Count());

            //// This is also fine
            //Console.WriteLine((from m in movies select m.Title).Count());


            //Console.WriteLine((from m in movies select m.Year).Average());

            ////Doesn't make sense
            ////Console.WriteLine((from m in movies select m.Title).Average());

            //Console.WriteLine((from m in movies select m.Title).Max());

            #endregion


            #region Example 1 join
            //Console.WriteLine("Find titler på film der er lavet i et studio i New York");
            //var joinTitleStudio = from m in movies
            //                      join s in studios
            //                          on m.StudioName equals s.StudioName
            //                      where s.HQCity == "New York"
            //                      select m.Title;

            //foreach (var j in joinTitleStudio)
            //{
            //    Console.WriteLine(j);
            //}
            #endregion

            #region Example join 2
            //Console.WriteLine("Find filmtitler og filmens antal skuespillere på film der er lavet i et studio i New York");
            //var queryTitleMoviesFromNewYorkNoOfActors =
            //        from m in movies
            //        join s in studios on m.StudioName equals s.StudioName
            //        where s.HQCity == "New York"
            //        select new { MovieTitle = m.Title, NoOfActors = m.Actors.Count };

            //foreach (var v in queryTitleMoviesFromNewYorkNoOfActors)
            //{
            //    Console.WriteLine($"Title {v.MovieTitle}  No of actors {v.NoOfActors}");
            //}
            #endregion

            #region Example join 3
            //Console.WriteLine("List movies der er lavet fra et filmselskab fra New York og antallet af actors der starter med R");
            //var moviesNewYork = from m in movies
            //                    join s in studios
            //                        on m.StudioName equals s.StudioName
            //                    where s.HQCity == "New York"
            //                    select new
            //                    {
            //                        MoviesName = m.Title,
            //                        ProductionCity = s.HQCity,
            //                        numberOfActors = (from a in m.Actors
            //                                          where a.Name.StartsWith("R")
            //                                          select a).Count()
            //                    };

            //foreach (var m in moviesNewYork)
            //{
            //    Console.WriteLine($"Title {m.MoviesName}  City {m.ProductionCity} number of Actor with R {m.numberOfActors}");
            //}
            #endregion

            #region Example Fluent syntax example 1

            //List<int> numbers = new List<int> { 12, 37, 8, 17 };
            //IEnumerable<int> resultA = numbers.Where(i => i < 15);

            //foreach (var i in resultA)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine();

            //// Corresponding SQL-like LINQ query
            //IEnumerable<int> resultB = from i in numbers
            //                           where i < 15
            //                           select i;

            //foreach (var i in resultB)
            //{
            //    Console.WriteLine(i);
            //}


            #endregion

            #region SQL like <> Fluent syntax example 2
            //// Corresponding SQL-like LINQ query
            //var resultB = from m in movies
            //              select new { m.Title, m.Year };



            //foreach (var i in resultB)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine();

            #endregion

            #region Fluent syntax example 2
            //var resultA = movies.Select(m => new { m.Title, m.Year });

            //var resultA = movies.Select(m => new { m.Title, m.Year }).Where(m => m.Year > 1995);

            //var resultA = movies.Select(m => new { m.Title, m.Year })
            //    .Select(m => new { ShortYear = m.Year, m.Title })
            //    .Where(m => m.ShortYear > 1995)
            //    .Where(m => m.Title.Contains("Da"));

            //foreach (var i in resultA)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine();

            #endregion

            #region Combining Linq and Lambda
            Console.WriteLine("Define the query combining LINQ and Lambda expressions");
            // Define the query combining LINQ and Lambda expressions
            IEnumerable<string> titles4 = from m in movies.FindAll(m => m.Year > 1979)
                                          select m.Title;

            foreach (var element in titles4)
            {
                Console.WriteLine(element);
            }

            #endregion

        }
    }
}
