using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

namespace SqlData
{
    public class GerveSqlRepository
    {
        private GerveContext _context;

        public GerveSqlRepository(DbContext dbContext)
        {
            _context = (GerveContext)dbContext;
            Database.SetInitializer(new GerveInitializer());


            //new GerveContext(sqlConnection);
            //context.Database.Initialize(false);
            var fgg = new ObservableCollection<MyDtoske>(_context.DataEntries);
        }


    }
}
