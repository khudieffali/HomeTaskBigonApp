using Bigon.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Commands.TagsEditCommands
{
    public class TagsEditRequest:IRequest<Tag>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
