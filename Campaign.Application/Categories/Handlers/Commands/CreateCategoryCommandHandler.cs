using AutoMapper;
using Campaign.Application.Categories.Commands;
using Campaign.Application.Categories.Models;
using Campaign.Domain.Category.Entities;
using Campaign.Domain.Category.Repositories;
using MediatR;

namespace Campaign.Application.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Map CreateCategoryCommand to CategoryEntity
            var categoryEntity = _mapper.Map<CategoryEntity>(request);

            // Create the category using the mapped entity
            var result = await _categoryRepository.CreateCategory(categoryEntity, cancellationToken);

            // Map CategoryEntity to Category and return
            var categoryModel = _mapper.Map<Category>(result);
            return categoryModel;
        }
    }
}
