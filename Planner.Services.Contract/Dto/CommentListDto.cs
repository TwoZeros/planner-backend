using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;

namespace Planner.Services.Contract.Dto
{
    public class CommentListDto
    {
        public int Id { get; set; }
         public int ClientId { get; set; }
        public string CreateDate { get; set; }
        public string Text { get; set; }
        public string UserLogin { get; set; }
        public int Karma { get; set; }
    }
}
