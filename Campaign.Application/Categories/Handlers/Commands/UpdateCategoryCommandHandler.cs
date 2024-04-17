using Campaign.Application.Categories.Commands;
using Campaign.Domain.Category.Repositories;
using MediatR;

namespace Campaign.Application.Categories.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetById(request.Id, cancellationToken);

                // Validation
                if (existingCategory == null)
                {
                    throw new Exception($"Category with id {request.Id} not found");
                }

                // Update existingCategory properties based on request
                existingCategory.Name = request.Name;
                // Add other properties here as needed

                var result = await _categoryRepository.UpdateCategory(existingCategory, cancellationToken);

                // Return the result
                return result;
            }
            catch (Exception ex)
            {
                // Handle any exceptions and rethrow with a custom message
                throw new Exception($"Failed to update category: {ex.Message}", ex);
            }
        }
    }
}
