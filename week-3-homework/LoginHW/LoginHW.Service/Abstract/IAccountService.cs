using LoginHW.Base;
using LoginHW.Data;
using LoginHW.Dto;

namespace LoginHW.Service
{
    public interface IAccountService : IBaseService<AccountDto, Account>
    {
        Task<BaseResponse<AccountDto>> SelfUpdateAsync(int id, AccountDto resource);
        Task<BaseResponse<AccountDto>> UpdatePasswordAsync(int id, UpdatePasswordRequest resource);
    }
}
