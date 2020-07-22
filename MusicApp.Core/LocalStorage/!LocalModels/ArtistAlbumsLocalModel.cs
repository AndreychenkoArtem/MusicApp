using System.Collections.Generic;
using MusicApp.Core.Models.ArtistAlbums;
using Realms;

namespace MusicApp.Core.LocalStorage
{
    public class ArtistAlbumsLocalModel : RealmObject
    {
        public ArtistAlbumsLocalModel(string name, long playCount, List<Image> image)
        {
            Name = name;
            PlayCount = playCount;
            Images = image;
        }

        public string Name { get; }

        public long PlayCount { get; }

        public List<Image> Images { get; }
    }
}