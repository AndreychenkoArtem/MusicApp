using FlexiMvvm.ViewModels;

namespace MusicApp.Core.ViewModels.ArtistAlbums
{
    public class ArtistAlbumsParameters : Parameters
    {
        public ArtistAlbumsParameters(string artistName)
        {
            ArtistName = artistName;
        }

        public string ArtistName
        {
            get => Bundle.GetString();
            private set => Bundle.SetString(value);
        }
    }
}