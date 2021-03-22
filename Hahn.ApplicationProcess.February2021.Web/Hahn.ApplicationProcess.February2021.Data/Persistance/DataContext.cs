using Hahn.ApplicationProcess.February2021.Data.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Hahn.ApplicationProcess.February2021.Data.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<Asset> Assets { get; set; }
    }
}
