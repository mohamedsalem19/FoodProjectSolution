using AutoMapper;
using FoodProject.CQRS.RecipesFeature.Command.PostRecipe;
using FoodProject.CQRS.RecipesFeature.Query.GetAllRecipes;
using FoodProject.CQRS.RecipesFeature.Query.GetRecipeById;
using FoodProject.Models;

namespace FoodProject.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<PostRecipeDto, RecipesItems>();
            CreateMap<RecipesItems, GetAllRecipesDto>()
                .ForMember(dest => dest.CategoryName, otp => otp.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.TagName, otp => otp.MapFrom(src => src.Tag.Name))
                .ForMember(dest => dest.ImageUrl, otp => otp.MapFrom(src => src.Image));
            CreateMap<RecipesItems, GetRecipeByIdDto>()
                .ForMember(dest => dest.CategoryName, otp => otp.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.TagName, otp => otp.MapFrom(src => src.Tag.Name))
                .ForMember(dest => dest.ImageUrl, otp => otp.MapFrom(src => src.Image));


        }
    }
}
