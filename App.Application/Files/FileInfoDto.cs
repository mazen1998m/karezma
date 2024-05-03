namespace App.Application.Files;

public class FileInfoDto
{
    public string FilePath { get; set; }
    public FileType FileType { get; set; }
    public string FileName { get; set; }
}

public enum FileType
{
    None = 0,
    Media = 1,
    Document = 2,
    Email = 3
}