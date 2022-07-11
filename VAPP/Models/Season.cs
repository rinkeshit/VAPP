using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAPP.Models
{
    public class Season:BaseEntity
    {
        public string Name { get; set; }
        public int MovieId { get; set; }
        public Movie movie { get; set; }
        public List<Episode> episodes { get; set; }
    }
}
