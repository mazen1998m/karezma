namespace app.core.EntityAndDtoStructure;

public abstract class SuperBase
{
    public virtual DateTime? CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdateBy { get; set; }
}