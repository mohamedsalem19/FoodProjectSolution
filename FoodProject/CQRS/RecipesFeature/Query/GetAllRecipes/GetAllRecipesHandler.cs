using AutoMapper;
using FoodProject.CQRS.CategoryFeature.Query.GetAllCategory;
using FoodProject.Models;
using FoodProject.Models.Enums;
using FoodProject.UnitOfWork;
using FoodProject.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodProject.CQRS.RecipesFeature.Query.GetAllRecipes
{
    public class GetAllRecipesHandler : IRequestHandler<GetAllRecipesCommand, ResponseViewModel<List<GetAllRecipesDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public GetAllRecipesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseViewModel<List<GetAllRecipesDto>>> Handle(GetAllRecipesCommand request, CancellationToken cancellationToken)
        {
            var recipes = _unitOfWork.Repository<RecipesItems>().GetAll().Include(x=>x.Category).Include(x=>x.Tag).ToList();
            var RescipesDto = _mapper.Map<List<GetAllRecipesDto>>(recipes);
            if (RescipesDto.Any())
            {
                return new SucessResponseViewModel<List<GetAllRecipesDto>>(RescipesDto, "Retrive Successfuly");
            }
            return new FailureResponseViewModel<List<GetAllRecipesDto>>(ErrorCode.NotFound, "Not Found Data");
        }
    }
}
