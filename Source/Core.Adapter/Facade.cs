using Core.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Facade
{
    public abstract class Facade<TRequest, TResponse> : IFacade<TRequest, TResponse>
    {
        private readonly IEnumerable<IAdapter<TRequest, TResponse>> adapters;

        public Facade(IEnumerable<IAdapter<TRequest, TResponse>> adapters)
        {
            this.adapters = adapters;
        }

        public Task<TResponse> Handle(TRequest request, string? sourceSystem)
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

    public abstract class Facade<TResponse> : IFacade<TResponse>
    {
        private readonly IEnumerable<IAdapter<TResponse>> adapters;

        public Facade(IEnumerable<IAdapter<TResponse>> adapters)
        {
            this.adapters = adapters;
        }

        public Task<TResponse> Handle(string? sourceSystem)
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
