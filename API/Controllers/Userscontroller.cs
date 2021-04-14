using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class Userscontroller : BaseApiController
    {
        private readonly DataContext _context;

        public Userscontroller(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetUsers() 
        {
            return await _context.Users.ToListAsync();   
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<AppUser> GetUser(int id) 
        {
            return await _context.Users.FindAsync(id);   
        }
    }
}