using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.BL.Abstract;
using Northwind.Entites.Sakila;
using NorthWind.Api.Models;

namespace NorthWind.Api.Controllers
{

    /*
     * Burada Route yapilandirmasinda domain'den sonra mutlaka api ,
     * sonrasinda controller ve ardindan action gelmek zorundadir.
     * 
     * 
     */
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController(IManager<SakilaContext,User> userManager) : ControllerBase
    {

        [HttpPost()]
        public async Task<Token> Login(UserLogin userLogin)
        {
            //var user = context.Users.Where(p => p.Email == userLogin.Email && p.Password == userLogin.Password).FirstOrDefault();
            var user = await userManager.GetByAsync(p=>p.Email==userLogin.Email && p.Password==userLogin.Password);

            if (user != null)
            {
                TokenManager tokenManager = new TokenManager();
                Token token = await tokenManager.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expration;
                await userManager.UpdateAsync(user);
                
                return token;
            }
            return null;
        }
        [HttpPost()]
        public async Task<Token?> LoginWithRefreshToken(string refreshToken)
        {
            Token token = new();
            var user = await userManager.GetByAsync(p=>p.RefreshToken==refreshToken);
            if (user != null) 
            {
                TokenManager tokenManager = new TokenManager();
                 token = await tokenManager.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expration;
                await userManager.UpdateAsync(user);

                
            }
            return token;
        }
    }
}
