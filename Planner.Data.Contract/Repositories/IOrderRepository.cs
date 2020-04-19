using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Contract.Base;
using Planner.Models;

namespace Planner.Data.Contract.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetOrderInfo(int id);

        List<Order> GetListOrder();

        void PutOrder(Order order);

        public List<Order> GetListOrderWitnId(int id);
    }
}
