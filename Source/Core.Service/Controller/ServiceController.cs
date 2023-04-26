using Core.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Controller
{
    public abstract class ServiceController : IController
    {
        private ILogger logger;

        public abstract string ServiceName { get; set; }

        public ServiceController(ILogger logger)
        {
            this.logger = logger;
        }

        public IServiceResult Execute()
        {
            var timer = new Stopwatch();
            this.logger.LogInformation($"{this.ServiceName} began execution");
            timer.Start();
            var result = this.OnExecute();
            timer.Stop();
            this.logger.LogInformation($"{this.ServiceName} ended execution after {timer.Elapsed.TotalMilliseconds} milliseconds");
            return result;
        }

        public abstract IServiceResult OnExecute();
    }

    public abstract class ServiceController<T> : IController<T> where T : class
    {
        private ILogger logger;

        public ServiceController(ILogger logger)
        {
            this.logger = logger;
        }

        public abstract string ServiceName { get; set; }

        public IServiceResult Execute(T request)
        {
            var timer = new Stopwatch();
            this.logger.LogInformation($"{this.ServiceName} began execution");
            timer.Start();
            var result = this.OnExecute(request);
            timer.Stop();
            this.logger.LogInformation($"{this.ServiceName} ended execution after {timer.Elapsed.TotalMilliseconds} milliseconds");
            return result;
        }

        public abstract IServiceResult OnExecute(T request);
    }
}
