using KnoKoFin.Domain.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceDetails
{
    //public static class GetServiceDetailsQueryMapper
    //{
    //    public static async Task<ServiceDetailsDto> GetServiceDetails(IQueryable<DictionaryService> query, CancellationToken cancellationToken)
    //    {
    //        var serviceDetailsDto = await query.Select(x => new ServiceDetailsDto()
    //        {
    //            Id = x.Id,
    //            Name = x.Name,
    //            Description = x.Description,
    //            Discount = x.Discount,
    //            GrossPrice = x.GrossPrice,
    //            NetPrice = x.NetPrice,
    //            Quantity = x.Quantity,
    //            ServiceTypeName = x.ServiceType.Name,
    //            Unit = x.Unit,
    //            Vat = x.Vat,
    //        }).FirstOrDefaultAsync(cancellationToken);

    //        return serviceDetailsDto;
    //    }
    //}
}
