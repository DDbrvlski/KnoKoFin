using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Queries.GetServiceTypeList;
using KnoKoFin.Domain.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Queries.GetTransactionServiceList
{
    //public static class GetServiceListQueryMapper
    //{
    //    public static async Task<ServiceList> GetServiceList(IQueryable<DictionaryService> queryToMap, CancellationToken cancellationToken)
    //    {
    //        var items = await queryToMap
    //        .Select(x => new ServiceDto
    //        {
    //            Id = x.Id,
    //            Name = x.Name,
    //            Description = x.Description,
    //            ServiceTypeName = x.ServiceType.Name
    //        })
    //        .ToListAsync(cancellationToken);

    //        return new ServiceList() { Services = items };
    //    }
    //}
}
