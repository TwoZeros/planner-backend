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
    class OrderService : IOrderService
    {
        public IOrderRepository _repo;

        private readonly IOrderDetailMapper _detailMapper;
        private readonly IOrderListMapper _listMapper;

        public OrderService(IOrderRepository repo, IOrderDetailMapper detailMapper, IOrderListMapper listMapper)
        {
            _detailMapper = detailMapper;
            _listMapper = listMapper;
            _repo = repo;
        }

        public async Task<OrderDetailDto> GetById(int id)
        {
            var comment = await _repo.GetOrderInfo(id);
            var commentDto = _detailMapper.Map<Order, OrderDetailDto>(comment);

            return commentDto;
        }
        public List<OrderListDto> GetAll()
        {
            var order = _repo.GetListOrder();
            return _listMapper.Map<List<Order>, List<OrderListDto>>(order);
        }

        public async Task<string> Delete(int id)
        {
            var order = await _repo.GetOrderInfo(id);
            if (order != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task AddOrder(Order order)
        {
            order.DateCreate = DateTime.Now;
            _repo.Add(order);
            await _repo.SaveAsync();
        }

        public void PutOrder(int id, Order order)
        {
            _repo.PutOrder(order);
        }

    }
}
