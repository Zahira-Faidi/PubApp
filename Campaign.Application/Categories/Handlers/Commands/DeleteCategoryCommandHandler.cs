using Campaign.Application.Categories.Commands;
using Campaign.Domain.Category.Repositories;
using MediatR;

namespace Campaign.Application.Categories.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _categoryRepository.GetById(request.Id, cancellationToken);
            if (categoryToDelete == null)
            {
                throw new Exception($"Category with ID {request.Id} not found.");
            }

            return await _categoryRepository.DeleteCategory(request.Id, cancellationToken);
        }
    }
}
