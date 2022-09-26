using LoginHW.Base;

namespace LoginHW.Data
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<int> TotalRecordAsync();
        Task<Account> ValidateCredentialsAsync(TokenRequest loginResource);
        Task<Account> GetByIdAsync(int id, bool hasToken);
    }
}
