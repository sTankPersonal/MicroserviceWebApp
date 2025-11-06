using RecipeMicroservice.Application.Interfaces.ViewModels;

namespace RecipeMicroservice.Presentation.Models.Category
{
    public class CategoryViewModel : IInfoViewModel<Guid>
    {
        public Guid Id { get; init;  }
        public string Name { get; set; } = string.Empty;
    }
}
