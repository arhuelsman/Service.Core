using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Core.Service.Controller
{
    /// <summary>
    /// Default implementation of a service. All services SHOULD inherit this class, but are not technically required to
    /// </summary>
    /// <typeparam name="TResponse">The response model for the service</typeparam>
    public abstract class ServiceController<TResponse> : IController<TResponse>
    {
        protected ILogger logger;

        public abstract string ServiceName { get; }

        public ServiceController(ILogger logger)
        {
            this.logger = logger;
        }

        public Task<TResponse> Execute()
        {
            var timer = new Stopwatch();
            try
            {
                this.logger.LogInformation($"{this.ServiceName} began execution");
                timer.Start();
                var result = this.OnExecute();
                timer.Stop();
                this.logger.LogInformation($"{this.ServiceName} ended execution after {timer.Elapsed.TotalMilliseconds} milliseconds");
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// What actually does the processing of Execute</cref>
        /// </summary>
        /// <returns>The response model for the service</returns>
        public virtual Task<TResponse> OnExecute()
        {
            return this.OnExecute(null);
        }

        public abstract Task<TResponse> OnExecute(string? SourceSystem);
    }

    /// <summary>
    /// Default implementation of a service. All services SHOULD inherit this class, but are not technically required to
    /// </summary>
    /// <typeparam name="TRequest">The request model for the service</typeparam>
    /// <typeparam name="TResponse">The response model for the service</typeparam>
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
            try
            {
                this.logger.LogInformation($"{this.ServiceName} began execution");
                timer.Start();
                var result = this.OnExecute(request);
                timer.Stop();
                this.logger.LogInformation($"{this.ServiceName} ended execution after {timer.Elapsed.TotalMilliseconds} milliseconds");
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// What actually does the processing of Execute</cref>
        /// </summary>
        /// <param name="request">The request model to be processed</param>
        /// <returns>The response model for the service</returns>
        public virtual Task<TResponse> OnExecute(TRequest request)
        {
            return this.OnExecute(request, null);
        }

        public abstract Task<TResponse> OnExecute(TRequest request, string? SourceSystem);
    }
}
