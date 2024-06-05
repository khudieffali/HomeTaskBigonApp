using Bigon.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorsAddCommands
{
    public class ColorsAddRequest:IRequest<Color>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
