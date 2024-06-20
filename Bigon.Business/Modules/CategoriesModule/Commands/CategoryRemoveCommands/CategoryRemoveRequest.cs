using Bigon.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.CategoriesModule.Commands.CategoryRemoveCommands
{
    public class CategoryRemoveRequest:IRequest<IEnumerable<Category>>
    {
        public int Id { get; set; }
    }
}
