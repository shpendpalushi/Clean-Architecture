using Hahn.ApplicationProcess.February2021.Data.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Data.Core.Repositories
{
    public interface IAssetRepository : IRepository<Asset>
    {
        IEnumerable<Asset> GetTopAssets(int count);
    }
}
