using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Queries.ColorsGetQuery
{
    internal class ColorsGetRequestHandler(IColorRepository colorRepository) : IRequestHandler<ColorsGetRequest, Color>
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public async Task<Color> Handle(ColorsGetRequest request, CancellationToken cancellationToken)
        {
            var response = await _colorRepository.GetById(x => x.Id == request.Id && x.DeletedBy == null);
            return response;
        }
    }
}
