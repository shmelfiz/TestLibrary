using AlbumsLibraryTest.BLL.Services.Commands.Base;
using AlbumsLibraryTest.Core.Models.Buisiness;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace AlbumsLibraryTest.BLL.Services.Commands
{
    public class GetAlbumsFromJsonServerCommand : AlbumsLibraryServicesBaseCommand<List<Album>>
    {
        #region Ctor

        public GetAlbumsFromJsonServerCommand(IConfiguration configuration, IHttpClientFactory httpClientFactory)
            : base(configuration, httpClientFactory)
        {
        }

        #endregion

        #region Methods

        protected override List<Album> OnRun()
        {
            var uri = base.CreateUriForRequest();

            var content = base.CreateContentForRequest(string.Empty);

            var httpClient = base.CreateHttpClient();

            var request = (HttpWebRequest)WebRequest.Create(uri);
            var response = request.GetResponse();

            var responseContent = string.Empty;
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                responseContent = streamReader.ReadToEnd();
            }

            var result = base.ConvertResponseToModel<DbModel>(responseContent);

            return result.Albums;
        }

        #endregion
    }
}
