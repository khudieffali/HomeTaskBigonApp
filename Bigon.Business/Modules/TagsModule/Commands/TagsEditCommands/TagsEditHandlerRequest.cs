using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Commands.TagsEditCommands
{
    internal class TagsEditHandlerRequest(ITagRepository tagRepository) : IRequestHandler<TagsEditRequest, Tag>
    {
        private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<Tag> Handle(TagsEditRequest request, CancellationToken cancellationToken)
        {
            var editTag = new Tag
            {
                Id=request.Id,
                Name=request.Name,
            };
            await _tagRepository.Edit(editTag);
            return editTag;
        }
    }
}
