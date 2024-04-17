using AutoMapper;
using Campaign.Application.Categories.Models;
using Campaign.Application.Categories.Queries;
using Campaign.Domain.Category.Repositories;
using MediatR;

namespace Campaign.Application.Categories.Handlers.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var resultData = await _categoryRepository.GetAll(cancellationToken);

            // Use AutoMapper to map CategoryEntity to Category directly
            var categories = _mapper.Map<List<Category>>(resultData);

            return categories;
        }
    }
}
