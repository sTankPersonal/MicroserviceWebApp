namespace RecipeMicroservice.Presentation.Models.Unit
{
    public class ListUnitViewModel : BaseListViewModel<UnitViewModel>
    {
        public string? SearchName { get; set; }
    }
}
