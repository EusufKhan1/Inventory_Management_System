using Inventory.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inventory.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContex dbContex;
        private readonly IConfiguration configuration;
        public UsersController(MyDbContex dbContex, IConfiguration configuration)
        {
            this.dbContex = dbContex;
            this.configuration = configuration;
        }
        /// <summary>
        /// This Api Created For User Registration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("registration")]
        public IActionResult Registration (User model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dbContex.Users.Add(new User
            {
                firstName = model.firstName,
                lastName = model.lastName,
                email = model.email,
                password = model.password
            });
            var output=dbContex.SaveChanges();

            return Ok("Registration Succefull!!");

        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(loginUser model)
        {
            
            var user = dbContex.Users.FirstOrDefault(x=>x.email == model.email && x.password==model.password);
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserId",user.userId.ToString()),
                    new Claim("Email",user.email.ToString()),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signIn=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn
                    );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new {Token=tokenValue, User=user});
                //return Ok(user);
            }
            return NoContent();

        }
        /// <summary>
        /// Get All User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get_user")]
        public IActionResult Getuser()
        {
          return Ok(dbContex.Users.ToList());
        }
        
        [HttpGet]
        [Route("edit_data_for_user")]
        public IActionResult GetEditDataById(int id)
        {
            var user=dbContex.Users.FirstOrDefault(x=>x.userId== id);
            if (user != null)
            {
                return Ok(user);
            }
            else return NoContent();
        }
    }
}
