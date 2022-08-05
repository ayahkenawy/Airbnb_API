using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API_Airbnb.Data.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<ArUsers>
    {
        public TokenDTO GetToken(List<Claim> claims);
        public SigningCredentials GetAlgorithmAndKey();


    }
}
