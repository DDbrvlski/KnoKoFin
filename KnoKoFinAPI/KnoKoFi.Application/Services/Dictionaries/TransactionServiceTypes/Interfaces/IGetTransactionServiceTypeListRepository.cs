using KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Dtos;
using KnoKoFin.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.TransactionServiceTypes.Interfaces
{
    public interface IGetTransactionServiceTypeListRepository
    {
        Task<TransactionServiceTypeListDto> GetTransactionServiceTypeList(CancellationToken cancellationToken);
    }
}
