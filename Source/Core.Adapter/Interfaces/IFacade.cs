using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Facade.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest">What model the facade handles as a request</typeparam>
    /// <typeparam name="TResponse">What model the facade returns as a response</typeparam>
    public interface IFacade<TRequest, TResponse>
    {
        public Task<TResponse> Handle(TRequest request, string? sourceSystem);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse">What model the facade returns as a response</typeparam>
    public interface IFacade<TResponse>
    {
        public Task<TResponse> Handle(string? sourceSystem);
    }
}
