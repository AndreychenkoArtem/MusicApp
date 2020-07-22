using System.Collections.Generic;
using System.Linq;
using FlexiMvvm.ViewModels;
using MusicApp.Core.Models.ArtistAlbums;

namespace MusicApp.Core.ViewModels.ArtistAlbums
{
    public class ArtistAlbumsItemViewModel : ViewModel
    {
        public ArtistAlbumsItemViewModel(string name, long playCount, List<Image> image)
        {
            Name = name;
            PlayCount = $"({playCount} plays)";
            Images = image;
            ImagePath = GetLargeImage();
        }

        public string Name { get; }

        public string PlayCount { get; }

        public string ImagePath { get; }

        public List<Image> Images { get; }

        private string GetLargeImage()
        {
            foreach (var item in Images.Where(item => item.Size == Size.Large))
            {
                return item.Text;
            }

            return string.Empty;
        }
    }
}