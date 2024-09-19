using Core.Dtos;
using MediatR;

namespace API.Command
{
    public class DeleteCategoryInfoRequest : IRequest<AllCategoryResponseDto>
    {
        public int Id { get; }
        public DeleteCategoryInfoRequest(int id)
        {
            Id = id;
        }
    }
}
