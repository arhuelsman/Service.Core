namespace Core.Domain
{
    public interface IServiceRequest<T>
    {
        public string RequestMessage { get; set; }

        public T GetRequest();
    }
}