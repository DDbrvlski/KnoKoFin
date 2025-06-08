using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnoKoFin.Application.Services.Dictionaries.Services.Dtos;

namespace KnoKoFin.Application.Services.Dictionaries.Services.Interfaces
{
    public interface IGetTransactionServiceDetailsRepository
    {
        Task<TransactionServiceDetailsDto> GetTransactionServiceDetailsAsync(long id, CancellationToken cancellationToken);
    }
}
