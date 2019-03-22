using AlbumsLibraryTest.BLL.Managers.Interfaces;
using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using AlbumsLibraryTest.Core.Models.Buisiness;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumsLibraryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController, FormatFilter]
    public class AlbumsController : ControllerBase
    {
        #region Properties

        private IAlbumsManager _albumsManager { get; set; }
        private IAlbumsCollectionManager _albumsCollectionManager { get; set; }

        #endregion

        #region Ctor

        public AlbumsController(IAlbumsManager albumsManager, IAlbumsCollectionManager albumsCollectionManager)
        {
            _albumsManager = albumsManager;
            _albumsCollectionManager = albumsCollectionManager;
        }

        #endregion

        #region Index

        [HttpGet]
        public string Index()
        {
            return "Albums controller";
        }

        #endregion

        #region Gets

        [HttpGet("get_all_albums"), HttpGet("get_all_albums/.{format?}")]
        public async Task<List<Album>> GetAllAlbums()
        {
            var albums = await _albumsCollectionManager.GetAlbumsCollectionAsync();

            return albums;
        }

        [HttpGet, Route("get_album_by_id/{id}.{format?}")]
        public async Task<Album> GetAlbumById(long id)
        {
            var album = await _albumsManager.GetAlbumById(id);

            return album;
        }

        [HttpGet, Route("get_albums_by_user_id/{id}.{format?}")]
        public async Task<List<Album>> GetAlbumsByUserd(long id)
        {
            var albums = await _albumsManager.GetUserAlbums(id);

            return albums;
        }

        #endregion
    }
}