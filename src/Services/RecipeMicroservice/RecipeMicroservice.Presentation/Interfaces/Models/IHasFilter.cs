namespace RecipeMicroservice.Presentation.Interfaces.Models
{
    public interface IHasFilter<TSelf, TFilter> where TSelf : IHasFilter<TSelf, TFilter>
    {
        TFilter Filter { get; set; }
        TSelf WithFilter(TFilter filter);
    }
}
