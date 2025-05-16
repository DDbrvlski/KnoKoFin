using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Queries.GetAddressDetails
{
    public interface IGetAddressDetailsRepository
    {
        Task<AddressDetailsDto> GetAddressDetailsAsync(long id, CancellationToken cancellationToken);
    }
}
