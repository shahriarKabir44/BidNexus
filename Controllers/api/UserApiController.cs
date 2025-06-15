using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using BidNexus.Jsons;
using BidNexus.Jsons.Custom.Other;
using BidNexus.Models;
using BidNexus.Repository;
using BidNexus.Utils;
using BidNexus.Utils.ControllerBases;
using BidNexus.Utils.JwtHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BidNexus.Controllers.api
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class UserApiController : ApiBaseController
    {
        private readonly IConfiguration _config;

        public UserApiController(BidNexusContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }





        public class LoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("login")]
        public ApiResponse Login(LoginModel model)
        {
            var result = new ApiResponse();
            try
            {




                var jwtSettings = _config.GetSection("Jwt").Get<JwtSettings>();
                var key = Encoding.ASCII.GetBytes(jwtSettings.Key);


                var user = DbInstance.UserAccounts.FirstOrDefault(x => x.UserName == model.UserName);
                if (user == null)
                {
                    result.HasError = true;
                    result.ErrorMsg = "Invalid UserName!";
                    return result;
                }

                var salt = user.PasswordSalt;

                if (user.PasswordHash == model.Password.HashWithKey(salt))
                {
                    result.HasError = true;
                    result.ErrorMsg = "Incorrect Password!";
                    return result;
                }

                var jwtHelper = new JwtHelper(_config);

                var token = jwtHelper.GenerateToken(user);

                result.Extra = token;

            }
            catch (Exception e)
            {
                result.HasError = true;
                result.ErrorMsg = e.GetBaseException().Message;
            }

            return result;

        }
        [HttpPost("register")]
        public ApiResponse Register(UserAccountJson newUser)
        {
            var result = new ApiResponse();
            var error = "";
            try
            {
                using (var scope = DbInstance.Database.BeginTransaction())
                {
                    if (!IsValidUser(newUser, out error))
                    {
                        result.HasError = true;
                        result.ErrorMsg = error;
                        return result;
                    }

                    var entityReceived = new UserAccount();
                    newUser.Map(entityReceived);
                    var dbAddedUser = new UserAccount();
                    if (!SaveUserLogic(entityReceived, ref dbAddedUser, out error, newUser))
                    {
                        result.HasError = true;
                        result.ErrorMsg = error;
                        scope.Rollback();
                        return result;
                    }

                    DbInstance.SaveChanges();
                    scope.Commit();

                }


            }
            catch (Exception e)
            {
                result.HasError = true;
                result.ErrorMsg = error;
            }

            return result;
        }

        private bool SaveUserLogic(UserAccount userEntity, ref UserAccount dbAttachedUser, out string error, UserAccountJson json)
        {
            error = "";

            var newUser = Models.UserAccount.GetNew();
            DbInstance.UserAccounts.Add(newUser);

            newUser.UserName = userEntity.UserName;
            newUser.FullName = userEntity.FullName;
            newUser.Address = userEntity.Address;
            newUser.Email = userEntity.Email;
            newUser.UserTypeEnumId = userEntity.UserTypeEnumId;

            newUser.PasswordSalt = StringHelper.GenerateRandomAlphanumericString(10);
            newUser.PasswordSalt = json.Password.HashWithKey(newUser.PasswordSalt);


            dbAttachedUser = newUser;
            return true;
        }

        private bool IsValidUser(UserAccountJson user, out string error)
        {
            error = "";

            if (!user.UserName.IsValid())
            {
                error = "Invalid Username!";
                return false;
            }
            if (!user.Password.IsValid())
            {
                error = "Please Provide a password!";
                return false;
            }
            if (!user.RetypePassword.IsValid())
            {
                error = "Password Mismatch!";
                return false;
            }

            if (!user.Email.IsValidEmail())
            {
                error = "Invalid Email!";
                return false;

            }

            if (user.Id <= 0)
            {
                if (DbInstance.UserAccounts.Any(x => x.UserName == user.UserName))
                {
                    error = "Username Already Exists!";
                    return false;
                }
            }
            return true;
        }
    }




}
