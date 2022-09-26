using LoginHW.Base;

namespace LoginHW.Service
{
    public interface ITokenManagementService
    {
        Task<BaseResponse<TokenResponse>> GenerateTokensAsync(TokenRequest loginResource, DateTime now, string userAgent);
    }
}
