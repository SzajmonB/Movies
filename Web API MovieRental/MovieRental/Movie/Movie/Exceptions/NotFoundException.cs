using System.Runtime.InteropServices;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NLog;
using Microsoft.Extensions.Logging;

namespace Movie.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
