using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.BillingTransactionServices.Commands.DeleteBillingTransactionService
{
    public class DeleteBillingTransactionServiceCommand : IRequest
    {
        public long Id { get; set; }
    }
}
