using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAPP.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }
        public int NumberOfSeason { get; set; }
        public string Plot { get; set; }
        public string Cast { get; set; }
        public string Creator { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }

        public List<Season> seasons { get; set; }

    }
}
