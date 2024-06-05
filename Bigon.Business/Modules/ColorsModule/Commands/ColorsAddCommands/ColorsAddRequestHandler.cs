using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorsAddCommands
{
    internal class ColorsAddRequestHandler(IColorRepository colorRepository) : IRequestHandler<ColorsAddRequest, Color>
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public async Task<Color> Handle(ColorsAddRequest request, CancellationToken cancellationToken)
        {
            Color newColor = new()
            {
                Name=request.Name,
                HexCode=request.HexCode
            };
           await  _colorRepository.Add(newColor);
            return newColor;

        }
    }
}
