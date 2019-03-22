using AlbumsLibraryTest.BLL.Services.Commands;
using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using AlbumsLibraryTest.Core.Models.Buisiness;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlbumsLibraryTest.BLL.Services.Managers
{
    public class AlbumsCollectionManager : IAlbumsCollectionManager
    {
        #region Properties

        private IConfiguration _config { get; set; }
        private IHttpClientFactory _httpClientFactory { get; set; }

        #endregion

        #region Ctor

        public AlbumsCollectionManager(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        #region Methods

        public async Task<List<Album>> GetAlbumsCollectionAsync()
        {
            try
            {
                var command = new GetAlbumsFromJsonServerCommand(_config, _httpClientFactory);
                var result = await command.RunAsync();

                return result;
            }
            catch
            {
                return new List<Album>();
            }
        }

        #endregion
    }
}
