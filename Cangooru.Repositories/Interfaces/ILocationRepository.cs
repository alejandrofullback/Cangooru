using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cangooru.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        void AddUserLocation(cangooru_Location location);
        void EditUserLocation(cangooru_Location location);
        IEnumerable<cangooru_Location> GetLocationsByUser(Guid userId);
        cangooru_Location GetLocationsById(Guid locationId);
        void DeleteLocation(Guid locationId);
    }
}
