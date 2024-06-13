using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Queries.BlogGetByIdQuery
{
    public class BlogGetByIdRequest:IRequest<BlogGetByIdDto>
    {
        public int Id { get; set; }
    }
}
