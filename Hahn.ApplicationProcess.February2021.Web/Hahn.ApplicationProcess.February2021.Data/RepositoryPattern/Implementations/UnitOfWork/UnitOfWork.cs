using Hahn.ApplicationProcess.February2021.Data.Core.Repositories;
using Hahn.ApplicationProcess.February2021.Data.Core.UnitOfWork;
using Hahn.ApplicationProcess.February2021.Data.Implementations.Repositories;
using Hahn.ApplicationProcess.February2021.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Data.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Assets = new AssetRepository(_context);
        }
        public IAssetRepository Assets { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
