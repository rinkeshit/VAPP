using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAPP.Models
{
    public class Episode : BaseEntity
    {
        public string Title { get; set; }
        public string Poster { get; set; }
        public string Duration { get; set; }
        public string Plot { get; set; }
        public string Video { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
