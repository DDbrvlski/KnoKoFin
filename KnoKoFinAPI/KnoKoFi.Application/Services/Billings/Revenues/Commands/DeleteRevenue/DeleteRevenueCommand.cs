using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Revenues.Commands.DeleteRevenue
{
    public class DeleteRevenueCommand : IRequest
    {
        public long Id { get; set; }
    }
}
