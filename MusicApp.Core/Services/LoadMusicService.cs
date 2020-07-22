using System;
using System.Net.Http;
using System.Threading.Tasks;
using MusicApp.Core.Models.ArtistAlbums;
using MusicApp.Core.Models.TopArtists;

namespace MusicApp.Core.Services
{
    /// <summary>
    /// Simple service for fetching data
    /// Hardcoded strings only for test project and for time saving
    /// </summary>
    public class LoadMusicService : ILoadMusicService
    {
        private readonly HttpClient _httpClient;

        public LoadMusicService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ArtistsModel> GetTopArtistsAsync(string country)
        {
            var url = $"https://ws.audioscrobbler.com/2.0/?method=geo.gettopartists&country={country}&api_key=fa91b7067617e8017f1daf354e2fb45e&format=json";
            try
            {
                var response = await _httpClient.GetStringAsync(new Uri(url));
                var result = ArtistsModel.FromJson(response);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ArtistAlbumModel> GetTopArtistAlbumsAsync(string name)
        {
            var url = $"https://ws.audioscrobbler.com/2.0/?method=artist.gettopalbums&artist={name}&api_key=fa91b7067617e8017f1daf354e2fb45e&format=json";
            try
            {
                var response = await _httpClient.GetStringAsync(new Uri(url));
                var result = ArtistAlbumModel.FromJson(response);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}