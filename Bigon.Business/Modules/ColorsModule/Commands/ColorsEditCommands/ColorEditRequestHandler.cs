using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorsEditCommands
{
    internal class ColorEditRequestHandler(IColorRepository colorRepository) : IRequestHandler<ColorsEditRequest, Color>
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public async Task<Color> Handle(ColorsEditRequest request, CancellationToken cancellationToken)
        {
            var newColor = new Color
            {
                Id=request.Id,
                Name = request.Name,
                HexCode=request.HexCode,
            };
            _colorRepository.Edit(newColor);
            return newColor;

        }
    }
}
