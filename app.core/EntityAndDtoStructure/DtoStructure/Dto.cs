namespace app.core.EntityAndDtoStructure.DtoStructure;

public class Dto : SuperBase, IDto, IDBase
{
    public int Id { get; set; }
}

public interface IDto : IDBase
{

}