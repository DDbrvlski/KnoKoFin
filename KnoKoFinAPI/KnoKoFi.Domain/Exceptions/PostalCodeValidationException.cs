using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Domain.Exceptions
{
    public class PostalCodeValidationException : Exception
    {
        public PostalCodeValidationException(string error) : base(error)
        {
            
        }
    }
}
