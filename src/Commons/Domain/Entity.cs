namespace Andromeda;

public abstract class Entity : IEqualityComparer<Entity>
{
    public Guid Id { get; protected set; }
    
    public bool Equals(Entity? x, Entity? y)
    {
        if(x is null && y is null)
        {
            return true;
        }
        
        if(x is null || y is null)
        {
            return false;
        }
        
        return x.Id.Equals(y.Id);
    }

    public int GetHashCode(Entity obj)
    {
        return obj.Id.GetHashCode();
    }
}