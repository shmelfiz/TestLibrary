using AlbumsLibraryTest.Core.Models.Buisiness;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumsLibraryTest.BLL.Managers.Interfaces
{
    public interface IUsersManager
    {
        Task<User> GetUserByIdAsync(long userId);
    }
}
