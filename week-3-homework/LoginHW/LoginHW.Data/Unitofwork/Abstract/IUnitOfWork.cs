namespace LoginHW.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
