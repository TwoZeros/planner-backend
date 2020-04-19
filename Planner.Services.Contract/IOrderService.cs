using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Planner.Models;
using Planner.Services.Contract.Dto;

namespace Planner.Services.Contract
{
    public interface IOrderService
    {
        public Task<OrderDetailDto> GetById(int id);

        public List<OrderListDto> GetAll();

        public Task<string> Delete(int id);
        public Task AddOrder(Order comment);
        public void PutOrder(int id, Order comment);
    }
}
