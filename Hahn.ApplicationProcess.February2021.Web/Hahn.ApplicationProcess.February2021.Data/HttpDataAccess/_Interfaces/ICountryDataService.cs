using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.HttpDataAccess._Interfaces
{
    public interface ICountryDataService
    {
        Task<bool> IsCountryValid(string countryname);
    }
}
