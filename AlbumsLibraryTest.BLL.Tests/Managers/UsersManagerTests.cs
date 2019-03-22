using AlbumsLibraryTest.BLL.Managers.Interfaces;
using AlbumsLibraryTest.BLL.Tests.Helper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace AlbumsLibraryTest.BLL.Tests.Managers
{
    public class UsersManagerTests
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
        public void GetUserByIdCommandTest()
        {
            var usersManager = ConfigurationHelper
                .services
                .BuildServiceProvider()
                .GetService<IUsersManager>();

            var album = usersManager.GetUserByIdAsync(1);

            Assert.IsNotNull(album);
        }

        #endregion
    }
}
