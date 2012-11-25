using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CangooruMVC.Models;
using System.Net;
using System.IO;
using System.Text;
using HtmlAgilityPack;
using System.Web.Helpers;
using System.Web.Security;
using Cangooru.Services.Interfaces;
using Cangooru.Services.DTO;
using System.Web.UI;

namespace CangooruMVC.Controllers
{
    public class LocationsController : Controller
    {
        private ILocationsService _locationsService;
        public LocationsController(ILocationsService service)
        {
            _locationsService = service;
        }

        //
        // GET: /Locations/
        public ActionResult Index(bool showEditColumns)
        {
            var userId = Membership.GetUser().ProviderUserKey;
            var response = _locationsService.GetLocationByUser((Guid)userId);
            List<LocationDTO> locations = (List<LocationDTO>)response.Values;
            var model = new UserLocations();
            model.UserId = (Guid)userId;
            model.Locations = locations.Select(loc => new AddressViewModel
            {
                CEP = loc.CEP,
                LocationId = loc.locationId,
                More = loc.More,
                Neighborhood = loc.Neighborhood,
                Number = loc.Number,
                Street = loc.Street,
                UF = loc.UF,
                City = loc.City,
                Address = loc.Street + " , " + loc.Number
            });
            model.ShowEditColumns = showEditColumns;
            return PartialView("Locations", model);
        }

        //
        // GET: /Locations/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Locations/Create

        public ActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.Title = "Nova Localidade";
            return PartialView("AddLocation", new AddressViewModel());
        }

        //
        // POST: /Locations/Create

        [HttpPost]
        public ActionResult Create(AddressViewModel model)
        {
            var userId = Membership.GetUser().ProviderUserKey;
            var response = _locationsService.CreateLocation(
                new Cangooru.Services.DTO.LocationDTO
                {
                    CEP = model.CEP,
                    City = model.City,
                    More = model.More,
                    Neighborhood = model.Neighborhood,
                    Number = model.Number,
                    Street = model.Street,
                    UF = model.UF,
                    UserAccountId = (Guid)userId
                });

            return Json(response);
        }

        //
        // GET: /Locations/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid locationId)
        {
            var location = (LocationDTO)_locationsService.GetLocationById(locationId).Values;
            ViewBag.Action = "Edit";
            ViewBag.Title = "Editar Localidade";
            return PartialView("AddLocation", new AddressViewModel
            {
                CEP = location.CEP,
                LocationId = location.locationId,
                More = location.More,
                Neighborhood = location.Neighborhood,
                Number = location.Number,
                Street = location.Street,
                UF = location.UF,
                City = location.City,
                Address = location.Street + " , " + location.Number
            });
        }

        //
        // POST: /Locations/Edit/5

        [HttpPost]
        public ActionResult Edit(AddressViewModel model)
        {
            var userId = Membership.GetUser().ProviderUserKey;
            var response = _locationsService.EditLocation(
                new Cangooru.Services.DTO.LocationDTO
                {
                    locationId = model.LocationId,
                    CEP = model.CEP,
                    City = model.City,
                    More = model.More,
                    Neighborhood = model.Neighborhood,
                    Number = model.Number,
                    Street = model.Street,
                    UF = model.UF,
                    UserAccountId = (Guid)userId
                });
            return Json(response);
        }


        //
        // POST: /Locations/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid locationId)
        {
            var response = _locationsService.DeleteLocation(locationId);
            return Json(response);
        }

        [HttpPost]
        public JsonResult GetAddressInfo(string cep)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://m.correios.com.br/movel/buscaCepConfirma.do?cepEntrada=" + cep + "&tipoCep=&cepTemp=&metodo=buscarCep");
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = WebRequestMethods.Http.Post;
            request.Timeout = 30000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.Default);
            string result = readStream.ReadToEnd();
            var html = new HtmlDocument();
            html.LoadHtml(result);
            var street = html.DocumentNode.SelectNodes("//*[@class='caixacampobranco']/span[2]").FirstOrDefault().InnerText.Split('-')[0].Trim();
            var neighborhood = html.DocumentNode.SelectNodes("//*[@class='caixacampobranco']/span[4]").FirstOrDefault().InnerText.Trim();
            var city = html.DocumentNode.SelectNodes("//*[@class='caixacampobranco']/span[6]").FirstOrDefault().InnerText.Split('/')[0].Trim();
            var uf = html.DocumentNode.SelectNodes("//*[@class='caixacampobranco']/span[6]").FirstOrDefault().InnerText.Split('/')[1].Trim();
            response.Close();
            readStream.Close();
            return Json(new { street = street, neighborhood = neighborhood, city = city, uf = uf });
        }

        [HttpPost]
        public ActionResult UpdateLocationsGrid(bool showEditColumns)
        {
            return PartialView("LocationsGrid", LoadLocationsModel(showEditColumns));
        }

        private UserLocations LoadLocationsModel(bool showEditColumns)
        {
            var userId = Membership.GetUser().ProviderUserKey;
            var response = _locationsService.GetLocationByUser((Guid)userId);
            List<LocationDTO> locations = (List<LocationDTO>)response.Values;
            var model = new UserLocations();
            model.UserId = (Guid)userId;
            model.Locations = locations.Select(loc => new AddressViewModel
            {
                CEP = loc.CEP,
                LocationId = loc.locationId,
                More = loc.More,
                Neighborhood = loc.Neighborhood,
                Number = loc.Number,
                Street = loc.Street,
                UF = loc.UF,
                City = loc.City,
                Address = loc.Street + " , " + loc.Number
            });
            model.ShowEditColumns = showEditColumns;
            return model;
        }
    }
}
