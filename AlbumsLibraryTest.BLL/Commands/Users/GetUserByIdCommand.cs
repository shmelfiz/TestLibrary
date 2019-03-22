using AlbumsLibraryTest.BLL.Commands.Base;
using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using AlbumsLibraryTest.Core.Models.Buisiness;
using System.Linq;

namespace AlbumsLibraryTest.BLL.Commands.Users
{
    public class GetUserByIdCommand : AlbumsLibraryBaseCommand<User>
    {
        #region Properties

        private IUsersCollectionManager _usersCollectionManager { get; set; }
        private long _userId { get; set; }

        #endregion

        #region Ctor

        public GetUserByIdCommand(IUsersCollectionManager usersCollectionManager, long userId)
        {
            _usersCollectionManager = usersCollectionManager;
            _userId = userId;
        }

        #endregion

        #region Methods

        protected override User OnRun()
        {
            var users = _usersCollectionManager
                .GetUsersCollectionAsync()
                .Result;

            var foundUser = users
                .Where(user => user.Id.Equals(_userId))
                .FirstOrDefault();

            return foundUser;
        }

        #endregion
    }
}
