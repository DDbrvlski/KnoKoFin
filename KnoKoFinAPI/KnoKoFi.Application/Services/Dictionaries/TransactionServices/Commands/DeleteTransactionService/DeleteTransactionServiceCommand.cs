using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Commands.DeleteTransactionService
{
    public class DeleteTransactionServiceCommand : IRequest
    {
        public long Id { get; set; }
    }
}
