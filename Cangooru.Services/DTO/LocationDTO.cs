using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cangooru.Services.DTO
{
    public class LocationDTO
    {
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Number { get; set; }
        public string More { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public Guid UserAccountId { get; set; }
        public Guid locationId { get; set; }
    }
}
