using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Js;
using CianParser.Parser.Exceptions;
using CianParser.Parser.Models;
using Jint.Runtime;
using Newtonsoft.Json;

namespace CianParser.Parser
{
    public class HttpCianParser
    {
        private readonly IBrowsingContext _browsingContext;
        
        private readonly HttpClient _httpClient;
        
        private string? Uri { get; set; }
        
        private string? CurrentHtmlDOM { get; set; }
        
        private int? CurrentPagePosition { get; set; }
        
        public HttpCianParser(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _browsingContext = BrowsingContext.New(Configuration.Default.WithJs());
        }

        public HttpCianParser(IBrowsingContext browsingContext, HttpClient httpClient)
        {
            _browsingContext = browsingContext ?? throw new ArgumentNullException(nameof(browsingContext));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        
        public HttpCianParser SetUri(string uri)
        {
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
            return this;
        }
        
        public async Task<string> GetHtmlDomAsync()
        {
            ValidateUri();
            
            var res = await _httpClient.GetAsync(Uri);

            var dom = await res.Content.ReadAsStringAsync();

            CurrentHtmlDOM = dom;

            return dom;
        }
        
        public async Task<List<Offer>> GetOffersOnPage()
        {
            var currentPageDom = await GetHtmlDomAsync();
        
            return await GetOffersOnPageFromHtml(currentPageDom);
        }
        
        private async Task<List<Offer>> GetOffersOnPageFromHtml(string html)
        {
            CheckCurrentHtmlDom();
            
            var document = await _browsingContext.OpenAsync(req => req.Content(html));

            try
            {
                var scriptJs = (string) document.ExecuteScript("JSON.stringify(_cianConfig['frontend-serp'][82].value.results.offers)");
                
                var deserializeResult = JsonConvert.DeserializeObject<List<Offer>>(scriptJs);

                return deserializeResult ?? throw new Exception();
            }
            catch (Exception ex)
            {
                if (ex is JavaScriptException)
                {
                    throw new JsNotFoundException("can't find javascript on the page, error message: " + ex.Message);

                }

                throw;
            }

        }
        
        private void ValidateUri()
        {
            if (Uri == null)
                throw new UriNotDefinedException("Use method SetUri() to setup Uri For Parsing");
        }

        private void CheckCurrentHtmlDom()
        {
            if (CurrentHtmlDOM == null)
                throw new CurrentHtmlDomEmptyException("You need to get Html DOM by GetHtmlDomAsync() method");
        }
    }
}