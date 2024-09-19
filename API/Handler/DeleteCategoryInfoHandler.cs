using API.Command;
using AutoMapper;
using Core;
using Core.Dtos;
using MediatR;

namespace API.Handler
{
    public class DeleteCategoryInfoHandler : IRequestHandler<DeleteCategoryInfoRequest, AllCategoryResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCategoryInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AllCategoryResponseDto> Handle(DeleteCategoryInfoRequest request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(request.Id); 
            if (category == null)
            {
                return null;
            }

            await _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<AllCategoryResponseDto>(category);

        }
    }
}
