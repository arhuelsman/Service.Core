using Core.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Facade
{
    /// <summary>
    /// Abstract implementation of a facade, which is
    /// a facade for a service to send a request to an adapter, which handles the backend request
    /// </summary>
    /// <typeparam name="TRequest">What model the facade handles as a request</typeparam>
    /// <typeparam name="TResponse">What model the facade returns as a response</typeparam>
    public abstract class Facade<TRequest, TResponse> : IFacade<TRequest, TResponse>
    {
        private readonly IEnumerable<IAdapter<TRequest, TResponse>> adapters;

        public Facade(IEnumerable<IAdapter<TRequest, TResponse>> adapters)
        {
            this.adapters = adapters;
        }

        /// <summary>
        /// Takes in the request, and routes it to the appropriate adapter
        /// </summary>
        /// <param name="request">The request model to route</param>
        /// <param name="sourceSystem">The source system this request will be handled from</param>
        /// <returns>The result of the request being handled</returns>
        /// <exception cref="AdapterNotFoundException">When the source system is not handled by any adapter</exception>
        public virtual Task<TResponse> Handle(TRequest request, string? sourceSystem)
        {
            var relevantAdapter = this.adapters.FirstOrDefault(x => x.HandlesSourceSystem(sourceSystem));
            if (relevantAdapter != null)
            {
                return relevantAdapter.Handle(request);
            }
            else
            {
                throw new AdapterNotFoundException($"Adapter not found for source system: {sourceSystem}");
            }
        }
    }

    /// <summary>
    /// Abstract implementation of a facade, which is
    /// a facade for a service to send a request to an adapter, which handles the backend request
    /// </summary>
    /// <typeparam name="TResponse">What model the facade returns as a response</typeparam>
    public abstract class Facade<TResponse> : IFacade<TResponse>
    {
        private readonly IEnumerable<IAdapter<TResponse>> adapters;

        public Facade(IEnumerable<IAdapter<TResponse>> adapters)
        {
            this.adapters = adapters;
        }

        /// <summary>
        /// Takes in the request, and routes it to the appropriate adapter
        /// </summary>
        /// <param name="sourceSystem">The source system this request will be handled from</param>
        /// <returns>The result of the request being handled</returns>
        /// <exception cref="AdapterNotFoundException">When the source system is not handled by any adapter</exception>
        public virtual Task<TResponse> Handle(string? sourceSystem)
        {
            var relevantAdapter = this.adapters.FirstOrDefault(x => x.HandlesSourceSystem(sourceSystem));
            if (relevantAdapter != null)
            {
                return relevantAdapter.Handle();
            }
            else
            {
                throw new AdapterNotFoundException($"Adapter not found for source system: {sourceSystem}");
            }
        }
    }
}
