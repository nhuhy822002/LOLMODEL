using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LOLMODEL.Models;

namespace LOLMODEL.Data
{
    public class LOLMODELContext : DbContext
    {
        public LOLMODELContext (DbContextOptions<LOLMODELContext> options)
            : base(options)
        {
        }

        public DbSet<LOLMODEL.Models.Lolmodel> Lolmodel { get; set; }
    }
}
