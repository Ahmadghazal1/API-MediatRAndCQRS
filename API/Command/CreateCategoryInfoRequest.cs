using Core.Dtos;
using MediatR;

namespace API.Command
{
    public class CreateCategoryInfoRequest : IRequest<AllCategoryResponseDto>
    {
        public CategoryRequestDto Category { get; }

        public CreateCategoryInfoRequest(CategoryRequestDto category)
        {
            Category = category;
        }
    }
}
