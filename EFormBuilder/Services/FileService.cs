using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using EFormBuilder.Models;

namespace EFormBuilder.Services
{
    public interface IFileService
    {
        Task<FileResponse> UploadFile(string base64, string filename, string folderPath);
        Task<FileResponse> DeleteFile(string fileUrl);
        Task<byte[]> GetFile(string fileUrl);
    }

    public class FileService : IFileService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<FileService> _logger;

        public FileService(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ILogger<FileService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;
        }

        private string GetApiUrl()
        {
            return _configuration["ApiSettings:BaseUrl"];
        }

        private string GetToken()
        {
            // In a real application, you would retrieve this from a secure storage or service
            return "key-token";
        }

        public async Task<FileResponse> UploadFile(string base64, string filename, string folderPath)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Post, $"{GetApiUrl()}api/Service_File/Upload_File");
                
                var fileData = new ClsServiceFile
                {
                    Base64 = base64,
                    Filename = filename,
                    FolderPath = folderPath
                };
                
                var jsonContent = JsonSerializer.Serialize(fileData);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                request.Headers.Add("Token", GetToken());
                
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<FileResponse>(responseContent, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                if (!result.IsSuccess)
                {
                    throw new Exception($"Error uploading file: {result.ErrorMessage}");
                }
                
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file {Filename}", filename);
                throw;
            }
        }

        public async Task<FileResponse> DeleteFile(string fileUrl)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Post, $"{GetApiUrl()}api/Service_File/Delete_File");

                fileUrl = HttpUtility.UrlEncode(fileUrl);
                request.Headers.Add("Token", GetToken());
                request.Headers.Add("FilePath", fileUrl);
                
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<FileResponse>(responseContent, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                if (!result.IsSuccess)
                {
                    throw new Exception($"Error deleting file: {result.ErrorMessage}");
                }
                
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting file {FileUrl}", fileUrl);
                throw;
            }
        }

        public async Task<byte[]> GetFile(string fileUrl)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                
                // Handle relative URLs correctly
                if (!fileUrl.StartsWith("http"))
                {
                    var baseUrl = _configuration["ApiSettings:BaseUrl"];
                    fileUrl = $"{baseUrl.TrimEnd('/')}/{fileUrl.TrimStart('/')}";
                }
                
                var request = new HttpRequestMessage(HttpMethod.Get, fileUrl);
                
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving file {FileUrl}", fileUrl);
                throw;
            }
        }
    }
}