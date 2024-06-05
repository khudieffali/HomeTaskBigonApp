using Bigon.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Queries.ColorsGetAllQuery
{
    public class ColorsGetAllRequest:IRequest<IEnumerable<Color>>
    {
    }
}
