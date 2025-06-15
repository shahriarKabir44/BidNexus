using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.DataProtection;

namespace BidNexus.Utils.JwtHandlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class JwtAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var token = context.HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            try
            {
                var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                var skey = config["Jwt:Key"]??"";
                var key = Encoding.UTF8.GetBytes(skey);
                var tokenHandler = new JwtSecurityTokenHandler();
                 tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "Id").Value;
                var fullName = jwtToken.Claims.First(x => x.Type == "FullName").Value;
                var username = jwtToken.Claims.First(x => x.Type == "UserName").Value;
                var UserTypeEnumId = jwtToken.Claims.First(x => x.Type == "UserTypeEnumId").Value;

                // Retrieve the user's profile data (for now, return dummy data)
                var profile = new Profile
                {
                    Id = int.Parse(userId),
                    FullName = fullName,
                    UserName = username,
                    UserTypeEnumId = byte.Parse(UserTypeEnumId)
                };
                context.HttpContext.Items["Profile"] = profile;
            }
            catch
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
