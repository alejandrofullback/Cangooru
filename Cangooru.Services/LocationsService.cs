using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cangooru.Services.Interfaces;
using Cangooru.Services.Request;
using Cangooru.Repositories.Interfaces;

namespace Cangooru.Services
{
    public class LocationsService : ILocationsService
    {
        ILocationRepository _repository;
        public LocationsService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public CangooruResponse CreateLocation(DTO.LocationDTO dto)
        {
            try
            {
                _repository.AddUserLocation(new Repositories.cangooru_Location
                {
                    Id = Guid.NewGuid(),
                    Address = dto.Street + " , " + dto.Number,
                    AddressExtraInfo = dto.More,
                    CEP = dto.CEP,
                    Neightborhood = dto.Neighborhood,
                    UserAccountId = dto.UserAccountId,
                    ContactName = "",
                    LocationType = 1,
                    RegionId = new Guid("815B3E05-A73C-4FD7-92D7-46B96924322B")
                });
                return new CangooruResponse { Status = RequestStatus.Success, Values = null };
            }
            catch
            {
                return new CangooruResponse { Status = RequestStatus.Fail, Values = null };
            }
        }

        public CangooruResponse EditLocation(DTO.LocationDTO dto)
        {
            try
            {
                _repository.EditUserLocation(new Repositories.cangooru_Location
                {
                    Id = dto.locationId,
                    Address = dto.Street + " , " + dto.Number,
                    AddressExtraInfo = dto.More,
                    CEP = dto.CEP,
                    Neightborhood = dto.Neighborhood,
                    UserAccountId = dto.UserAccountId,
                    ContactName = "",
                    LocationType = 1,
                    RegionId = new Guid("815B3E05-A73C-4FD7-92D7-46B96924322B")
                });
                return new CangooruResponse { Status = RequestStatus.Success, Values = null };
            }
            catch
            {
                return new CangooruResponse { Status = RequestStatus.Fail, Values = null };
            }
        }

        public CangooruResponse GetLocationByUser(Guid userId)
        {
            var locations = _repository.GetLocationsByUser(userId);
            var locationsDto = locations.Select(loc => new DTO.LocationDTO
            {
                CEP = loc.CEP,
                More = loc.AddressExtraInfo,
                Neighborhood = loc.Neightborhood,
                Number = loc.Address.Split(',')[1].Trim(),
                Street = loc.Address.Split(',')[0].Trim(),
                UF = loc.cangooru_Region.State,
                City = loc.cangooru_Region.Name,
                locationId = loc.Id
            });
            return new CangooruResponse { Status = RequestStatus.Success, Values = locationsDto.ToList() };
        }

        public CangooruResponse GetLocationById(Guid locationId)
        {
            var location = _repository.GetLocationsById(locationId);
            var locationDto =  new DTO.LocationDTO
            {
                CEP = location.CEP,
                More = location.AddressExtraInfo,
                Neighborhood = location.Neightborhood,
                Number = location.Address.Split(',')[1].Trim(),
                Street = location.Address.Split(',')[0].Trim(),
                UF = location.cangooru_Region.State,
                City = location.cangooru_Region.Name,
                locationId = location.Id
            };
            return new CangooruResponse { Status = RequestStatus.Success, Values = locationDto };
        }

        public CangooruResponse DeleteLocation(Guid locationId)
        {
            try
            {
                _repository.DeleteLocation(locationId);
                return new CangooruResponse { Status = RequestStatus.Success, Values = null };
            }
            catch
            {
                return new CangooruResponse { Status = RequestStatus.Fail, Values = null };
            }
        }
    }
}
