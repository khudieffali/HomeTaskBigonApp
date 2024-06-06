using Bigon.Business.Modules.TagsModule.Queries.TagsGetAllQuery;
using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Queries.TagsGetQuery
{
    internal class TagsGetHandlerRequest(ITagRepository tagRepository) : IRequestHandler<TagsGetRequest, Tag>
    {
        private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<Tag> Handle(TagsGetRequest request, CancellationToken cancellationToken)
        {
            var response = await _tagRepository.GetById(x =>x.Id==request.Id && x.DeletedBy == null);
            return response;
        }
    }
}
