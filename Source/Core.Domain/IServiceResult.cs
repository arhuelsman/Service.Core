namespace Core.Domain
{
    public interface IServiceResult
    {
        public bool Result { get; set; }
        public string ResultMessage { get; set; }
    }
}