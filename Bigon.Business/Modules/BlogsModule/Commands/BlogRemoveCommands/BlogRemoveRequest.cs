using Bigon.Business.Modules.BlogsModule.Queries.BlogGetAllQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Commands.BlogRemoveCommands
{
    public class BlogRemoveRequest:IRequest<IEnumerable<BlogGetAllDto>>
    {
        public int Id { get; set; }
    }
}
