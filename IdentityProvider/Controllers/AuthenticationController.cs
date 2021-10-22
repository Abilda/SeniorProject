using IdentityProvider.Data;
using IdentityProvider.IServices;
using IdentityProvider.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProvider.Controllers
{
    public class AuthenticationController : Controller
    {
        private ITokenBuilder _tokenBuilder;
        private IdentityProvider_dbContext _dbContext;
        public AuthenticationController(ITokenBuilder tokenBuilder, IdentityProvider_dbContext dbContext)
        {
            _tokenBuilder = tokenBuilder;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]User user) 
        {
            var dbUser = await _dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Name == user.Name);
            if (dbUser == null)
            {
                return NotFound("User not found");
            }
            bool isValid = dbUser.Password == user.Password;
            if (!isValid)
            {
                return BadRequest("Couldn't authenticate user. Wrong credentials");
            }

            var token = _tokenBuilder.BuildToken(user.Name);
            return Ok(token);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody]User user)
        {
            foreach (var userInDb in _dbContext.Users)
            {
                string name = userInDb.Name;
            }
            var userFromDb = (await _dbContext.Users.SingleOrDefaultAsync(u => u.Name == user.Name));
            bool loginIsFree = userFromDb == null;
            if (!loginIsFree)
            {
                return BadRequest("Given username is busy");
            }
            user.Id = Guid.NewGuid();
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet("VerifyToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> VerifyToken()
        {
            var username = User
                .Claims
                .SingleOrDefault();

            if (username == null)
            {
                return Unauthorized();
            }

            var userExists = await _dbContext
                .Users
                .AnyAsync(u => u.Name == username.Value);

            if (!userExists)
            {
                return Unauthorized();
            }

            return NoContent();
        }

    }
}
