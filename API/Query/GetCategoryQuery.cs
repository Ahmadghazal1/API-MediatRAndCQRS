using Core.Dtos;
using MediatR;

namespace API.Query
{
    public class GetCategoryQuery : IRequest<AllCategoryResponseDto>
    {
        public int Id { get; }
        public GetCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
