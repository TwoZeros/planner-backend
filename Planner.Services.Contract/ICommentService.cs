using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Models;
using Planner.Services.Contract.Dto;

namespace Planner.Services.Contract
{
    public interface ICommentService
    {
        public Task<CommentListDto> GetById(int id);

        public List<CommentListDto> GetAll();
        
        public List<CommentListDto> GetAllCommentsClient(int id);
        public Task<string> Delete(int id);
        public Task AddComment(Comment comment);

        public void PutComment(int id, Comment comment);

        public int GetRating(int id);
    }
}
