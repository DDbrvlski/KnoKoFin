using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Contractors
{
    public class GetContractorAddressIdDto
    {
        public long ContractorId { get; set; }
        public long? AddressId { get; set; }
    }
}
