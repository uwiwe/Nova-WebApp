using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nova_WebApp.Server.Data;
using Nova_WebApp.Server.Models;
using Nova_WebApp.Server.DTOs.Users;
using AutoMapper;

namespace Nova_WebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Nova_WebAppServerContext _context;
        private readonly IMapper _mapper;

        public UsersController(Nova_WebAppServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOutputDto>>> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            var userDtos = _mapper.Map<List<UserOutputDto>>(users); // Mapea la entidad a DTO
            return Ok(userDtos);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOutputDto>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserOutputDto>(user); // Mapea la entidad a DTO
            return Ok(userDto);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserInputDto userInputDto)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(userInputDto, user); // Mapea el DTO a la entidad existente
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserOutputDto>> PostUser(UserInputDto userInputDto)
        {
            var user = _mapper.Map<User>(userInputDto);
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            var userOutputDto = _mapper.Map<UserOutputDto>(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, userOutputDto);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}

//namespace Nova_WebApp.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly Nova_WebAppServerContext _context;

//        public UsersController(Nova_WebAppServerContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Users
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<User>>> GetUser()
//        {
//            return await _context.User.ToListAsync();
//        }

//        // GET: api/Users/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<User>> GetUser(int id)
//        {
//            var user = await _context.User.FindAsync(id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            return user;
//        }

//        // PUT: api/Users/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutUser(int id, User user)
//        {
//            if (id != user.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(user).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!UserExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Users
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<User>> PostUser(User user)
//        {
//            _context.User.Add(user);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetUser", new { id = user.Id }, user);
//        }

//        // DELETE: api/Users/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteUser(int id)
//        {
//            var user = await _context.User.FindAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            _context.User.Remove(user);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool UserExists(int id)
//        {
//            return _context.User.Any(e => e.Id == id);
//        }
//    }
//}