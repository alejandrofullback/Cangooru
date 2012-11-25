using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cangooru.Repositories.Interfaces;
using System.Data;

namespace Cangooru.Repositories.Location
{
    public class LocationRepository : ILocationRepository, IDisposable
    {
        CangooruEntities _entities;
        public LocationRepository()
        {
            _entities = new CangooruEntities();
        }

        public void AddUserLocation(cangooru_Location location)
        {
            _entities.AddTocangooru_Location(location);
            _entities.SaveChanges();
        }

        public void EditUserLocation(cangooru_Location location)
        {
            if (location.EntityState == EntityState.Detached)
                _entities.cangooru_Location.Attach(location);
            _entities.ObjectStateManager.ChangeObjectState(location, System.Data.EntityState.Modified);
            _entities.SaveChanges();
        }

        public IEnumerable<cangooru_Location> GetLocationsByUser(Guid userId)
        {
            return _entities.cangooru_Location.Where(loc => loc.UserAccountId == userId);
        }

        public cangooru_Location GetLocationsById(Guid locationId)
        {
            return _entities.cangooru_Location.SingleOrDefault(loc => loc.Id == locationId);
        }

        public void DeleteLocation(Guid locationId)
        {
            var location = _entities.cangooru_Location.Where(loc => loc.Id == locationId).SingleOrDefault();
            _entities.cangooru_Location.DeleteObject(location);
            _entities.SaveChanges();

        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}
