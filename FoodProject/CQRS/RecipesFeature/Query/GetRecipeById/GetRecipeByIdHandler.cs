using FoodProject.CQRS.RecipesFeature.Query.GetAllRecipes;
using FoodProject.Models.Enums;
using FoodProject.Models;
using FoodProject.ViewModels;
using MediatR;
using AutoMapper;
using FoodProject.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace FoodProject.CQRS.RecipesFeature.Query.GetRecipeById
{
    public class GetRecipeByIdHandler : IRequestHandler<GetRecipeByIdCommand, ResponseViewModel<GetRecipeByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetRecipeByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseViewModel<GetRecipeByIdDto>> Handle(GetRecipeByIdCommand request, CancellationToken cancellationToken)
        {
            var recipe = _unitOfWork.Repository<RecipesItems>().GetAll().Where(x=>x.Id == request.Id).Include(x => x.Category).Include(x => x.Tag).FirstOrDefault();
            var RescipesDto = _mapper.Map<GetRecipeByIdDto>(recipe);
            if (RescipesDto is not null)
            {
                return new SucessResponseViewModel<GetRecipeByIdDto>(RescipesDto, "Retrive Successfuly");
            }
            return new FailureResponseViewModel<GetRecipeByIdDto>(ErrorCode.NotFound, "Not Found Data");
        }
    }
}
