using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;

namespace Planner.Services
{
    public class ProductInOrderService : IProductInOrderService
    {
        public IProductInOrderRepository _repo;

        private readonly IProductInOrderDetailMapper _detailMapper;
        private readonly IProductInOrderListMapper _listMapper;
        public ProductInOrderService(IProductInOrderRepository repo, IProductInOrderDetailMapper detailMapper, IProductInOrderListMapper listMapper)
        {
            _detailMapper = detailMapper;
            _listMapper = listMapper;
            _repo = repo;

        }
        
        public async Task<ProductInOrderDetailDto> GetById(int id)
        {
            var productInOrder = await _repo.GetProductInOrderInfo(id);
            var productInOrderDto = _detailMapper.Map<ProductInOrder, ProductInOrderDetailDto>(productInOrder);

            return productInOrderDto;
        }

        public List<ProductInOrderListDto> GetAll()
        {
            var productInOrder = _repo.GetListProductInOrder();
            return _listMapper.Map<List<ProductInOrder>, List<ProductInOrderListDto>>(productInOrder);
        }

        public async Task<string> Delete(int id)
        {
            var productInOrder = await _repo.GetProductInOrderInfo(id);
            if (productInOrder != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";

        }
        public async Task AddProductInOrder(ProductInOrder productInOrder)
        {
            _repo.Add(productInOrder);
            await _repo.SaveAsync();
        }

        public void PutProductInOrder(int id, ProductInOrder productInOrder)
        {
            _repo.PutProductInOrder(productInOrder);
        }
     
    }
}
