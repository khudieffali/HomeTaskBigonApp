using Bigon.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.CategoriesModule.Commands.CategoryAddCommands
{
    public class CategoryAddRequest:IRequest<Category>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
    }
}
