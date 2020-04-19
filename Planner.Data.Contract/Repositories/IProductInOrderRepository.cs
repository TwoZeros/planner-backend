using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Contract.Base;
using Planner.Models;

namespace Planner.Data.Contract.Repositories
{
    public interface IProductInOrderRepository : IBaseRepository<ProductInOrder>
    {
        List<ProductInOrder> GetListProductInOrder();
        Task<ProductInOrder> GetProductInOrderInfo(int id);
        void PutProductInOrder(ProductInOrder employee);
    }
}
