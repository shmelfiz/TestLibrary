using AlbumsLibraryTest.BLL.Services.Commands.Base;
using AlbumsLibraryTest.Core.Models.Buisiness;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;

namespace AlbumsLibraryTest.BLL.Services.Commands
{
    public class GetUsersFromJsonServerCommand : AlbumsLibraryServicesBaseCommand<List<User>>
    {
        #region Ctor

        public GetUsersFromJsonServerCommand(IConfiguration configuration, IHttpClientFactory httpClientFactory) 
            : base(configuration, httpClientFactory)
        {
        }

        #endregion

        #region Methods

        protected override List<User> OnRun()
        {
            var uri = base.CreateUriForRequest();

            var content = base.CreateContentForRequest(string.Empty);

            var httpClient = base.CreateHttpClient();

            var response = httpClient.GetAsync(uri).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            var result = base.ConvertResponseToModel<DbModel>(responseString);

            return result.Users;
        }

        #endregion
    }
}
