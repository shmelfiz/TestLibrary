using AlbumsLibraryTest.Core.Models.Buisiness;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumsLibraryTest.BLL.Services.Managers.Interfaces
{
    public interface IAlbumsCollectionManager
    {
        Task<List<Album>> GetAlbumsCollectionAsync();
    }
}
