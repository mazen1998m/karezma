namespace app.core.EntityAndDtoStructure.EntityStructure;

public abstract class EntityBase : SuperBase
{
    public bool IsDeleted { get; set; } = false;
}