using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Common.Exceptions
{
    public class UpdateFailureException : Exception
    {
        public UpdateFailureException(string name, object key, string message)
            : base($"Wystąpił problem podczas modyfikowania encji \"{name}\" ({key}). {message}") { }
    }
}
