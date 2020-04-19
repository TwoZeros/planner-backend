using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;

namespace Planner.Data.Repositories
{
    public class OrderRepository : BaseRepository<Planner.Models.Order>, IOrderRepository
    {
        private readonly PlannerDbContext _context;
        public OrderRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Order> GetOrderInfo(int id)
        {
            return await _context.Orders.Include(p => p.Client).Include(p => p.User).Include(p => p.StatusOrder)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }
        public List<Order> GetListOrder()
        {
            return _context.Orders.Include(p => p.Client).Include(p => p.User).Include(p => p.StatusOrder).ToList();
        }

        public void PutOrder(Order order)
        {
            _context.Entry(order)
                .Property(i => i.Name).IsModified = true;
            _context.Entry(order)
                .Property(i => i.DateCreate).IsModified = true;
        }
        public List<Order> GetListOrderWitnId(int id)
        {
            return _context.Orders.Where(p => p.StatusId == id).ToList();
        }
    }
}
