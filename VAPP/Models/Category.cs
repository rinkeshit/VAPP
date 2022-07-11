using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAPP.Models
{
    public class Category:BaseEntity
    {
        public string Title { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
