using System.Collections.Generic;
using System.Linq;
using MusicApp.Core.Models.ArtistAlbums;
using Realms;

namespace MusicApp.Core.LocalStorage
{
    public class RealmLocalStorageService : IRealmLocalStorageService
    {
        private readonly Realm _realm;

        public RealmLocalStorageService()
        {
            _realm = Realm.GetInstance();
        }

        public void SaveArtistAlbumData(ArtistAlbumModel model)
        {
            var items = model.Topalbums.Album
                .Select(x => new ArtistAlbumsLocalModel(x.Name, x.Playcount, x.Image))
                .ToList();

            _realm.Write(() =>
            {
                foreach (var item in items)
                {
                    var localModel = _realm.Add(item, false);
                }
            });
        }

    }
}