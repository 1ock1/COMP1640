using COMP1640.Auth;
using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(ILogger<UserController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IAuthRepository authRepository, 
            IUserRepository userRepository
        )
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _authRepository = authRepository;
            _userRepository = userRepository;
        }
        [HttpPost("login")]
        public async Task<ActionResult> SignIn(UserDTO userDTO)
        {
            bool isEmailExisted = await this._userRepository.CheckUserByEmail(userDTO.Email);
            Console.WriteLine(isEmailExisted);
            if (isEmailExisted==true)
            {
                var user = this._userRepository.GetUserInformation(userDTO);
                if(user != null)
                {
                    var token = _authRepository.GenerateCookieToken(user, _httpContextAccessor);
                    var result = new
                    {
                        jwt = token,
                        role = user.Role,
                    };
                    return StatusCode(200, result);
                }
            }
            return BadRequest();
        }
        [HttpPost("checkMultipleRole")]
        public ActionResult CheckMultipleRole(UserDTO userDTO) 
        {
            bool isMultipleRole = this._userRepository.IsMultipleRole(userDTO);
            return StatusCode(200, isMultipleRole);
        }
        [HttpPost("loginSelectedRole")]
        public async Task<ActionResult> SignInSelectedRole(UserMultipleRoleDTO userDTO)
        {
            bool isEmailExisted = await this._userRepository.CheckUserByEmail(userDTO.Email);
            Console.WriteLine(isEmailExisted);
            if (isEmailExisted == true)
            {
                UserDTO dto = new()
                {
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                };
                var user = this._userRepository.GetUserInformation(dto);
                if (user != null)
                {
                    var token = _authRepository.GenerateCookieTokenForSelectedRole(user, userDTO.RoleSelected);
                    var result = new
                    {
                        jwt = token,
                        role = userDTO.RoleSelected,
                    };
                    return StatusCode(200, result);
                }
            }
            return BadRequest();
        }
        [HttpPost("signup")]
        public async Task<ActionResult> CreateAccount(UserSignUpDTO user)
        {
            var result = await _userRepository.CreateAccount(user);
            return StatusCode(200, result);
        }
        [HttpPost("checkEmail")]
        public async Task<ActionResult> CheckEmail(string email)
        {
            var result = await _userRepository.CheckUserByEmail(email);
            return StatusCode(200, result);
        }
        [Authorize(Roles = "STUDENT, ADMIN, COORDINATOR, GUEST, MANAGER")]
        [HttpPost("auth")]
        public async Task<ActionResult> CheckAuth(TokenDTO token)
        {
            var result = await this._authRepository.CheckRole(token.Token);
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return StatusCode(200, new
            {
                id=-1,
                role="UNAUTHORIZED"
            }); ;
        }
    }
}
