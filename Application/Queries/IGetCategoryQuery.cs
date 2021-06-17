using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetCategoryQuery : IQuery<CategorySearch, PagedResponse<CategoryDto>>
    {
    }
}
