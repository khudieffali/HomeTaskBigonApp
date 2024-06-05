using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorsDeleteCommands
{
    internal class ColorsDeleteHandlerRequest(IColorRepository colorRepository) : IRequestHandler<ColorsDeleteRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public async Task<IEnumerable<Color>> Handle(ColorsDeleteRequest request, CancellationToken cancellationToken)
        {
         var color= await  _colorRepository.GetById(x=>x.Id==request.Id && x.DeletedBy==null);
          await _colorRepository.Remove(color);
            var colorList=await  _colorRepository.GetAll(x=>x.DeletedBy==null);
            return colorList;
        }
    }
}
