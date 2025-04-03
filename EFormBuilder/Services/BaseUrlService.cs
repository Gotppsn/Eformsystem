// Path: EFormBuilder/Services/BaseUrlService.cs
using Microsoft.AspNetCore.Components;

namespace EFormBuilder.Services
{
    public interface IBaseUrlService
    {
        string GetBaseUrl();
        string CombineUrl(string baseUrl, string relativeUrl);
    }

    public class BaseUrlService : IBaseUrlService
    {
        private readonly NavigationManager _navigationManager;
        private readonly IWebHostEnvironment _environment;

        public BaseUrlService(NavigationManager navigationManager, IWebHostEnvironment environment)
        {
            _navigationManager = navigationManager;
            _environment = environment;
        }

        public string GetBaseUrl()
        {
            // Get base URL from NavigationManager
            var uri = new Uri(_navigationManager.BaseUri);
            var baseUrl = $"{uri.Scheme}://{uri.Authority}";
            
            // Add application path if not running at root
            if (!string.IsNullOrEmpty(uri.AbsolutePath) && uri.AbsolutePath != "/")
            {
                baseUrl += uri.AbsolutePath.TrimEnd('/');
            }
            
            return baseUrl;
        }

        public string CombineUrl(string baseUrl, string relativeUrl)
        {
            baseUrl = baseUrl.TrimEnd('/');
            relativeUrl = relativeUrl.TrimStart('/');
            return $"{baseUrl}/{relativeUrl}";
        }
    }
}