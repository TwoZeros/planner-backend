using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models;
using Planner.Dto.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using AutoMapper;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientController(PlannerDbContext context, IMapper mapper, IClientService clientService)
        {
            _context = context;
            _mapper = mapper;
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        public List<ClientListDto> GetClients()
        {
   
        return _clientService.GetAll();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClient(int id)
        {
            var client = await _clientService.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return new JsonResult(client);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientModel model)
        {
            if (id != model.Id)
                return BadRequest();
            Client client = _mapper.Map<ClientModel, Client>(model);
            _clientService.PutClient(id, client);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        [HttpPut("{id}/upload-avatar")]
        public async Task<IActionResult> PutClientPhoto(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest();

            _clientService.PutClientPhoto(id, client);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Client

        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientModel model)
        {
            Client client = _mapper.Map<ClientModel, Client>(model);
            await _clientService.AddClient(client);

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var status = await _clientService.Delete(id);
            if (status == "Not Found")
            {
                return NotFound();
            }
 
            return new JsonResult(status);
        }

        [HttpGet("getClientCountByDay")]
        public ClientsByDayDto GetClientCountByDay()
        {
            return _clientService.GetClientsAndDay();
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
