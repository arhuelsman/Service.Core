using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Controller
{
    public interface IController
    {
        public string ServiceName { get; set; }
        public IServiceResult Execute();
    }

    public interface IController<T> where T : class
    {
        public string ServiceName { get; set; }
        public IServiceResult Execute(T request);
    }
}
