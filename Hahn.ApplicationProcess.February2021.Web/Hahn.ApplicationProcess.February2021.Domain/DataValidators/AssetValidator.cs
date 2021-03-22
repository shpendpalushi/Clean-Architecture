using FluentValidation;
using Hahn.ApplicationProcess.February2021.Data.Core.Data;
using Hahn.ApplicationProcess.February2021.Data.HttpDataAccess;
using Hahn.ApplicationProcess.February2021.Data.HttpDataAccess._Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.DataValidators
{
    public class AssetValidator : AbstractValidator<SaveAssetDto>
    {
        private ICountryDataService _countryService;

        public AssetValidator(ICountryDataService countryService)
        {
            _countryService = countryService;
        }

        public ICountryDataService CountryService 
        {
            get
            {
                if(_countryService == null)
                {
                    _countryService = new CountryDataService(new System.Net.Http.HttpClient());
                }
                return _countryService;
            }
        }

        public AssetValidator()
        {
            RuleFor(asset => asset.AssetName).MinimumLength(5)
                .WithMessage("The name of the asset requires at least 5 characters")
                .MaximumLength(255)
                .WithMessage("You have reached the maximum length of 255 characters");
            RuleFor(asset => asset.Department).IsInEnum()
                .WithMessage("This is not a valid department");
            RuleFor(asset => asset.CountryOfDepartment)
                .MustAsync(async (countryName,cancellation) => await ValidateCountry(countryName))
                .WithMessage("Country is not valid");
            RuleFor(asset => asset.PurchaseDate)
                .Must(date => BeAValidDate(date))
                .WithMessage("The date you proivded is not in the desired range");
            RuleFor(asset => asset.EMailAdressOfDepartment)
                .EmailAddress()
                .WithMessage("Email address is invalid");
        }

        private async Task<bool> ValidateCountry(string countryName)
        {
            return await CountryService.IsCountryValid(countryName);
        }
        public bool BeAValidDate(DateTime date)
        {
            DateTime dateNow = DateTime.UtcNow;
            return IsDateDifferenceValid(dateNow, date);

        }
        private bool IsDateDifferenceValid(DateTime currentDate, DateTime oldDate)
        {
            return (currentDate - oldDate).TotalDays / 365 < 1 && (currentDate - oldDate).TotalDays / 365 > 0;
        }
    }
}
