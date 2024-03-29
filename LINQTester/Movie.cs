﻿using System.Collections.Generic;

namespace LINQTester
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int DurationInMins { get; set; }
        public string StudioName { get; set; }

        public List<Actor> Actors { get; set; }

        public Movie()
        {
        }
        public Movie(string title, int year, int durationInMins, string studioName)
        {
            Title = title;
            Year = year;
            DurationInMins = durationInMins;
            StudioName = studioName;

        }

        public override string ToString()
        {
            return $"{Title} {Year} {DurationInMins} {StudioName}";
        }
    }
}