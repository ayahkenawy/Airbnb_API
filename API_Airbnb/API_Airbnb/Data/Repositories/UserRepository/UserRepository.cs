using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API_Airbnb.Data.DTOs;

namespace API_Airbnb.Data.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<ArUsers>, IUserRepository
    {
        public readonly AirbnbContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(AirbnbContext context, IConfiguration configuration) : base(context)
        {
            _context = context;
            _configuration = configuration;
        }

        public TokenDTO GetToken(List<Claim> claims)
        {

            // Putting All Together
            var expires = DateTime.Now.AddMinutes(15);
            var jwt = new JwtSecurityToken(
                claims: claims,
                signingCredentials: GetAlgorithmAndKey(),
                expires: DateTime.Now.AddMinutes(15)
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            return  new TokenDTO
            {
                Token = tokenHandler.WriteToken(jwt),
                Expire = expires,
            };
        }
        public SigningCredentials GetAlgorithmAndKey()
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var byteKey = Encoding.ASCII.GetBytes(secretKey);
            var securityKey = new SymmetricSecurityKey(byteKey);
            var algorithmAndKey = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256);
            return algorithmAndKey;
        }


    }
}
