using API.Query;
using AutoMapper;
using Core;
using Core.Dtos;
using MediatR;

namespace API.Handler
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<AllCategoryResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AllCategoryResponseDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoriesModel = await _unitOfWork.CategoryRepository.GetAll(); 

            if(categoriesModel == null)
            {
                return null;
            }

            var results = _mapper.Map<IEnumerable<AllCategoryResponseDto>>(categoriesModel);

            return results;
        }
    }
}
