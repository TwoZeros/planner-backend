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
    public class ProductInOrderRepository : BaseRepository<Planner.Models.ProductInOrder>, IProductInOrderRepository
    {
        private readonly PlannerDbContext _context;
        public ProductInOrderRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ProductInOrder> GetProductInOrderInfo(int id)
        {
            return await _context.ProductInOrders.Include(p => p.Order)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public void PutProductInOrder(ProductInOrder employee)
        {
            _context.Entry(employee)
             .Property(i => i.OrderId).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.Quantity).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.Price).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.TotalPrice).IsModified = true;
        }

        public List<ProductInOrder> GetListProductInOrder()
        {
            return _context.ProductInOrders.Include(p => p.Order).Include(p => p.Product).ToList();
        }
    }
}
