using Hahn.ApplicationProcess.February2021.Data.Core.Data;
using Hahn.ApplicationProcess.February2021.Data.Core.Repositories;
using Hahn.ApplicationProcess.February2021.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Data.Implementations.Repositories
{
    public class AssetRepository : Repository<Asset>, IAssetRepository
    {
        public AssetRepository(DataContext context) : base(context)
        {

        }

        public IEnumerable<Asset> GetTopAssets(int count)
        {
            throw new NotImplementedException();
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
