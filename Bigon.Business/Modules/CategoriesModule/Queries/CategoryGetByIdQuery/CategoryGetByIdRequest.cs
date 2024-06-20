using Bigon.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    public class CategoryGetByIdRequest:IRequest<CategoryGetByIdDto>
    {
        public int Id { get; set; }
    }
}
