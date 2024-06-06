using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Commands.TagsAddCommands
{
    internal class TagsAddHandlerRequest(ITagRepository tagRepository) : IRequestHandler<TagsAddRequest, Tag>
    {
        private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<Tag> Handle(TagsAddRequest request, CancellationToken cancellationToken)
        {
           var newTag=new Tag
           {
               Name= request.Name,
           };
            await _tagRepository.Add(newTag);
           return newTag;
        }
    }
}
