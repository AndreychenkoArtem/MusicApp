using System.Collections.Generic;
using System.Linq;
using FlexiMvvm.ViewModels;
using MusicApp.Core.Models.TopArtists;

namespace MusicApp.Core.ViewModels.MainMusic
{
    public class MainMusicItemViewModel : ViewModel
    {
        public MainMusicItemViewModel(string artistName, string listeners, List<Image> artistImages)
        {
            ArtistName = artistName;
            Listeners = $"({listeners} listeners)";
            ArtistImages = artistImages;
            ImagePath = GetLargeImage();
        }

        public string ArtistName { get; }

        public string Listeners { get; }

        public string ImagePath { get; }

        private List<Image> ArtistImages { get; }

        private string GetLargeImage()
        {
            foreach (var item in ArtistImages.Where(item => item.Size == Size.Large))
            {
                return item.Text.ToString();
            }

            return string.Empty;
        }
    }
}