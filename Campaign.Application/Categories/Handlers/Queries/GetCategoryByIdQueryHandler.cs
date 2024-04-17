using AutoMapper;
using Campaign.Application.Categories.Models;
using Campaign.Application.Categories.Queries;
using Campaign.Domain.Category.Repositories;
using MediatR;

namespace Campaign.Application.Categories.Handlers.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetById(request.Id, cancellationToken);

            // Use AutoMapper to map CategoryEntity to Category directly
            var category = _mapper.Map<Category>(result);

            return category;
        }
    }
}
