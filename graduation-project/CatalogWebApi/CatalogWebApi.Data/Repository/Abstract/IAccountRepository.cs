﻿using CatalogWebApi.Base;

namespace CatalogWebApi.Data
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> ValidateCredentialsAsync(TokenRequest loginResource);
        Task<Account> GetByIdAsync(int id, bool hasToken);
        Task<Account> GetByEmailAsync(string username);
        Task<Account> GetByUsernameAsync(string username);
    }
}
