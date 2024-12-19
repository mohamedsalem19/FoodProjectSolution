using AutoMapper;
using FoodProject.Helper;
using FoodProject.Models;
using FoodProject.UnitOfWork;
using MediatR;

namespace FoodProject.CQRS.RecipesFeature.Command.PostRecipe
{
    public class PostRecipeHandler : IRequestHandler<PostRecipeCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hosting;

        public PostRecipeHandler(IUnitOfWork unitOfWork, IMapper mapper , IWebHostEnvironment hosting)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hosting = hosting;
        }
        public async Task<string> Handle(PostRecipeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Recipe = _mapper.Map<RecipesItems>(request.Dto);
                if (request.Dto.Image is not null)
                {
                    var image = await Upload.UploadFiles(request.Dto.Image, _hosting, "Violation/" + Guid.NewGuid() + "Attachments");
                    Recipe.Image = image;
                }
                _unitOfWork.Repository<RecipesItems>().Add(Recipe);
                 await _unitOfWork.CompleteAsync();
                return "Post Successfully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
