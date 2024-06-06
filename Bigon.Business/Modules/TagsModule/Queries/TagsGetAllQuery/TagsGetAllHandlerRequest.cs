using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Queries.TagsGetAllQuery
{
    internal class TagsGetAllHandlerRequest(ITagRepository tagRepository) : IRequestHandler<TagsGetAllRequest, IEnumerable<Tag>>
    {
        private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<IEnumerable<Tag>> Handle(TagsGetAllRequest request, CancellationToken cancellationToken)
        {
            var response = await _tagRepository.GetAll(x => x.DeletedBy == null);
            return response;
        }
    }
}
