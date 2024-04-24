namespace App.Domain.Representatives.Dtos;

public class RepresentativeUpdateDto : Dto
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public double Commision { get; set; }
    public bool IsActive { get; set; }
    public int UserId { get; set; }
}

