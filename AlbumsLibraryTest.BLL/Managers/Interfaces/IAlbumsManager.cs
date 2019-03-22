using AlbumsLibraryTest.Core.Models.Buisiness;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumsLibraryTest.BLL.Managers.Interfaces
{
    public interface IAlbumsManager
    {
        Task<Album> GetAlbumById(long albumId);
        Task<List<Album>> GetUserAlbums(long userId);
    }
}
