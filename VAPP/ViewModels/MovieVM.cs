using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAPP.ViewModels
{
    public class MovieVM
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }
        public int NumberOfSeason { get; set; }
        public string Plot { get; set; }
        public string Cast { get; set; }
        public string Creator { get; set; }
        public int CategoryId { get; set; }
        public List<MovieSeasonVM> Seasons { get; set; }
    }
    public class MovieSeasonVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieSeasonEpisodeVM> episodes { get; set; }
    }
    public class MovieSeasonEpisodeVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public string Duration { get; set; }
        public string Plot { get; set; }
        public string Video { get; set; }
        public int SeasonId { get; set; }
    }
}
