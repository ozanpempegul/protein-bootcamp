namespace cacheHW.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
