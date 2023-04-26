using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Facade
{
    public class AdapterNotFoundException : Exception
    {
        public AdapterNotFoundException(string message) : base(message)
        {
        }
    }
}
