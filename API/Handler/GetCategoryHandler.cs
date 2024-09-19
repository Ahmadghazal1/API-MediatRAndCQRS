using API.Query;
using AutoMapper;
using Core;
using Core.Dtos;
using MediatR;

namespace API.Handler
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, AllCategoryResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<AllCategoryResponseDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.CategoryRepository.GetById(request.Id);

            if (model == null)
                return null; 

            var result = _mapper.Map<AllCategoryResponseDto>(model);

            return result;
        }
    }
}
