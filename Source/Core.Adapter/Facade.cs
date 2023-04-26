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

        public abstract string SourceSystem { get; }

        public Facade(IEnumerable<IAdapter<TRequest, TResponse>> adapters)
        {
            this.adapters = adapters;
        }

        public Task<TResponse> Handle(TRequest request)
        {
            var relevantAdapter = this.adapters.FirstOrDefault(x => x.HandlesSourceSystem(this.SourceSystem));
            if (relevantAdapter != null)
            {
                return relevantAdapter.Handle(request);
            }
            else
            {
                throw new AdapterNotFoundException($"Adapter not found for source system: {this.SourceSystem}");
            }
        }


    }
}
