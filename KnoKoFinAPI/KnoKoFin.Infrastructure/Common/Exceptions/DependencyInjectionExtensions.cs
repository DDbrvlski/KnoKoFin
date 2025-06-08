using KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using KnoKoFin.Infrastructure.Repositories.Billings;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Contractors;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.ServiceTypes;
using KnoKoFin.Infrastructure.Repositories.Invoices;
using Microsoft.Extensions.DependencyInjection;

namespace KnoKoFin.Infrastructure.Common.Exceptions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //#region Billings
            //services.AddScoped<IExpensePositionRepository, ExpensePositionRepository>();
            //services.AddScoped<IExpenseRepository, ExpenseRepository>();
            //services.AddScoped<IRevenuePositionRepository, RevenuePositionRepository>();
            //services.AddScoped<IRevenueRepository, RevenueRepository>();
            //services.AddScoped<IServiceRepository, BillingServiceRepository>();
            //#endregion

            #region Dictionaries
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IDictionaryContractorRepository, DictionaryContractorRepository>();
            //services.AddScoped<IServiceRepository, DictionaryServiceRepository>();
            services.AddScoped<ITransactionServiceTypeRepository, TransactionServiceTypeRepository>();
            //services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            #endregion

            //#region Invoices
            //services.AddScoped<IInvoiceContractorRepository, InvoiceContractorRepository>();
            //services.AddScoped<IContractorRepository, InvoiceMetadataRepository>();
            //services.AddScoped<IContractorRepository, InvoiceRepository>();
            //#endregion

            return services;
        }
    }
}
