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

        public BaseUrlService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public string GetBaseUrl()
        {
            return _navigationManager.BaseUri;
        }

        public string CombineUrl(string baseUrl, string relativeUrl)
        {
            baseUrl = baseUrl.TrimEnd('/');
            relativeUrl = relativeUrl.TrimStart('/');
            return $"{baseUrl}/{relativeUrl}";
        }
    }
}