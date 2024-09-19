using Core.Dtos;
using MediatR;

namespace API.Query
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<AllCategoryResponseDto>>
    {
    }
}
