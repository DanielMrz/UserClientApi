using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserClientApi.Entities;
using UserClientApi.Model;

namespace UserClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClientController : ControllerBase
    {
        private readonly DataContext _context;
        public UserClientController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserClient>>> GetUsers()
        {
            return Ok(await _context.UserClients.ToListAsync());

            //return new List<UserClient>
            //{ 
            //    new UserClient
            //    {
            //        NickName = "TestowyNick01",
            //        FirstName = "User",
            //        LastName = "One",
            //        Email = "example@gmail.com",
            //        City = "Wrocław"
            //    }
            //};
        }

        [HttpPost]
        public async Task<ActionResult<List<UserClient>>> CreateUser(UserClient user)
        {
            _context.UserClients.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserClients.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<UserClient>>> UpdateUser(UserClient user)
        {
            var dbUser = await _context.UserClients.FindAsync(user.Id);
            if (dbUser == null)
                return BadRequest("Nie znaleziono użytkownika :(");

            dbUser.NickName = user.NickName;
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.City = user.City;
            dbUser.Email = user.Email;

            await _context.SaveChangesAsync();
            return Ok(await _context.UserClients.ToListAsync());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<UserClient>>> DeleteUser(int id)
        {
            // sprawdzenie czy id jest poprawne
            var dbUser = await _context.UserClients.FindAsync(id);
            if (dbUser == null)
                return BadRequest("Nie znaleziono użytkownika :(");

            _context.UserClients.Remove(dbUser);
            await _context.SaveChangesAsync();
            return Ok(await _context.UserClients.ToListAsync());
        }
    }
}
