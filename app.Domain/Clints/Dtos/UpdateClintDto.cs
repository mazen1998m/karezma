namespace App.Domain.Clints.Dtos;

public class UpdateClintDto : Dto
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string SecandPhone { get; set; }
    public decimal Weight { get; set; }
    public decimal Hight { get; set; }
}
