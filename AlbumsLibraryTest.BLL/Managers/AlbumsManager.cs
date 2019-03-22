using AlbumsLibraryTest.BLL.Commands.Albums;
using AlbumsLibraryTest.BLL.Managers.Interfaces;
using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using AlbumsLibraryTest.Core.Models.Buisiness;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumsLibraryTest.BLL.Managers
{
    public class AlbumsManager : IAlbumsManager
    {
        #region Properties

        private IAlbumsCollectionManager _albumsCollectionManager { get; set; }

        #endregion

        #region Ctor

        public AlbumsManager(IAlbumsCollectionManager albumsCollectionManager)
        {
            _albumsCollectionManager = albumsCollectionManager;
        }

        #endregion

        #region Methods

        public async Task<Album> GetAlbumById(long albumId)
        {
            try
            {
                var command = new GetAlbumByIdCommand(_albumsCollectionManager, albumId);
                var result = await command.RunAsync();

                return result;
            }
            catch(Exception e)
            {
                return new Album();
            }
        }

        public async Task<List<Album>> GetUserAlbums(long userId)
        {
            try
            {
                var command = new GetAllAlbumsByUserIdCommand(_albumsCollectionManager, userId);
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
