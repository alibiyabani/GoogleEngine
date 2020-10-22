using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoogleEngine.Models;

namespace GoogleEngine.Data
{
    public class GoogleEngineContext : DbContext
    {
        public GoogleEngineContext (DbContextOptions<GoogleEngineContext> options)
            : base(options)
        {
        }

        public DbSet<GoogleEngine.Models.Search> Search { get; set; }
        public DbSet<GoogleEngine.Models.Result> Result { get; set; }
    }
}
