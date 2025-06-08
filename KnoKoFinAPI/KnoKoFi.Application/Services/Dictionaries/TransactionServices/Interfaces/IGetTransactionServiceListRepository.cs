using KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceDetails;
using KnoKoFin.Application.Services.Dictionaries.TransactionServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Interfaces
{
    public interface IGetTransactionServiceListRepository
    {
        Task<TransactionServiceListDto> GetTransactionServiceListAsync(CancellationToken cancellationToken);
    }
}
