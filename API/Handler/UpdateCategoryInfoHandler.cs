using API.Command;
using AutoMapper;
using Azure.Core;
using Core;
using Core.Dtos;
using DAL.Models;
using MediatR;

namespace API.Handler
{
    public class UpdateCategoryInfoHandler : IRequestHandler<UpdateCategoryInfoRequest, AllCategoryResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<AllCategoryResponseDto> Handle(UpdateCategoryInfoRequest request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(request.Id);
            if(category == null)
            {
                return null;
            }

            category.Name = request.Category.Name;
            var Model = _mapper.Map<Category>(category);
            var result =  await _unitOfWork.CategoryRepository.Update(Model, request.Id);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<AllCategoryResponseDto>(result);
        }
    }
}
