using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using MusicStoreDb.DataLayer;
using MusicStoreDb.Repositories;
using MusicStoreDb.Services.Controllers;

namespace MusicStoreDb.Services.DependencyResolvers
{
    public class MusicStoreDbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(AlbumsController))
            {
                var context = new MusicStoreDbEntities();
                var repository = new DbAlbumRepository(context);

                return new AlbumsController(repository);
            }
            else if (serviceType == typeof(ArtistsController))
            {
                var context = new MusicStoreDbEntities();
                var repository = new DbArtistRepository(context);

                return new ArtistsController(repository);
            }
            else if (serviceType == typeof(SongsController))
            {
                var context = new MusicStoreDbEntities();
                var repository = new DbSongRepository(context);

                return new SongsController(repository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}