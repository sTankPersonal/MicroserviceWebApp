namespace RecipeMicroservice.Presentation.Models.Category
{
    public class ListCategoryViewModel : BaseListViewModel<CategoryViewModel>
    {
        public string? SearchName { get; set; }
    }
}
