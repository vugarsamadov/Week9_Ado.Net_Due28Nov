using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov27Practice.Helpers
{
    internal static class ExceptionHelper
    {
        public static Exception InputFormatInvalidException(string msg)
            => new Exception(msg);
    }
}
