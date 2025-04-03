window.apiUtils = {
    getBaseUrl: function() {
        return document.querySelector('base')?.getAttribute('href') || '/';
    },
    
    getApiUrl: function(endpoint) {
        const baseUrl = this.getBaseUrl();
        return `${baseUrl}api/${endpoint.startsWith('/') ? endpoint.substring(1) : endpoint}`;
    },
    
    getFullApiUrl: function(baseApiUrl, endpoint) {
        return `${baseApiUrl.endsWith('/') ? baseApiUrl : baseApiUrl + '/'}${endpoint.startsWith('/') ? endpoint.substring(1) : endpoint}`;
    }
};