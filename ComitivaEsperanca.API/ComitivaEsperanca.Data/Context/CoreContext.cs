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
        #endregion

        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }
    }
}
