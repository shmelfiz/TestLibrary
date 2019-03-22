using AlbumsLibraryTest.Core.Models.Buisiness;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumsLibraryTest.BLL.Services.Managers.Interfaces
{
    public interface IUsersCollectionManager
    {
        Task<List<User>> GetUsersCollectionAsync();
    }
}
