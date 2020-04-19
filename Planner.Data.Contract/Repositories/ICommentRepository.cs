using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Contract.Base;
using System.Linq;
using Planner.Models;

namespace Planner.Data.Contract.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<Comment> GetCommentInfo(int id);

        List<Comment> GetListComment();

        void PutComment(Comment сomment);

        public List<Comment> GetListCommentWitnId(int id);

    }
}