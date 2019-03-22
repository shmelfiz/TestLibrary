using AlbumsLibraryTest.BLL.Commands.Base;
using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using AlbumsLibraryTest.Core.Models.Buisiness;
using System.Linq;

namespace AlbumsLibraryTest.BLL.Commands.Albums
{
    public class GetAlbumByIdCommand : AlbumsLibraryBaseCommand<Album>
    {
        #region Properties

        private IAlbumsCollectionManager _albumsCollectionManager { get; set; }
        private long _albumId { get; set; }

        #endregion

        #region Ctor

        public GetAlbumByIdCommand(IAlbumsCollectionManager albumsCollectionManager, long albumId)
        {
            _albumsCollectionManager = albumsCollectionManager;
            _albumId = albumId;
        }

        #endregion

        #region Methods

        protected override Album OnRun()
        {
            var albums = _albumsCollectionManager
                .GetAlbumsCollectionAsync()
                .Result;

            var foundAlbum = albums
                .Where(album => album.Id.Equals(_albumId))
                .FirstOrDefault();

            return foundAlbum;
        }

        #endregion
    }
}
