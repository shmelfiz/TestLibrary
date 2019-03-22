using AlbumsLibraryTest.Core.Constants;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlbumsLibraryTest.BLL.Services.Commands.Base
{
    public abstract class AlbumsLibraryServicesBaseCommand<TResponse> where TResponse : class
    {
        #region Properteis

        private IHttpClientFactory _httpClientFactory { get; set; }

        #endregion

        #region Fields

        protected readonly string HostAddress;

        #endregion

        #region Ctor

        public AlbumsLibraryServicesBaseCommand(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            HostAddress = config.GetSection(Defaults.ConfigServerSectionName)
                .GetValue<string>(Defaults.ConfigServerHostSection);

            _httpClientFactory = httpClientFactory;
        }

        #endregion

        #region Abstract methods

        protected abstract TResponse OnRun();

        #endregion

        #region Virtual methods

        public virtual TResponse Run()
        {
            var result = OnRun();

            return result;
        }

        public virtual Task<TResponse> RunAsync()
        {
            return Task.Run(() =>
            {
                var result = OnRun();

                return result;
            });
        }

        protected virtual HttpClient CreateHttpClient()
        {
            if (_httpClientFactory == null)
            {
                return new HttpClient();
            }

            var httpClient = _httpClientFactory.CreateClient();

            return httpClient;
        }

        protected virtual StringContent CreateContentForRequest(string dataToSend)
        {
            var content = new StringContent(dataToSend, Encoding.UTF8, Defaults.BasicContentTypeForRequest);

            return content;
        }

        protected virtual Uri CreateUriForRequest()
        {
            var uri = new Uri($"{HostAddress}/{Defaults.JsonDbName}");

            return uri;
        }

        protected virtual TResponse ConvertResponseToModel(string response)
        {
            var result = JsonConvert.DeserializeObject<TResponse>(response);

            return result;
        }

        protected virtual TConvertType ConvertResponseToModel<TConvertType>(string response) where TConvertType : class
        {
            var result = JsonConvert.DeserializeObject<TConvertType>(response);

            return result;
        }

        #endregion
    }
}
