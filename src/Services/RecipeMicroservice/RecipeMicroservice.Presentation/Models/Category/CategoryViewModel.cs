namespace RecipeMicroservice.Presentation.Models.Category
{
    public class CategoryViewModel : BaseIdViewModel<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}
