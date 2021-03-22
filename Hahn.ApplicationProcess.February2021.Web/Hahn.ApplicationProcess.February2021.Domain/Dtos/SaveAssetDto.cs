using FluentValidation.Attributes;
using Hahn.ApplicationProcess.February2021.Data.Common.Enums;
using Hahn.ApplicationProcess.February2021.Domain.DataValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace Hahn.ApplicationProcess.February2021.Domain.Dtos
{
    public class SaveAssetDto
    {
        //public int Id { get; set; }
        [DefaultValue("DataTest1")]
        public string AssetName { get; set; }
        [DefaultValue(DepartmentTypeEnum.HQ)]
        public DepartmentTypeEnum Department { get; set; }
        [DefaultValue("test@test.com")]
        public string EMailAdressOfDepartment { get; set; }
        [DefaultValue("albania")]
        public string CountryOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; } 
        public bool Broken { get; set; } = false;
    }
}
