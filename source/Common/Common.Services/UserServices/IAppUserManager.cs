using Common.Services.RequestDtos;
using Microsoft.AspNetCore.Identity;

namespace Common.Services.UserServices
{
    public interface IAppUserManager
    {
        Task<ResponseDto<IdentityResult>> UpsertAsync(AppUserRequestDto userDto);
    }
}