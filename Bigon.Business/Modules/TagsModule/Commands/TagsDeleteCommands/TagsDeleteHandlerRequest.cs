using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Commands.TagsDeleteCommands
{
    internal class TagsDeleteHandlerRequest(ITagRepository tagRepository):IRequestHandler<TagsDeleteRequest,IEnumerable<Tag>>
    {
        private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<IEnumerable<Tag>> Handle(TagsDeleteRequest request, CancellationToken cancellationToken)
        {
            var response=await _tagRepository.GetById(x=>x.Id==request.Id && x.DeletedBy==null);
            await _tagRepository.Remove(response);
            var tagList=await _tagRepository.GetAll(x=>x.DeletedBy==null);
            return tagList;
        }
    }
}
