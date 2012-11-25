using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cangooru.Services.DTO;
using Cangooru.Services.Request;

namespace Cangooru.Services.Interfaces
{
    public interface ILocationsService
    {
        CangooruResponse CreateLocation(LocationDTO dto);
        CangooruResponse EditLocation(LocationDTO dto);
        CangooruResponse GetLocationByUser(Guid userId);
        CangooruResponse GetLocationById(Guid locationId);
        CangooruResponse DeleteLocation(Guid locationId);
    }
}
