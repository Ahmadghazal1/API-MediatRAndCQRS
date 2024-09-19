using Core.Dtos;
using MediatR;

namespace API.Command
{
    public class UpdateCategoryInfoRequest : IRequest<AllCategoryResponseDto>
    {
        public CategoryRequestDto Category { get; set; }    
        public int Id { get; }
        public UpdateCategoryInfoRequest(int id, CategoryRequestDto category)
        {
            Id = id;
            Category = category;
        }
    }
}
