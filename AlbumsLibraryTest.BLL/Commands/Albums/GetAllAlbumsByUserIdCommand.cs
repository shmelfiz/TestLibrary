using AlbumsLibraryTest.BLL.Commands.Base;
using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using AlbumsLibraryTest.Core.Models.Buisiness;
using System.Collections.Generic;
using System.Linq;

namespace AlbumsLibraryTest.BLL.Commands.Albums
{
    public class GetAllAlbumsByUserIdCommand : AlbumsLibraryBaseCommand<List<Album>>
    {
        #region Properties

        private IAlbumsCollectionManager _albumsCollectionManager { get; set; }
        private long _userId { get; set; }

        #endregion

        #region Ctor

        public GetAllAlbumsByUserIdCommand(IAlbumsCollectionManager albumsCollectionManager, long userId)
        {
            _albumsCollectionManager = albumsCollectionManager;
            _userId = userId;
        }

        #endregion

        #region Methods

        protected override List<Album> OnRun()
        {
            var albums = _albumsCollectionManager
                .GetAlbumsCollectionAsync()
                .Result;

            var foundAlbums = albums
                .Where(album => album.UserId.Equals(_userId))
                .ToList();

            return foundAlbums;
        }

        #endregion
    }
}
