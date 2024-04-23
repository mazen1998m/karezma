
namespace App.Domain.Addresses.Dtos;

public class AddressReadDto : Dto
{
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Street { get; set; }
    public string? Lat { get; set; }
    public string? Lot { get; set; }
}
