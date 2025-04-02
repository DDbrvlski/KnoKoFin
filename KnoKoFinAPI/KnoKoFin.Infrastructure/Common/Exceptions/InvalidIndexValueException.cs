using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Common.Exceptions
{
    public class InvalidIndexValueException : Exception
    {
        public string EntityName { get; }
        public object Key { get; }
        public string? ErrorDetails { get; }

        public InvalidIndexValueException(string name, object key, string? error)
            : base($"ID podanej encji \"{name}\" ({key}) jest błędne. Error: {error}")
        {
            EntityName = name;
            Key = key;
            ErrorDetails = error;
        }
    }
}
