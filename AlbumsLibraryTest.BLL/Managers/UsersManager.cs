using AlbumsLibraryTest.BLL.Commands.Users;
using AlbumsLibraryTest.BLL.Managers.Interfaces;
using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using AlbumsLibraryTest.Core.Models.Buisiness;
using System.Threading.Tasks;

namespace AlbumsLibraryTest.BLL.Managers
{
    public class UsersManager : IUsersManager
    {
        #region Properties

        private IUsersCollectionManager _usersCollectionManager { get; set; }

        #endregion

        #region Ctor

        public UsersManager(IUsersCollectionManager usersCollectionManager)
        {
            _usersCollectionManager = usersCollectionManager;
        }

        #endregion

        #region Methods

        public async Task<User> GetUserByIdAsync(long userId)
        {
            try
            {
                var command = new GetUserByIdCommand(_usersCollectionManager, userId);
                var result = await command.RunAsync();

                return result;
            }
            catch
            {
                return new User();
            }
        }

        #endregion
    }
}
