using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Queries.ColorsGetAllQuery
{
    internal class ColorsGetAllHandlerRequest(IColorRepository colorRepository) : IRequestHandler<ColorsGetAllRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository=colorRepository;
        public async Task<IEnumerable<Color>> Handle(ColorsGetAllRequest request, CancellationToken cancellationToken)
        {
            var response = await _colorRepository.GetAll(x=>x.DeletedBy==null);
            return [..response];
            
        }
    }
}
