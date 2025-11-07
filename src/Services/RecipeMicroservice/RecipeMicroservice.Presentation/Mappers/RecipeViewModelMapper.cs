using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Recipe;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class RecipeViewModelMapper
    {
        // Map from DTO to ViewModel
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
       
        public static ListRecipeViewModel ToListViewModel(this PagedResult<RecipeDto> pagedDto) => new()
        {
            Items = pagedDto.Items.Select(ToViewModel),
            PageNumber = pagedDto.PageNumber,
            PageSize = pagedDto.PageSize,
            TotalItems = pagedDto.TotalItems,
        };

        public static UpdateRecipeViewModel ToUpdateViewModel(this RecipeDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            PrepTimeInMinutes = dto.PrepTimeInMinutes,
            CookTimeInMinutes = dto.CookTimeInMinutes,
            Servings = dto.Servings
        };


        // Map from ViewModel to DTO
        public static CreateRecipeDto ToDto(this CreateRecipeViewModel viewModel) => new()
        {
            Name = viewModel.Name,
            PrepTimeInMinutes = viewModel.PrepTimeInMinutes,
            CookTimeInMinutes = viewModel.CookTimeInMinutes,
            Servings = viewModel.Servings
        };
        public static UpdateRecipeDto ToDto(this UpdateRecipeViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            PrepTimeInMinutes = viewModel.PrepTimeInMinutes,
            CookTimeInMinutes = viewModel.CookTimeInMinutes,
            Servings = viewModel.Servings
        };

        // Map from FilterViewModel to Filter
        public static FilterRecipe ToFilter(this FilterRecipeViewModel filterViewModel) => new()
        {
            SearchName = filterViewModel.SearchName,
            SearchCategoryId = filterViewModel.SearchCategoryId,
            SearchIngredientId = filterViewModel.SearchIngredientId
        };

        // Map from Filter to FilterViewModel
        public static FilterRecipeViewModel ToFilterViewModel(this FilterRecipe filter) => new()
        {
            SearchName = filter.SearchName,
            SearchCategoryId = filter.SearchCategoryId,
            SearchIngredientId = filter.SearchIngredientId
        };
    }
}
