using FoodProject.ViewModels;
using MediatR;

namespace FoodProject.CQRS.CategoryFeature.Query.GetAllCategory
{
    public class GetAllCategoryQuery : IRequest<ResponseViewModel<List<GetAllCategoryDTO>>>
    {
    }
}
