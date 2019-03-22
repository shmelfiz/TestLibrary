using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AlbumsLibraryTest.BLL.Services.Commands;
using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using AlbumsLibraryTest.Core.Models.Buisiness;
using Microsoft.Extensions.Configuration;

namespace AlbumsLibraryTest.BLL.Services.Managers
{
    public class UsersCollectionManager : IUsersCollectionManager
    {
        #region Properties

        private IConfiguration _config { get; set; }
        private IHttpClientFactory _httpClientFactory { get; set; }

        #endregion

        #region Ctor

        public UsersCollectionManager(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        #region Methods

        public async Task<List<User>> GetUsersCollectionAsync()
        {
            try
            {
                var command = new GetUsersFromJsonServerCommand(_config, _httpClientFactory);
                var result = await command.RunAsync();

                return result;
            }
            catch(Exception e)
            {
                return new List<User>();
            }
        }

        #endregion
    }
}
