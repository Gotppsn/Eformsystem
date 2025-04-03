namespace EFormBuilder.Models
{
    public class ClsServiceFile
    {
        public string Base64 { get; set; }
        public string Filename { get; set; }
        public string FolderPath { get; set; }
    }

    public class FileResponse
    {
        public string ErrorMessage { get; set; }
        public byte[] FileBytes { get; set; }
        public string FilePath { get; set; }
        public string FileThumbnailPath { get; set; }
        public string FileThumbnailUrl { get; set; }
        public string FileUrl { get; set; }
        public bool IsSuccess { get; set; }
    }
}