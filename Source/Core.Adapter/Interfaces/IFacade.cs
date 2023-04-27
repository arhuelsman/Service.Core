using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Facade.Interfaces
{
    /// <summary>
    /// A facade for a service to send a request to an adapter, which handles the backend request
    /// </summary>
    /// <typeparam name="TRequest">What model the facade handles as a request</typeparam>
    /// <typeparam name="TResponse">What model the facade returns as a response</typeparam>
    public interface IFacade<TRequest, TResponse>
    {
        public Task<TResponse> Handle(TRequest request, string? sourceSystem);
    }

    /// <summary>
    /// A facade for a service to send a request to an adapter, which handles the backend request
    /// </summary>
    /// <typeparam name="TResponse">What model the facade returns as a response</typeparam>
    public interface IFacade<TResponse>
    {
        public Task<TResponse> Handle(string? sourceSystem);
    }
}
