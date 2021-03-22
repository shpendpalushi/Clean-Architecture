using Hahn.ApplicationProcess.February2021.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Data.Core.Data
{
    public class Asset
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public DepartmentTypeEnum Department { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public string CountryOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; } = false;
    }
}
