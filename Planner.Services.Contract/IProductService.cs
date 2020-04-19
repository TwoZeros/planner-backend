using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Planner.Models;
using Planner.Services.Contract.Dto;

namespace Planner.Services.Contract
{
    public interface IProductService
    {
        public Task<ProductDetailDto> GetById(int id);

        public List<ProductListDto> GetAll();
        public Task<string> Delete(int id);

        public Task AddProduct(Product product);

        public void PutProduct(int id, Product product);
    }
}
