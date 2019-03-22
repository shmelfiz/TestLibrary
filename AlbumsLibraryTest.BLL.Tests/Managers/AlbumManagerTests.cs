using AlbumsLibraryTest.BLL.Managers.Interfaces;
using AlbumsLibraryTest.BLL.Tests.Helper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace AlbumsLibraryTest.BLL.Tests.Managers
{
    public class AlbumManagerTests
    {
        #region Setup

        [SetUp]
        public void Setup()
        {
            ConfigurationHelper.Setup();
        }

        #endregion

        #region Tests

        [Test]
        public void GetAlbumByIdCommandTest()
        {
            var albumsManager = ConfigurationHelper
                .services
                .BuildServiceProvider()
                .GetService<IAlbumsManager>();

            var album = albumsManager.GetAlbumById(1);

            Assert.IsNotNull(album);
        }

        [Test]
        public void GetAlbumByUserId()
        {
            var albumsManager = ConfigurationHelper
                .services
                .BuildServiceProvider()
                .GetService<IAlbumsManager>();

            var album = albumsManager.GetUserAlbums(1);

            Assert.IsNotNull(album);
        }

        #endregion
    }
}
