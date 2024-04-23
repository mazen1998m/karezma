using Microsoft.AspNetCore.Http;

namespace App.Domain.Documents.Dtos;

public class CreateDocumentDto : IdNameDto
{
    public IFormFile File { get; set; }
    public string FilePath { get; set; }
}
