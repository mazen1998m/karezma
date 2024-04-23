using Muslim.Filter.FilterInterface;

namespace app.core.EntityAndDtoStructure.EntityStructure;

public abstract class Entity : EntityBase, IDBase,IHaveFilter
{
    public virtual int Id { get; set; }
    public virtual DateTime? DeletedDate { get; set; }
    public virtual string? DeletedBy { get; set; }
}
