using Bigon.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Commands.TagsAddCommands
{
    public class TagsAddRequest:IRequest<Tag>
    {
        public string Name { get; set; }
    }
}
