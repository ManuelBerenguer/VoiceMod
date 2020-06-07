using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VoiceMod.Common.Dispatchers;
using VoiceMod.Users.Core.Dtos;
using VoiceMod.Users.Core.Messages.Commands;
using VoiceMod.Users.Core.Queries;

namespace VoiceMod.Users.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IConfiguration _config;

        public UsersController(IDispatcher dispatcher, IConfiguration config) : base(dispatcher) 
        {
            _config = config;
        }

        [HttpGet("{id}", Name = "Get")]
        [Authorize]
        public async Task<ActionResult<UserDto>> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Single(await QueryAsync(new GetUser { Id = id }));
        }

        [AllowAnonymous]
        [HttpPost("~/login")]
        public async Task<IActionResult> Login(AuthenticateUser authenticateUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IActionResult response = Unauthorized();

            var user = await SendAsync(authenticateUser);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(UserDto userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Generate list of claims with general and universally recommended claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        //[Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateUser createUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await SendAsync(createUser);

            return CreatedAtRoute("Get", new { id = user.Id }, user);            
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(UpdateUser updateUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await SendAsync(updateUser);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await SendAsync(new DeleteUser { Id = id });

            // A successful response of DELETE requests should be HTTP response code 200 (OK) if the response includes an entity describing the status, 
            // 202 (Accepted) if the action has been queued, 
            // or 204 (No Content) if the action has been performed but the response does not include an entity.
            return NoContent();
        }
    }
}
