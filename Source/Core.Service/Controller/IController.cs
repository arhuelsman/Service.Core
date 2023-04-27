namespace Core.Service.Controller
{
    public interface IController<TResponse>
    {
        public string ServiceName { get; }
        public Task<TResponse> Execute();
    }

    public interface IController<TRequest, TResponse>
    {
        public string ServiceName { get; }
        public Task<TResponse> Execute(TRequest request);
    }
}
