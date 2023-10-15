using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace TestWebApp.Factories
{
    public class DbFactory
    {
        public static DataContext CreateDbContextForSQLite()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new DataContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            return context;
        }

    }
}
