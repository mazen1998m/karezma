namespace App.Domain.Representatives.Dtos;

public class RepresentativeCreateDto : Dto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public double Commision { get; set; }
}
