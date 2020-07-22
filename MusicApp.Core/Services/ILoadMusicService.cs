using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Core.Models.ArtistAlbums;
using MusicApp.Core.Models.TopArtists;

namespace MusicApp.Core.Services
{
    public interface ILoadMusicService
    {
        Task<ArtistsModel> GetTopArtistsAsync(string url);

        Task<ArtistAlbumModel> GetTopArtistAlbumsAsync(string name);
    }
}