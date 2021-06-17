using Application;
using Application.DTO;
using Application.Queries;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries
{
    public interface IGetPostQuery : IQuery<PostSearch, PagedResponse<PostDto>>
    {
    }
}
