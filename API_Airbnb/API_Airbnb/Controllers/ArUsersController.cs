using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Airbnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArUsersController : ControllerBase
    {
        private readonly IUserRepository _usersRepository;
        private readonly UserManager<ArUsers> _userManager;

        public ArUsersController(IUserRepository usersRepository, UserManager<ArUsers> userManager)
        {
            _usersRepository = usersRepository;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginDTO credentials)
        {
            var requiredUser = await _userManager.FindByEmailAsync(credentials.Email);
            if (requiredUser == null) return NotFound(new {Message="Not Found"});
            if (_userManager.IsLockedOutAsync(requiredUser).Result)
            {
                return BadRequest(new {Message= "User Is Locked"});
            }
            if (requiredUser.Status==false)
            {
                requiredUser.Status = true;
                var result = await _userManager.UpdateAsync(requiredUser);
            }
            
            var isAuth = await _userManager.CheckPasswordAsync(requiredUser, credentials.Password);
            if (!isAuth) return Unauthorized(new {Message="Wrong Password"});
            #region Generate Token
            var claims = await _userManager.GetClaimsAsync(requiredUser) as List<Claim>;

            #endregion
            return Ok(_usersRepository.GetToken(claims));
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {
            var user = new ArUsers
            {
                UserName = $"{registerDTO.FirstName}{registerDTO.LastName}",
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Status = true,
                UserType = registerDTO.UserType,

            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await _userManager.AddClaimsAsync(user, new List<Claim>
            {
                 new Claim(ClaimTypes.Role, registerDTO.UserType == true ? "host" : "user"),
                 new Claim(ClaimTypes.NameIdentifier, user.Id),
                 new Claim(ClaimTypes.Email, registerDTO.Email),
            });
            return StatusCode(StatusCodes.Status201Created, new {Message= "User Created Successfully" });
        }
        [Authorize]
        [HttpPut]
        [Route("ChangePassword")]

        public async Task<ActionResult> ChangePassword(ChangePasswordDTO changePassword)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId is null)
            {
                return NotFound(new {Message= "User not Exist" });
            }
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var result = await _userManager.ChangePasswordAsync(currentUser, changePassword.OldPassword, changePassword.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Failed To Change Password" });
            }
            return Ok(StatusCode(StatusCodes.Status202Accepted, new { Message = "Password Updated" }));
        }
        [Authorize]
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update(ArUserDTO arUserDTO)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId is null)
            {
                return NotFound(new { Message = "User not Exist" });
            }
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var oldEmail = currentUser.Email;
            currentUser.UserName = $"{arUserDTO.FirstName}{arUserDTO.LastName}";
            currentUser.FirstName = arUserDTO.FirstName;
            currentUser.LastName = arUserDTO.LastName;
            currentUser.Email = arUserDTO.Email;
            currentUser.Modified = DateTime.Now;
            currentUser.DateOfBirth = arUserDTO.DateOfBirth;
            currentUser.FacebookId = arUserDTO.FacebookId;
            currentUser.TwitterId = arUserDTO.TwitterId;
            currentUser.About = arUserDTO.About;

            var result = await _userManager.UpdateAsync(currentUser);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Failed To Update User" });
            }
            if (oldEmail != arUserDTO.Email)
            {
                var oldClaims = await _userManager.GetClaimsAsync(currentUser);
                var oldClaim = oldClaims.Where(c => c.Type.EndsWith("emailaddress")).FirstOrDefault();
                var resultUpdateClaim = await _userManager.ReplaceClaimAsync(currentUser, oldClaim, new Claim(ClaimTypes.Email, arUserDTO.Email));
                if (!resultUpdateClaim.Succeeded)
                {
                    return BadRequest(new { Message = "Failed To Update Claims" });
                }
            }

            return Ok(StatusCode(StatusCodes.Status202Accepted, new { Message = "User Updated" }));
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Delete()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId is null)
            {
                return NotFound(new { Message = "User not Exist" });
            }
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            currentUser.Status = false;
            var result = await _userManager.UpdateAsync(currentUser);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Couldn't Delete User" });
            }

            return Ok(StatusCode(StatusCodes.Status202Accepted, new { Message = "User Deleted" }));
        }

        [Authorize]
        [HttpGet]
        [Route("GetByEmail/{Email}")]
        public async Task<ActionResult> GetByEmail(string Email)
        {
            var getUserByEmail = await _userManager.FindByEmailAsync(Email);
            if (getUserByEmail is null)
            {
                return NotFound(new { Message = "User not Exist" });
            }
            if (getUserByEmail.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)|| User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                return Ok(getUserByEmail);
            }
            return Ok(StatusCode(StatusCodes.Status401Unauthorized, new { Message = "You Don't Have Access" }));
            
        }
        [Authorize]
        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult> GetUser()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var getUserByEmail = await _userManager.FindByEmailAsync(userEmail);
            if (getUserByEmail is null)
            {
                return NotFound(new { Message = "User not Exist" });
            }
            if (getUserByEmail.Id == User.FindFirstValue(ClaimTypes.NameIdentifier) || User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                return Ok(getUserByEmail);
            }
            return Ok(StatusCode(StatusCodes.Status401Unauthorized, new { Message = "You Don't Have Access" }));

        }
        [Authorize]
        [HttpGet]
        [Route("GetById/{Id}")]
        public async Task<ActionResult> GetById(string Id)
        {
            var getUserById = await _userManager.FindByIdAsync(Id);
            if (getUserById is null)
            {
                return NotFound(new { Message = "User not Exist" });
            }
            if (getUserById.Status == false)
            {
                return NotFound(new { Message = "User not Exist" });
            }
            return Ok(getUserById);
        }

        [Authorize(Policy = "admin")]
        [HttpGet]
        public ActionResult GetAllUser()
        {
            var getAllUsers = _userManager.Users.Where(s=>s.Status==true).ToList();
            if (getAllUsers is null)
            {
                return NotFound(new { Message = "There Are No Users" });
            }

            return Ok(getAllUsers);
        }

    }
}
