namespace App.core.EntityAndDtoStructure.Auditables;

public class Auditable
{
    public int Id { get; set; }
    public virtual DateTime? CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string CreatedBy { get; set; }//convert to int
    public string UpdateBy { get; set; }
    public virtual DateTime? DeletedDate { get; set; }
    public virtual string DeletedBy { get; set; }
    public bool IsDeleted { get; set; } = false;

}
