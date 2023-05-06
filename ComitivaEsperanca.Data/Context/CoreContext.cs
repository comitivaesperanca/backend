using ComitivaEsperanca.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComitivaEsperanca.API.Data.Context
{
    public class CoreContext : DbContext
    {
        #region [DbSets]
        public DbSet<News>? News { get; set; }
        public DbSet<ClassifiedNews>? ClassifiedNews { get; set; }
        #endregion

        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }
    }
}
