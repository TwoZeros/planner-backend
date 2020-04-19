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
    public class ProductRepository : BaseRepository<Planner.Models.Product>, IProductRepository
    {
        private readonly PlannerDbContext _context;

        public ProductRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductInfo(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }
        public void PutProduct(Product product)
        {
            _context.Entry(product)
                .Property(i => i.Name).IsModified = true;
            _context.Entry(product)
                .Property(i => i.Price).IsModified = true;
        }
        public List<Product> GetListProduct()
        {
            return _context.Products.ToList();
        }
    }
}
