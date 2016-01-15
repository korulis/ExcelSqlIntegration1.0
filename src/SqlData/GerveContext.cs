using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlData
{
    public class GerveContext : DbContext
    {
        public DbSet<MyDtoske> DataEntries { get; set; }

        public GerveContext(DbConnection dbConnection) : this(dbConnection, true) { }

        private GerveContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {
        }
    }
}
