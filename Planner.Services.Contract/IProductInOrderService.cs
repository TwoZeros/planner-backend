using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Planner.Models;
using Planner.Services.Contract.Dto;

namespace Planner.Services.Contract
{
    public interface IProductInOrderService
    {
        public Task<ProductInOrderDetailDto> GetById(int id);

        public List<ProductInOrderListDto> GetAll();
        public Task<string> Delete(int id);

        public Task AddProductInOrder(ProductInOrder employee);

        public void PutProductInOrder(int id, ProductInOrder employee);
    }
}
