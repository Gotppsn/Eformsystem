// Path: EFormBuilder/wwwroot/js/apiUtils.js

window.apiUtils = {
    getBaseUrl: function() {
        return document.querySelector('base')?.getAttribute('href') || '/';
    },
    
    getApiUrl: function(endpoint) {
        return `${this.getBaseUrl()}api/${endpoint}`;
    },
    
    getFullApiUrl: function(baseApiUrl, endpoint) {
        return `${baseApiUrl}${endpoint}`;
    }
};