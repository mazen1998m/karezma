using App.Domain.Addresses;
using App.Domain.Documents.Dtos;
using App.Domain.Enums;

namespace App.Domain.Users.Dtos;

public class UserDetailsDto : IdNameDto
{
    public string Phone { get; set; }
    public string Email { get; set; }
    public string PhotoUrl { get; set; }
    public UserType UserType { get; set; }
    public Address Address { get; set; }
    public List<DocumentDetailsDto> Documents { get; set; }
    public bool IsActive { get; set; }

}
