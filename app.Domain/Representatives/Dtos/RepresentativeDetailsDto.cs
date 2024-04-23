namespace App.Domain.Representatives.Dtos;

public class RepresentativeDetailsDto : Dto
{
    public double Commision { get; set; }
    public string UserName { get; set; }

    public string Name { get; set; }
    public string Phone { get; set; }
    public int UserId { get; set; }
    public bool IsActive { get; set; }
}
