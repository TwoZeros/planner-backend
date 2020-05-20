using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;

namespace Planner.Data.Repositories
{
    public class CommentRepository : BaseRepository<Planner.Models.Comment>, ICommentRepository
    {
        private readonly PlannerDbContext _context;

        public CommentRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Comment> GetCommentInfo(int id)
        {
            return await _context.Comments.Include(p => p.Client).Include(p=>p.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public List<Comment> GetListComment()
        {
            return _context.Comments.Include(p => p.Client).Include(p => p.User).ToList();
        }
       public List<Comment> GetClientComments(int id)
        {
            return _context.Comments.Include(p => p.Client).Include(p=>p.User).Where(p=>p.ClientId==id).ToList();
        }
        public void PutComment(Comment сomment)
        {
            _context.Entry(сomment)
                .Property(i => i.Text).IsModified = true;
            _context.Entry(сomment)
                .Property(i => i.CreateDate).IsModified = true;
            _context.Entry(сomment)
                .Property(i => i.Karma).IsModified = true;
        }
        public List<Comment> GetListCommentWitnId(int id)
        {
            return _context.Comments.Where(p => p.ClientId == id).ToList();
        }
        public int GetRatingByDate(DateTime date)
        {
            var comments = _context.Comments.Where(p => p.CreateDate.Date == date.Date).ToList();
            if (comments.Count == 0)
            {
                return 0;
            }
            int rating = 0;
            foreach (var it in comments)
            {
                rating += it.Karma;
            }
            return rating;
        }
        public List<DateTime> GetDates()
        {
            return _context.Comments.Select(p => p.CreateDate.Date).Distinct().OrderBy(p => p.Date).ToList();
        }
    }
}