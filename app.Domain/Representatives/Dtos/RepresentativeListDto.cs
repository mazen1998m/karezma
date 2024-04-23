namespace App.Domain.Representatives.Dtos;

public class RepresentativeListDto : Dto
{
    public double Commision { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? UserName { get; set; }
    public int UserId { get; set; }
}
