using Hahn.ApplicationProcess.February2021.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Data.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAssetRepository Assets { get;  }
        int Complete();
    }
}
