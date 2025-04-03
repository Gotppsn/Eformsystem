using System.DirectoryServices.AccountManagement;
using Microsoft.Extensions.Options;
using EFormBuilder.Models;
using System.Text.Json;

namespace EFormBuilder.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateCredentials(string username, string password);
        Task<UserResponse> GetUserInfo(string userCode);
    }

    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ILogger<AuthService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            try
            {
                string domain = _configuration["LdapSettings:Domain"];
                
                using (var context = new PrincipalContext(ContextType.Domain, domain))
                {
                    return context.ValidateCredentials(username, password);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating credentials for user {Username}", username);
                return false;
            }
        }

        public async Task<UserResponse> GetUserInfo(string userCode)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var apiUrl = $"{_configuration["ApiSettings:ApiUserUrl"]}?userCode={userCode}";
                
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                
                var content = await response.Content.ReadAsStringAsync();
                var userInfo = JsonSerializer.Deserialize<UserResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                
                return userInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user information for user code {UserCode}", userCode);
                return null;
            }
        }
    }
}