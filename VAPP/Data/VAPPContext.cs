using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VAPP.Models;

namespace VAPP.Data
{
    public class VAPPContext : DbContext
    {
        public VAPPContext (DbContextOptions<VAPPContext> options)
            : base(options)
        {
        }

        public DbSet<VAPP.Models.Category> Category { get; set; }

        public DbSet<VAPP.Models.Movie> Movie { get; set; }

        public DbSet<VAPP.Models.Season> Season { get; set; }

        public DbSet<VAPP.Models.Episode> Episode { get; set; }
    }
}
