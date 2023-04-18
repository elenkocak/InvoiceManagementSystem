using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.BLL.Constants;
using InvoiceManagementSystem.Core.Entities.Concrete;
using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.Core.Security;
using InvoiceManagementSystem.DAL.Abstract;
using InvoiceManagementSystem.DAL.Concrete.Context;
using InvoiceManagementSystem.Entity.Dtos;
using InvoiceManagementSystem.Entity.Dtos.UserDtos;
using PhoneNumbers;
using Snickler.EFCore;
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
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserDal _userDal;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserDal userDal)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userDal = userDal;
        }

        public IDataResult<bool> ChangeUserPassword(ChangePasswordWithDto changePasswordWithDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> CreateToken(User user)
        {
            try
            {
                var token = _tokenHelper.CreateNewToken(user);
                var accessToken = new AccessToken();
                using (var context=new ImsDbContext())
                {
                    context.LoadStoredProc("dbo.proc_CreateToken")
                        .WithSqlParam("userId", token.UserId)
                        .WithSqlParam("tokenString", token.TokenString)
                        .WithSqlParam("userAgent", token.UserAgent)
                        .WithSqlParam("ip", token.Ip)
                        .ExecuteStoredProc((handler) =>
                        {
                            var data = handler.ReadToList<AccessToken>().FirstOrDefault();
                            accessToken = data;
                        });
                }
                if (accessToken==null)
                {
                    return new ErrorDataResult<AccessToken>(new AccessToken(), "Generate Token Failed", Messages.generate_token_failed);
                }
                return new SuccessDataResult<AccessToken>(accessToken, "token created", Messages.success);

            }
            catch (Exception e)
            {

                return new ErrorDataResult<AccessToken>(null, e.Message, Messages.unknown_err);

            }
        }

        public IDataResult<SecuritiesResponseDto> Login(UserLoginDto userLoginDto)
        {
            var userToCheck = _userService.Get(x => x.Email == userLoginDto.Email);
            if (userToCheck.Data==null)
            {
                return new ErrorDataResult<SecuritiesResponseDto>(null, "user not found", Messages.user_not_found);
            }
            if (userToCheck != null)
            {
                if (userToCheck.Data.Status==false)
                {
                    return new ErrorDataResult<SecuritiesResponseDto>(null, "user is not active", Messages.user_not_active);
                }
            }
            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password,userToCheck.Data.PasswordSalt, userToCheck.Data.PasswordHash ))
            {
                return new ErrorDataResult<SecuritiesResponseDto>(null, "password is wrong", Messages.user_wrong_password);
            }

            userToCheck.Data.SecurityCode = RandomString(15);
            _userService.UpdateBasic(userToCheck.Data);
            SecuritiesResponseDto getToken = new();
            return new SuccessDataResult<SecuritiesResponseDto>(getToken,  getToken.Token.ToString(), Messages.success); /////çalışmayadabilir
        }

        public static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length) //belirtilen bir nesneyi belirtilen sayıda kez içeren bir IEnumerable koleksiyonu oluşturur. Yani, bu metodu kullanarak bir karakter dizisini veya başka bir nesneyi belirtilen sayıda tekrarlayarak yeni bir koleksiyon oluşturabilirsin

              .Select(s => s[random.Next(s.Length)]).ToArray()); // koleksiyondaki her bir karakteri, koleksiyonun uzunluğu içinde rasgele bir karakter seçerek değiştirir. //ToArray() ifadesi, koleksiyonu karakter dizisine dönüştürür.
        }

        public IDataResult<bool> RegisterForAdmin(UserRegisterAdminstratorDto userRegisterAdminstratorDto)
        {
            try
            {
                if (!userRegisterAdminstratorDto.Email.Contains("@"))
                {
                    return new ErrorDataResult<bool>(false, "Lütfen geçerli bir e-posta giriniz", Messages.invalid_email); 
                }
                PhoneNumberUtil phoneUtil=PhoneNumberUtil.GetInstance(); //Bu class singletondur.Yani tek bir örnek oluşturmayı sağlar o yüzden getinstance kullanılmalı
                PhoneNumber phoneNumber = phoneUtil.Parse(userRegisterAdminstratorDto.PhoneNumber, "TR");

                if (!phoneUtil.IsValidNumber(phoneNumber))
                {
                    return new ErrorDataResult<bool>(false, "Invalid PhoneNumber", Messages.)
                }
                byte[] passworsalt, passwordhash;
                var createPasswordBySystem = RandomString(6);
                HashingHelper.CreatePasswordHash(createPasswordBySystem, out passworsalt, out passwordhash);

                var user = new User
                {
                    Name = userRegisterAdminstratorDto.Name,
                    Surname = userRegisterAdminstratorDto.SurName,
                    Email = userRegisterAdminstratorDto.Email,
                    RegistrationDate = DateTime.Now,
                    Status = true,
                    PhoneNumber = userRegisterAdminstratorDto.PhoneNumber,
                    TcNo = userRegisterAdminstratorDto.TcNo,
                };
                _userDal.Add(user);
                return new SuccessDataResult<bool>(true, "Kayıt başarıyla oluşturuldu", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);
            }
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
