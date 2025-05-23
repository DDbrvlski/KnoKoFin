using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Dto;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Interfaces
{
    public interface IGetAddressDetailsRepository
    {
        Task<AddressDetailsDto> GetAddressDetailsAsync(long id, CancellationToken cancellationToken);
    }
}
