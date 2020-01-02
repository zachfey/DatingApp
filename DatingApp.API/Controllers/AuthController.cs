using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegsiterDTO)
        {

            userForRegsiterDTO.Username = userForRegsiterDTO.Username.ToLower();

            if (await _repo.UserExists(userForRegsiterDTO.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegsiterDTO.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegsiterDTO.Password);

            return StatusCode(201);
        } 
    }
}