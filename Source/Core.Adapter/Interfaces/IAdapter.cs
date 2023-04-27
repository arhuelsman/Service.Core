namespace Core.Facade.Interfaces
{
    /// <summary>
    /// Adapter for a request to to route appropriately to a particular source
    /// </summary>
    /// <typeparam name="TRequest">The request this adapter handles</typeparam>
    /// <typeparam name="TResponse">The response this adapter returns</typeparam>
    public interface IAdapter<TRequest, TResponse>
    {
        public bool HandlesSourceSystem(string? sourceSystem);
        public Task<TResponse> Handle(TRequest request);
    }

    /// <summary>
    /// Adapter for a request to to route appropriately to a particular source
    /// </summary>
    /// <typeparam name="TResponse">The response this adapter returns</typeparam>
    public interface IAdapter<TResponse>
    {
        public bool HandlesSourceSystem(string? sourceSystem);
        public Task<TResponse> Handle();
    }
}