using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_brasileira_se.Models;
using api_brasileira_se.Data;

namespace api_brasileira_se.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> Get()
        {
            return await _context.Estados.OrderBy(e => e.Nome).ToListAsync();
        }
    }
}