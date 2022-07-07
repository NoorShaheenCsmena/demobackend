using banner.Context;
using banner.DTO;
using banner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace banner.Controllers
{
    [Route("api/user"),ApiController,Authorize]
    public class UserManagementController : ControllerBase
    {
        private readonly BannersContext _context;
        private readonly IAccessTokenService _accessTokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        public UserManagementController(BannersContext context,IAccessTokenService accessTokenService,IRefreshTokenService refreshTokenService)
        {
            _context = context; 
            _accessTokenService = accessTokenService;   
            _refreshTokenService = refreshTokenService;
        }
        
        [HttpPost("Login"),AllowAnonymous] public IActionResult Login ([FromBody]LoginDTO user)
        {
            if (string.IsNullOrEmpty(user.Username)) return Forbid("You Didnt Provide Username");
            if (string.IsNullOrEmpty(user.Password)) return Forbid("You Didnt Provide Password");
            User selectedUser = _context.users.FirstOrDefault(i => i.Username == user.Username || i.Phone==user.Username||i.Email==user.Username);
            if (selectedUser == null) return NotFound("NotFound , You Can Sign UP");
            if (!BCrypt.Net.BCrypt.Verify(user.Password, selectedUser.Password)) return BadRequest("Invalid Credentials");
            return Ok(new AuthenticateResponse(){AccessToken=_accessTokenService.Generate(selectedUser),RefreshToken=_refreshTokenService.Generate(selectedUser)});
            //User selectedUser = _context.users.FirstOrDefault(i => i.Username == user.Username);
            //if (selectedUser == null) selectedUser=  _context.users.FirstOrDefault(i => i.Phone == user.Username);
            //if (selectedUser == null) selectedUser=  _context.users.FirstOrDefault(i => i.Email == user.Username);
        }
        [HttpGet] public IEnumerable<User> GetUsers() => _context.users.ToList();
        [HttpPost("add"),AllowAnonymous] public User AddUser(User user) { user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);var newUser = _context.users.Add(user); _context.SaveChanges(); return newUser.Entity; }
        [HttpDelete("{id}")] public User DeleteUser(Guid id) { User deleteUser = _context.users.FirstOrDefault(i => i.Id == id); _context.users.Remove(deleteUser); _context.SaveChanges(); return deleteUser; }
        [HttpPut] public User UpdateUser(User user) { var userToUpdate = _context.users.Update(user); _context.SaveChanges(); return userToUpdate.Entity; }
    }
}
