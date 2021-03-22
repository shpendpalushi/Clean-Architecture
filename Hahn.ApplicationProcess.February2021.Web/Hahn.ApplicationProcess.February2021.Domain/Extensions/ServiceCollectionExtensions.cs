using AutoMapper;
using Hahn.ApplicationProcess.February2021.Data.Core.Repositories;
using Hahn.ApplicationProcess.February2021.Data.Core.UnitOfWork;
using Hahn.ApplicationProcess.February2021.Data.HttpDataAccess;
using Hahn.ApplicationProcess.February2021.Data.HttpDataAccess._Interfaces;
using Hahn.ApplicationProcess.February2021.Data.Implementations.Repositories;
using Hahn.ApplicationProcess.February2021.Data.Implementations.UnitOfWork;
using Hahn.ApplicationProcess.February2021.Data.Persistence;
using Hahn.ApplicationProcess.February2021.Domain.Implementations;
using Hahn.ApplicationProcess.February2021.Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCountryService(this IServiceCollection services)
        {
            services.AddHttpClient<ICountryDataService, CountryDataService>(request =>
            {
                request.BaseAddress = new Uri("https://restcountries.eu/rest/v2/name/");
            });
        }
        public static void AddRepositoryPatternService(this IServiceCollection services)
        {
            services.AddScoped<IAssetRepository, AssetRepository>();
        }
        public static void AddInMemoryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("HahnAplication"));
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddAssetProvider(this IServiceCollection services)
        {
            services.AddScoped<IAssetProvider, AssetProvider>();
        }

        public static void AddAutoMapperConig(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AssetSaveProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddMvc();
        }
    }
}
