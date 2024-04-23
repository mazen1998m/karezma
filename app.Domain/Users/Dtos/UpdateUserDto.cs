using App.Domain.Addresses;
using App.Domain.Documents.Dtos;
using App.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Users.Dtos;

public class UpdateUserDto : Dto
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IFormFile Photo { get; set; }
    public List<CreateDocumentDto> Documents { get; set; }
    public List<int> RoleIds { get; set; }
    public UserType UserType { get; set; }
    public Address Address { get; set; }
    public bool IsActive { get; set; }


}