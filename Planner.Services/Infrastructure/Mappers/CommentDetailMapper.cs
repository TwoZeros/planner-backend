using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{

    public interface ICommentDetailMapper : IModelMapper<CommentDetailDto, Comment>
    {
    }

    public class CommentDetailMapper : AbstractModelMapper<CommentDetailDto, Comment>, ICommentDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentDetailDto, Comment>();

                cfg.CreateMap<Comment, CommentDetailDto>()
                .ForMember(x => x.UserLogin, s => s.MapFrom(x => x.User.Login));
            });

            return config.CreateMapper();
        }
    }
}
