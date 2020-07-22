using System.Text;

namespace MusicApp.Core.AppConfig
{
    /// <summary>
    /// App configuration class
    /// </summary>
    public class AppConfig : IAppConfig
    {
        public AppConfig()
        {
            // LastFmApiLink = "https://ws.audioscrobbler.com/2.0/?method=geo.gettopartists&country=";
            // ApiKey = "&api_key=fa91b7067617e8017f1daf354e2fb45e";
            // Format = "&format=json";
        }

        private string LastFmApiLink { get; }

        private string ApiKey { get; }

        private string Format { get; }

        public string GetLink(string country)
        {
            var link = $"{LastFmApiLink}{country}{ApiKey}{Format}";
            return link;
        }
    }
}