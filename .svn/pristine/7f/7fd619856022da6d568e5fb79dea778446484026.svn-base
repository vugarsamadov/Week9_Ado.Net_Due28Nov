using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI.ExceptionRelated
{
    internal static class ExceptionHelper
    {
        public static Exception EmployeeNotFoundException(int? id = null)
            => new Exception($"Employee with {id} is not found!");

        public static Exception CommandInvalidException(int? command = null)
            => new Exception($"Input command ({command}) is invalid!");

        public static Exception InputFormatInvalidException(string msg)
            => new Exception(msg);


    }
}
