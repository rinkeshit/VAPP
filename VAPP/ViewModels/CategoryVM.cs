using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAPP.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<MoviePosterVM> movies { get; set; }
    }

    public class MoviePosterVM
    {
        public int Id { get; set; }
        public string Poster { get; set; }

    }
}
