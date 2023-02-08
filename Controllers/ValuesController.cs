using aPi_AC.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace aPi_AC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration configuration;

        public ValuesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }




        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register(UserDto userDto)
        {
            CreatePasswordHas(userDto.Password, out byte[] passwordHash, out byte[] salt);
            user.Username = userDto.Username;
            user.PasswordHash = passwordHash;
            user.PassswordSalt = salt;
            return Ok(user);

        }

        private void CreatePasswordHas(string password, out byte[] passwordHash, out byte[] salt)
        {

            using (var hmac = new HMACSHA512())
            {

                salt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            CreatePasswordHas(request.Password, out byte[] passwordHash, out byte[] salt);
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PassswordSalt = salt;

            if (request.Username != user.Username)
            {
                return BadRequest(401);
            }

            if (!verifyPasswordHas(request.Password, user.PasswordHash, user.PassswordSalt))
            {
                return BadRequest(401);

            }

            if (request.Username != "SeñorC")
            {
                return BadRequest(401);
            }


            Register(request);

            string token = createToken(user);

            return Ok(token);
        }


        private string createToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now,
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);




            return jwt;

        }

        private bool verifyPasswordHas(string password, byte[] passwordHas, byte[] passwordsSalt)
        {
            using (var hmac = new HMACSHA512(user.PassswordSalt))
            {
                var computedhas = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedhas.SequenceEqual(passwordHas);
            }
        }


    }
}
