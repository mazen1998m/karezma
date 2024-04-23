using App.core.Helpers;
using App.Data.GenericRepository;
using App.Domain.Documents;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace App.Application.Documents;

public class DocumentsService : Service<Document>, IDocumentsService
{
    private readonly IConfiguration _configuration;

    public DocumentsService(
        IRepository<Document> repository,
        IMapper mapper,
        IConfiguration configuration
        ) : base(repository)
    {
        _configuration = configuration;
    }

    public string UploadFile(IFormFile file)
    {
        return FileUploaderHelper.Upload(file, _configuration["DefaultFolderFilesName"], _configuration["RootFilePath"]);
    }
}


public interface IDocumentsService : IService<Document>
{
    string UploadFile(IFormFile file);
}
