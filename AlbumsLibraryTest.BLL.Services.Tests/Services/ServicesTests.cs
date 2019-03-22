using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using AlbumsLibraryTest.BLL.Services.Tests.Helper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace AlbumsLibraryTest.BLL.Services.Tests.Services
{
    public class ServicesTests
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
        public void UsersCollectionManagerTest()
        {
            var usersCollectionManager = ConfigurationHelper
                .services
                .BuildServiceProvider()
                .GetService<IUsersCollectionManager>();

            var users = usersCollectionManager.GetUsersCollectionAsync().Result;

            Assert.IsNotNull(users);
        }

        [Test]
        public void AlbumsCollectionManagerTest()
        {
            var usersCollectionManager = ConfigurationHelper
                .services
                .BuildServiceProvider()
                .GetService<IUsersCollectionManager>();

            var users = usersCollectionManager.GetUsersCollectionAsync().Result;

            Assert.IsNotNull(users);
        }

        #endregion
    }
}
