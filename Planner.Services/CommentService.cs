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
    class CommentService : ICommentService
    {
        public ICommentRepository _repo;

        private readonly ICommentDetailMapper _detailMapper;
        private readonly ICommentListMapper _listMapper;
        public CommentService(ICommentRepository repo, ICommentDetailMapper detailMapper, ICommentListMapper listMapper)
        {
            _detailMapper = detailMapper;
            _listMapper = listMapper;
            _repo = repo;
        }

        public async Task<CommentListDto> GetById(int id)
        {
            var comment = await _repo.GetCommentInfo(id);
            var commentDto = _detailMapper.Map<Comment, CommentListDto>(comment);

            return commentDto;
        }

        public List<CommentListDto> GetAll()
        {
            var comment = _repo.GetListComment();
            return _listMapper.Map<List<Comment>, List<CommentListDto>>(comment);
        }
        public List<CommentListDto> GetAllCommentsClient(int id)
        {
            var comment = _repo.GetClientComments(id);
            return _listMapper.Map<List<Comment>, List<CommentListDto>>(comment);
        }

        public async Task<string> Delete(int id)
        {
            var comment = await _repo.GetCommentInfo(id);
            if (comment != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";

        }
        public async Task AddComment(Comment comment)
        {
            comment.CreateDate = DateTime.Now;
            _repo.Add(comment);
            await _repo.SaveAsync();
        }

        public void PutComment(int id, Comment comment)
        {
            _repo.PutComment(comment);
        }

        public int GetRating(int id)
        {
            var comments = _repo.GetListCommentWitnId(id);
            if (comments.Count == 0)
            {
                return 0;
            }
            
            int karma = 0;
            foreach (var it in comments)
            {
                karma += it.Karma;
            }
            return karma;
            
        }
        public List<string> getDateAndRating()
        {
            var dates = _repo.GetDates();
            if (dates.Count == 0)
            {
                return null;
            }
            var ratings = new List<string>();
            foreach(var it in dates)
            {
                ratings.Add(it.ToString());
                ratings.Add(_repo.GetRatingByDate(it).ToString());
            }
            return ratings;
        }
    }
}
