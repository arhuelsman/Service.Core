using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Core.Service.Controller
{
    public abstract class ServiceController<TResponse> : IController<TResponse>
    {
        protected ILogger logger;

        public abstract string ServiceName { get; }

        public ServiceController(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task<TResponse> Execute()
        {
            var timer = new Stopwatch();
            this.logger.LogInformation($"{this.ServiceName} began execution");
            timer.Start();
            var result = await this.OnExecute();
            timer.Stop();
            this.logger.LogInformation($"{this.ServiceName} ended execution after {timer.Elapsed.TotalMilliseconds} milliseconds");
            return result;
        }

        public virtual Task<TResponse> OnExecute()
        {
            return this.OnExecute(null);
        }

        public abstract Task<TResponse> OnExecute(string? SourceSystem);
    }

    public abstract class ServiceController<TRequest, TResponse> : IController<TRequest, TResponse>
    {
        protected ILogger logger;

        public ServiceController(ILogger logger)
        {
            this.logger = logger;
        }

        public abstract string ServiceName { get; }

        public Task<TResponse> Execute(TRequest request)
        {
            var timer = new Stopwatch();
            this.logger.LogInformation($"{this.ServiceName} began execution");
            timer.Start();
            var result = this.OnExecute(request);
            timer.Stop();
            this.logger.LogInformation($"{this.ServiceName} ended execution after {timer.Elapsed.TotalMilliseconds} milliseconds");
            return result;
        }

        public virtual Task<TResponse> OnExecute(TRequest request)
        {
            return this.OnExecute(request, null);
        }

        public abstract Task<TResponse> OnExecute(TRequest request, string? SourceSystem);
    }
}
