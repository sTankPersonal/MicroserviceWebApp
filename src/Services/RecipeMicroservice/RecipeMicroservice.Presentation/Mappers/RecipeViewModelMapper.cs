using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Recipe;
using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

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
            Categories = dto.Categories.ToListViewModel(),
            Ingredients = dto.Ingredients.ToListViewModel(),
            Instructions = dto.Instructions.ToListViewModel(),
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
            Servings = dto.Servings,
            RecipeCategories = dto.Categories.ToListViewModel(),
            RecipeIngredients = dto.Ingredients.ToListViewModel(),
            RecipeInstructions = dto.Instructions.ToListViewModel()
        };
        public static AttachElementsRecipeViewModel ToAttachElementsViewModel(this RecipeDto dto) => new()
        {
            NewCategory = new CreateRecipeCategoryViewModel() { AggregateId = dto.Id },
            NewIngredient = new CreateRecipeIngredientViewModel() { AggregateId = dto.Id },
            NewInstruction = new CreateRecipeInstructionViewModel() { AggregateId = dto.Id }
        };

        public static UpdateAndAttachElementsRecipeViewModel ToUpdateAndAttachElementsViewModel(this RecipeDto dto) => new()
        {
            UpdateRecipe = dto.ToUpdateViewModel(),
            AttachElements = dto.ToAttachElementsViewModel()
        };


        // Map from ViewModel to DTO
        public static CreateRecipeDto ToCreateDto(this CreateRecipeViewModel viewModel) => new()
        {
            Name = viewModel.Name,
            PrepTimeInMinutes = viewModel.PrepTimeInMinutes,
            CookTimeInMinutes = viewModel.CookTimeInMinutes,
            Servings = viewModel.Servings
        };
        public static UpdateRecipeDto ToUpdateDto(this UpdateRecipeViewModel viewModel) => new()
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
