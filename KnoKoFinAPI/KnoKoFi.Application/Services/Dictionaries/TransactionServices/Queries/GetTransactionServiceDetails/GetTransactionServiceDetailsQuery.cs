using KnoKoFin.Application.Services.Dictionaries.TransactionServices.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Queries.GetTransactionServiceDetails
{
    public class GetTransactionServiceDetailsQuery : IRequest<TransactionServiceDetailsDto>
    {
        public long Id { get; set; }
    }
}
