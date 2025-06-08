using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnoKoFin.Application.Services.Dictionaries.TransactionServices.Dtos;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServices.Interfaces
{
    public interface IGetTransactionServiceDetailsRepository
    {
        Task<TransactionServiceDetailsDto> GetTransactionServiceDetailsAsync(long id, CancellationToken cancellationToken);
    }
}
