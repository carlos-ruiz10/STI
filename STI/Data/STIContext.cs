using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STI.Models;

namespace STI.Models
{
    public class STIContext : DbContext
    {
        public STIContext (DbContextOptions<STIContext> options)
            : base(options)
        {
        }

        public DbSet<STI.Models.curso> curso { get; set; }

        public DbSet<STI.Models.temas_curso> temas_curso { get; set; }
    }
}
