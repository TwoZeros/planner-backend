using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Planner.Data.Contract.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Planner.Data.Repositories
{
    public class ClientRepository : BaseRepository<Planner.Models.Client>, IClientRepository
    {
        private readonly PlannerDbContext _context;
        public ClientRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Client> GetClientInfo(int id)
        {
            return await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public void PutClient(Client client)
        {
            _context.Entry(client)
             .Property(i => i.FullName).IsModified = true;
            _context.Entry(client)
                .Property(i => i.Email).IsModified = true;
            _context.Entry(client)
                .Property(i => i.PhoneNumber).IsModified = true;
            _context.Entry(client);
        }
        public void PutClientPhoto(Client Client)
        {
            _context.Entry(Client)
             .Property(i => i.Photo).IsModified = true;
        }
        


        public List<Client> GetListClient()
        {
            return  _context.Clients.ToList();
        }

    }
}
