using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList;

namespace KnoKoFin.Application.Common.Interfaces.Dictionaries.ServiceTypes
{
    public interface IGetServiceTypeListService
    {
        Task<ServiceTypeList> GetAllServices();
    }
}