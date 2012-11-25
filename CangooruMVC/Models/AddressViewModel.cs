using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace CangooruMVC.Models
{
    public class AddressViewModel
    {
        [Required]
        [StringLength(9, ErrorMessage = "O {0} deve ter {2} caracteres.", MinimumLength = 8)]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Required]
        [Display(Name = "Rua")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        public string Neighborhood { get; set; }

        [Required]
        [Display(Name = "Número")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Complemento")]
        public string More { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Required]
        [Display(Name = "UF")]
        public string UF { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }

        public Guid LocationId { get; set; }
    }

    public class UserLocations
    {
        public IEnumerable<AddressViewModel> Locations { get; set; }
        public Guid UserId { get; set; }
        public bool ShowEditColumns { get; set; }
    }

}
