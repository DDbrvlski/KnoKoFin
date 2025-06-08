using KnoKoFin.Application.Services.Dictionaries.Services.Dtos;
using KnoKoFin.Application.Services.Dictionaries.Services.Queries.GetServiceDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Interfaces
{
    public interface IGetTransactionServiceListRepository
    {
        Task<TransactionServiceListDto> GetTransactionServiceListAsync(CancellationToken cancellationToken);
    }
}
