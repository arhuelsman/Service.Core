namespace Core.Facade.Interfaces
{
    public interface IAdapter<TRequest, TResponse>
    {
        public bool HandlesSourceSystem(string sourceSystem);
        public Task<TResponse> Handle(TRequest request);
    }
}