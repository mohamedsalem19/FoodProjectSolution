using FoodProject.Models;
using FoodProject.Models.Enums;
using FoodProject.UnitOfWork;
using FoodProject.ViewModels;
using MediatR;

namespace FoodProject.CQRS.CategoryFeature.Query.GetAllCategory
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, ResponseViewModel<List<GetAllCategoryDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseViewModel<List<GetAllCategoryDTO>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = _unitOfWork.Repository<Category>()
                .GetAll()
                .Select(x => new GetAllCategoryDTO
                {
                    Name = x.Name
                }).ToList();

            if (!categories.Any())
            {
                return new FailureResponseViewModel<List<GetAllCategoryDTO>>(ErrorCode.NotFound, "Not Found Data");
            }

            return new SucessResponseViewModel<List<GetAllCategoryDTO>>(categories, "Data retrieved successfully");
        }
    }
}
