using MiniOnlineShop.Application.Services.Commands.Dto;
using MiniOnlineShop.Common.BaseDto;
using MiniOnlineShop.Common.BaseInterfaces;


namespace MiniOnlineShop.Application.Services.Commands
{
    public interface IUserCommandService : IBaseCrudCommandService<long,
        UserUpdateInputDTO,
        UserDeleteInputDTO>
    {
        Task<ApiResult<LoginUserOutputDTO>> Signin(LoginUserInputDTO inputDTO);
        Task<ApiResult<RegisterUserOutputDTO>> Signup(RegisterUserInputDTO inputDTO);
    }
}
