using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;

namespace Planner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInOrdersController : ControllerBase
    {
        private readonly PlannerDbContext _context;
        private readonly IProductInOrderService _productInOrdersService;
        public ProductInOrdersController(PlannerDbContext context, IProductInOrderService productInOrdersService)
        {
            _context = context;
            _productInOrdersService = productInOrdersService;
        }

        // GET: api/ProductInOrders
        [HttpGet]
        public List<ProductInOrderListDto> GetProductInOrders()
        {
            return _productInOrdersService.GetAll();
        }

        // GET: api/ProductInOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInOrder>> GetProductInOrder(int id)
        {
            var productInOrder = await _productInOrdersService.GetById(id);

            if (productInOrder == null)
            {
                return NotFound();
            }

            return new JsonResult(productInOrder);
        }

        // PUT: api/ProductInOrders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInOrder(int id, ProductInOrder productInOrder)
        {
            if (id != productInOrder.Id)
            {
                return BadRequest();
            }

            _productInOrdersService.PutProductInOrder(id, productInOrder);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInOrderExists(id))
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

        // POST: api/ProductInOrders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProductInOrder>> PostProductInOrder(ProductInOrder productInOrder)
        {
            await _productInOrdersService.AddProductInOrder(productInOrder);

            return CreatedAtAction("GetProductInOrder", new { id = productInOrder.Id }, productInOrder);
        }

        // DELETE: api/ProductInOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductInOrder(int id)
        {
            var productInOrder = await _productInOrdersService.Delete(id);
            if (productInOrder == "Not Found")
            {
                return NotFound();
            }

            return new JsonResult(productInOrder);
        }

        private bool ProductInOrderExists(int id)
        {
            return _context.ProductInOrders.Any(e => e.Id == id);
        }
    }
}
