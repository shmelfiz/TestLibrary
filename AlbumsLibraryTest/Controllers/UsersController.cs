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
    public class UsersController : ControllerBase
    {
        #region Properties

        private IUsersManager _usersManager { get; set; }
        private IUsersCollectionManager _usersCollectionManager { get; set; }

        #endregion

        #region Ctor

        public UsersController(IUsersManager usersManager, IUsersCollectionManager usersCollectionManager)
        {
            _usersManager = usersManager;
            _usersCollectionManager = usersCollectionManager;
        }

        #endregion

        #region Index

        [HttpGet]
        public string Index()
        {
            return "Users controller";
        }

        #endregion

        #region Gets

        [HttpGet("get_all_users"), HttpGet("get_all_users/.{format?}")]
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _usersCollectionManager.GetUsersCollectionAsync();

            return users;
        }

        [HttpGet, Route("get_user_by_id/{id}.{format?}")]
        public async Task<User> GetUserById(long id)
        {
            var user = await _usersManager.GetUserByIdAsync(id);

            return user;
        }

        #endregion
    }
}