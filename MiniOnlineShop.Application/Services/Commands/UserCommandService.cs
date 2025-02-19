using Mani_Store.Common;
using MiniOnlineShop.Application.Interfaces.Context;
using MiniOnlineShop.Application.Services.Commands.Dto;
using MiniOnlineShop.Common.BaseDto;
using MiniOnlineShop.Domain.Entities.Users;
using System.Data;

namespace MiniOnlineShop.Application.Services.Commands
{
    public class UserCommandService : IUserCommandService
    {

        private readonly ICommandDbContext _context;

        #region [-Ctor-]
        public UserCommandService(ICommandDbContext context)
        {
            _context = context;
        }
        #endregion

        #region [-Signin()-]

        public async Task<ApiResult<LoginUserOutputDTO>> Signin(LoginUserInputDTO inputDTO)
        {
            try
            {
                var user = _context.Users
                .Where(p => p.Email.Equals(inputDTO.Email)
                && p.IsActive == true)
                .FirstOrDefault();

                if (user == null)
                {
                    return new ApiResult<LoginUserOutputDTO>
                    {
                        IsSuccess = false,
                        Message = "نام کاربری یا گذرواژه شما اشتباه است",
                    };
                }
                if (!user.IsActive)
                {
                    return new ApiResult<LoginUserOutputDTO>
                    {
                        IsSuccess = false,
                        Message = "حساب کاربری شما غیرفعال است لطفا به ادمین سایت پیام بدهید"
                    };
                }
                var passwordHasher = new PasswordHasher();
                bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Password, inputDTO.Password);
                if (resultVerifyPassword == false)
                {
                    return new ApiResult<LoginUserOutputDTO>()
                    {
                        Data = new LoginUserOutputDTO()
                        {

                        },
                        IsSuccess = false,
                        Message = "رمز وارد شده اشتباه است!",
                    };
                }
                return new ApiResult<LoginUserOutputDTO>
                {
                    Data = new LoginUserOutputDTO()
                    {
                        UserId = user.Id,
                        Email = inputDTO.Email,
                    },
                    IsSuccess = true,
                    Message = "ورود به سایت با موفقیت انجام شد",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region [-Signup()-]
        public async Task<ApiResult<RegisterUserOutputDTO>> Signup(RegisterUserInputDTO inputDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputDTO.Email))
                {
                    return new ApiResult<RegisterUserOutputDTO>()
                    {
                        Data = new RegisterUserOutputDTO()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "پست الکترونیک را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(inputDTO.FullName))
                {
                    return new ApiResult<RegisterUserOutputDTO>()
                    {
                        Data = new RegisterUserOutputDTO()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "لطفا نام را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(inputDTO.PhoneNumber))
                {
                    return new ApiResult<RegisterUserOutputDTO>()
                    {
                        Data = new RegisterUserOutputDTO()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "لطفا ایمیل را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(inputDTO.Password))
                {
                    return new ApiResult<RegisterUserOutputDTO>()
                    {
                        Data = new RegisterUserOutputDTO()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد کنید"
                    };
                }
                if (inputDTO.Password != inputDTO.RePassword)
                {
                    return new ApiResult<RegisterUserOutputDTO>()
                    {
                        Data = new RegisterUserOutputDTO()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }

                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(inputDTO.Password);

                User user = new User()
                {
                    Email = inputDTO.Email,
                    FullName = inputDTO.FullName,
                    Password = hashedPassword,
                    IsActive = true,
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return new ApiResult<RegisterUserOutputDTO>()
                {
                    Data = new RegisterUserOutputDTO()
                    {
                        UserId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام با موفقیت انجام شد",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [-SoftDelete()-]
        public async Task<ApiResult> SoftDelete(UserDeleteInputDTO inputDTO)
        {
            var user = _context.Users.Where(p => p.Id == inputDTO.Id).FirstOrDefault();
            if (user is null)
                return new ApiResult { IsSuccess = false, Message = "خطا" };
            user.IsRemoved = true;
            user.RemoveByUserId = inputDTO.RemoveByUserId;
            user.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "حذف با موفقیت انجام شد" };
        }
        #endregion

        #region [-Delete()-]
        public async Task<ApiResult> Delete(UserDeleteInputDTO inputDTO)
        {
            var user = _context.Users.Where(p => p.Id == inputDTO.Id).FirstOrDefault();
            if (user is null)
                return new ApiResult { IsSuccess = false, Message = "خطا" };

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "حذف با موفقیت انجام شد" };
        }
        #endregion

        #region [-Update()-]

        public async Task<ApiResult> Update(UserUpdateInputDTO inputDTO)
        {
            var user = _context.Users.Where(p => p.Id == inputDTO.Id).FirstOrDefault();
            if (user is null)
                return new ApiResult { IsSuccess = false, Message = "خطا" };

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Message = "به روز رسانی با موفقیت انجام شد" };
        }
        #endregion
    }
}
