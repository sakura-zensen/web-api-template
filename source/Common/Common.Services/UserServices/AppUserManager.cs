using Common.Services.RequestDtos;
using Microsoft.AspNetCore.Identity;

namespace Common.Services.UserServices
{
    public partial class AppUserManager(UserManager<AppUser> userManager) : IAppUserManager
    {
        public async Task<ResponseDto<IdentityResult>> UpsertAsync(AppUserRequestDto userDto)
        {
            return new()
            {
                Succeeded = true,
                Data = await userManager.CreateAsync(new()
                {
                    Email = userDto.Email,
                    UserName = userDto.UserName,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    PhoneNumber = userDto.PhoneNumber,
                }, userDto.Password)
            };
        }
    }
}
