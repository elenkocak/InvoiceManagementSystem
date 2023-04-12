using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.BLL.Constants;
using InvoiceManagementSystem.Core.Entities.Concrete;
using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.Core.Security;
using InvoiceManagementSystem.Entity.Dtos;
using InvoiceManagementSystem.Entity.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<bool> ChangeUserPassword(ChangePasswordWithDto changePasswordWithDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> CreateToken(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<SecuritiesResponseDto> Login(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<bool> RegisterForAdmin(UserRegisterAdminstratorDto userRegisterAdminstratorDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> UserExists(UserRegisterAdminstratorDto userRegisterDto)
        {
            try
            {

                var checkEmail = _userService.GetUserByMail(userRegisterDto.Email);
                if (checkEmail.Success)
                {
                    return new ErrorDataResult<User>(null, "Bu maille daha önce kayıt oluşturulmuş", Messages.already_mail_registered);
                }
                var checkPhone = _userService.GetUserByPhone(userRegisterDto.PhoneNumber);
                if (checkPhone.Success)
                {
                    return new ErrorDataResult<User>(null, "Bu telefon numarasıyla daha önce kayıt oluşturulmuş", Messages.already_phone_number_exists);
                }
                return new SuccessDataResult<User>(null, "Kayıt başarıyla oluşturuldu", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<User>(null, e.Message, Messages.unknown_err);

            }
        }
    }
}
