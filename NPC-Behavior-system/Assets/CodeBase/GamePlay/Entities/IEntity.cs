namespace CodeBase.CompositionRoot
{
    public interface IEntity
    {
        EntityState State { get; }
        string Id { get; set; }
        EntityTypeId TypeId { get; set; }
        int PlaceNumber { get; set; }
        
        bool IsDead { get; }
        bool IsReady { get; }
        void InitWithState(EntityState state, bool turn, int placeNumber);
        void SwitchNextTurnPointer(bool on);
    }
}