namespace Template.Presentation.Interfaces.Models
{
    public interface IHasEntity<TSelf, TId> where TSelf : IHasEntity<TSelf, TId>
    {
        TId Id { get; set; }
        TSelf WithId(TId entityId);
    }
}
