using System;
using System.Net.Http;
using AngleSharp;

namespace CianParser.Parser
{
    public class HttpCianParser
    {
        private readonly IBrowsingContext _browsingContext;
        
        private readonly HttpClient _httpClient;
        
        private string Uri { get; set; }
        
        private string CurrentHtmlDOM { get; set; }
        
        private int CurrentPagePosition { get; set; }

        public HttpCianParser(IBrowsingContext browsingContext, HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _browsingContext = browsingContext ?? throw new ArgumentNullException(nameof(browsingContext));
        }
        
        public HttpCianParser SetUri(string uri)
        {
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
            
            return this;
        }
    }
}