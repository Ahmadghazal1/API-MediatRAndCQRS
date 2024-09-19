using API.Command;
using AutoMapper;
using Core;
using Core.Dtos;
using DAL.Models;
using MediatR;

namespace API.Handler
{
    public class CreateCategoryInfoHandler : IRequestHandler<CreateCategoryInfoRequest, AllCategoryResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AllCategoryResponseDto> Handle(CreateCategoryInfoRequest request, CancellationToken cancellationToken)
        {
            var Model = _mapper.Map<Category>(request.Category);
            var result =  _mapper.Map<AllCategoryResponseDto>(await _unitOfWork.CategoryRepository.Create(Model));
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}
