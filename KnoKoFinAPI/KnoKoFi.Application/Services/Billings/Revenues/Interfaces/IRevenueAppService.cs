using KnoKoFin.Application.Services.Billings.Revenues.Commands.CreateRevenue;
using KnoKoFin.Application.Services.Billings.Revenues.Commands.DeleteRevenue;
using KnoKoFin.Domain.Entities.Billings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Revenues.Interfaces
{
    public interface IRevenueAppService
    {
        Task ArchiveRevenueAsync(DeleteRevenueCommand request, CancellationToken cancellationToken);
        Task<Revenue> CreateRevenueAsync(CreateRevenueCommand request, CancellationToken cancellationToken);
    }
}
