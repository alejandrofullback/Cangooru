using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace CangooruMVC.Models
{
    public class OrderModel
    {

    }

    public class CreateOrderModel
    {
        public CreateOrderModel()
        {
            DeliveryAddress = new List<AddressViewModel>();
        }
        [Display(Name = "Valor do Produto")]
        public string Value { get; set; }

        [Display(Name = "Local de Retirada")]
        public IEnumerable<AddressViewModel> WithDrawAddress { get; set; }

        [Display(Name = "Local de Entrega")]
        public IEnumerable<AddressViewModel> DeliveryAddress { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "O valor {0} não é valido")]
        [Display(Name = "Data da Retirada")]
        public DateTime DeliveryDateTime { get; set; }

        [Display(Name = "Tipo de entrega")]
        public string DeliveryType { get; set; }

        [Display(Name = "Comentarios")]
        public string Comments { get; set; }

        [Display(Name = "Entrega Expressa")]
        public bool ExpressDelivery { get; set; }

        [Display(Name = "Largura")]
        public decimal Width { get; set; }

        [Display(Name = "Comprimento")]
        public decimal Depth { get; set; }

        [Display(Name = "Altura")]
        public decimal Height { get; set; }

        [Display(Name = "Peso(Kg)")]
        public decimal Weight { get; set; }
    }
}