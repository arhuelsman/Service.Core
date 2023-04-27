namespace Core.Service.Controller
{
    /// <summary>
    /// Interface for a service controller that does not require any sort of request
    /// </summary>
    /// <typeparam name="TResponse">The response model for the service</typeparam>
    public interface IController<TResponse>
    {
        /// <summary>
        /// The name of the service executing the request. Used for logging purposes.
        /// </summary>
        public string ServiceName { get; }

        /// <summary>
        /// Executes the request service request
        /// </summary>
        /// <returns>The response model to return</returns>
        public Task<TResponse> Execute();
    }

    /// <summary>
    /// Interface for a service controller that requires a request in order to process
    /// </summary>
    /// <typeparam name="TRequest">The request model for the service</typeparam>
    /// <typeparam name="TResponse">The response model for the service</typeparam>
    public interface IController<TRequest, TResponse>
    {
        /// <summary>
        /// The name of the service executing the request. Used for logging purposes.
        /// </summary>
        public string ServiceName { get; }

        /// <summary>
        /// Executes the request service request
        /// </summary>
        /// <param name="request">The request model to process</param>
        /// <returns>The response model to return</returns>
        public Task<TResponse> Execute(TRequest request);
    }
}
