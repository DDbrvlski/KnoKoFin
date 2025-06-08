using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingServices.Commands.DeleteBillingService
{
    public class DeleteBillingTransactionServiceCommand : IRequest
    {
        public long Id { get; set; }
    }
}
