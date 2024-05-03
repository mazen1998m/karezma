using App.core.Common;
using Muslim.Assembly.Helper;
using System.Reflection;

namespace App.Application.Files;


internal class FileService : IFileService
{
    #region ctor
    private static Assembly _assembly;
    public FileService()
    {

        _assembly = AssemblyHelper.GetAssembly("app.Dashboard");
    }

    private static readonly string[] MediaFileExt =
    {
        "bmp", "gif", "webp", "jpeg", "jpg", "jpe", "jfif", "pjpeg", "pjp", "png", "tiff", "tif"
    };

    private static readonly string[] DocsFileExt =
    {
        "pdf", "docx", "doc", "xlsx", "xls", "ppt", "vnd.openxmlformats-officedocument.wordprocessingml.document"
    };

    private static readonly string[] EmailFileExt =
    {
        "eml", "msg"
    };

    #endregion

    public FileInfoDto FileSaveInFolder(string base64String, string folderName = "Documents", string fileName = "")
    {
        var fileInfo = new FileInfoDto();
        if (base64String.IsNullOrEmpty())
        {
            return fileInfo;
        }
        var file = new Base64Data(base64String);

        fileInfo.FileType = MediaFileExt.Contains(file.Extension) ? FileType.Media
            : DocsFileExt.Contains(file.Extension) ? FileType.Document
            : EmailFileExt.Contains(file.Extension) ? FileType.Email : FileType.None;

        fileInfo.FileName = fileName.IsNullOrEmpty() ? $"{Guid.NewGuid()}.{file.Extension}" : fileName;


        var folderPath = IsFolderExist(folderName);

        //check if file exist
        var fileFullPath = Path.Combine(folderPath, fileInfo.FileName);

        File.WriteAllBytes(fileFullPath, file.Bytes);
        return fileInfo;
    }


    private static string IsFolderExist(string folderName)
    {
        var folderPath = GetFolderPath(folderName);
        var isFolderExist = Directory.Exists(folderPath);

        if (isFolderExist)
        {
            return folderPath;
        }

        folderPath = CreateFolder(folderPath);

        return folderPath;
    }

    private static string CreateFolder(string folderPath)
    {

        Directory.CreateDirectory(folderPath);

        return folderPath;
    }

    private static string GetFolderPath(string folderName)
    {
        folderName = folderName.Replace('.', '/');

        // Get the assembly's location
        string assemblyLocation = Path.GetDirectoryName(_assembly.Location);
        var binDebugNetPath = Path.Combine("bin", "Debug", "net6.0");
        var exeDirectory = assemblyLocation!.Replace(binDebugNetPath, string.Empty);

        //with wwwroot/img
        exeDirectory = Path.Combine(exeDirectory, "wwwroot", "img");
        // Combine assembly location with the folder path to get the full path
        string fullPath = Path.Combine(exeDirectory, folderName);


        return fullPath;
    }

    public string GetFileBase64(string fileName, string folderName = "Documents")
    {
        var filePath = Path.Combine(GetFolderPath(folderName), fileName);
        if (!File.Exists(filePath))
        {
            return string.Empty;
        }

        var bytes = File.ReadAllBytes(filePath);
        return Convert.ToBase64String(bytes);
    }
}

public interface IFileService : IAutoInjection
{
    FileInfoDto FileSaveInFolder(string base64String, string folderName = "Documents", string fileName = "");

    string GetFileBase64(string fileName, string folderName = "Documents");
}

