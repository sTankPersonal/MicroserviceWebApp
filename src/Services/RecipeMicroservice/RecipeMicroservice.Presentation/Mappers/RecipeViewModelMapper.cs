using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Recipe;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class RecipeViewModelMapper
    {
        public static RecipeViewModel ToViewModel(this RecipeDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            PrepTimeInMinutes = dto.PrepTimeInMinutes,
            CookTimeInMinutes = dto.CookTimeInMinutes,
            Servings = dto.Servings,
            Categories = dto.Categories.ToViewModel(dto.Id),
            Ingredients = dto.Ingredients.ToViewModel(dto.Id),
            Instructions = dto.Instructions.ToViewModel(dto.Id)
        };

        public static ListRecipeViewModel ToViewModel(this PagedResult<RecipeDto> pagedDto, FilterRecipe filter) => new()
        {
            Items = pagedDto.Items.Select(ToViewModel),
            PageNumber = pagedDto.PageNumber,
            PageSize = pagedDto.PageSize,
            TotalItems = pagedDto.TotalItems,
            Filter = filter.ToViewModel()
        };

        public static FilterViewModel ToViewModel(this FilterRecipe filter) => new()
        {
            SearchName = filter.SearchName,
            SearchCategoryId = filter.SearchCategoryId,
            SearchIngredientId = filter.SearchIngredientId
        };
        public static FilterRecipe ToFilter(this FilterViewModel filter) => new()
        {
            SearchName = filter.SearchName,
            SearchCategoryId = filter.SearchCategoryId,
            SearchIngredientId = filter.SearchIngredientId
        };
    }
}
