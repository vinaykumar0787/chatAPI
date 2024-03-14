using ChatPostgreAPI.Dtos.Request;
using ChatPostgreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChatPostgreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ChatAPIDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, ChatAPIDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserPatchRequestDTO userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }

            var existingUser = await _context.Users.Where(usr => usr.PhoneNumber == userModel.PhoneNumber).FirstOrDefaultAsync();
            if (existingUser == null)
            {
                var newUser = new User
                {
                    PhoneNumber = userModel.PhoneNumber,
                    UserName = userModel.UserName,
                    CreatedAt = DateTime.UtcNow,
                    Disabled = false,
                    IsUserVerified = true,
                };
                await _context.Users.AddAsync(newUser);
            }
            else
            {
                existingUser.UserName = userModel.UserName;
                _context.Entry(existingUser).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateUser), new { Status = "Success" });
           
        }
    }
}
