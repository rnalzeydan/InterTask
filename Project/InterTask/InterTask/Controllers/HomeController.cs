using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using InterTask.Models.ViewModel;

namespace InterTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WeatherVM weatherVM = new WeatherVM();
            weatherVM.Cites = new List<SelectListItem>();
           
            weatherVM.Cites.Add(new SelectListItem() { Text = "Select City", Value = "0", Selected = true, Disabled=true});
            weatherVM.Cites.Add(new SelectListItem() { Text = "Riyadh", Value = "Riyadh"});
            weatherVM.Cites.Add(new SelectListItem() { Text = "Madinah", Value = "Madinah" });
            weatherVM.Cites.Add(new SelectListItem() { Text = "Jeddah", Value = "Jeddah"});
            weatherVM.Cites.Add(new SelectListItem() { Text = "Dammam", Value = "Dammam"});

            return View(weatherVM);
        }


        [HttpPost]
        public ActionResult Weather(string city)
        {
            WeatherVM weatherVM = new WeatherVM();

            //Assign API KEY which received from OPENWEATHERMAP.ORG  
            string appId = "XXXXXXXXX";

            // API path with CITY parameter and other parameters.
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", city, appId);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                // Converting to OBJECT from JSON string.
                OpenweatherapiJSON weatherInfo = (new JavaScriptSerializer()).Deserialize<OpenweatherapiJSON>(json);

                weatherVM.CityWeather = weatherInfo.main;
            }
            
            return PartialView("_WeatherResult", weatherVM);
        }

        [HttpPost]
        public ActionResult SaveWeatherResult(JSONData w)
        {
            ServiceReference.InterTaskWebServiceSoapClient client = new ServiceReference.InterTaskWebServiceSoapClient();
            int result = client.SaveSearchResult(w.humidity, w.temp_max, w.temp_min, System.Web.HttpContext.Current.Session["username"].ToString(), w.city);
            return View();
        }

        [OutputCache(Duration=60)]
        public ActionResult Results()
        {
            ServiceReference.InterTaskWebServiceSoapClient client = new ServiceReference.InterTaskWebServiceSoapClient();
            DataSet ds = client.GetSearchResults(System.Web.HttpContext.Current.Session["username"].ToString());
            return View(ds);
        }

        [HttpPost]
        public ActionResult DeleteSelected(ResultsVM ch)
        {
            ServiceReference.InterTaskWebServiceSoapClient client = new ServiceReference.InterTaskWebServiceSoapClient();
            //int result = client.DeleteRecords(ch.data);
            return View();
        }

    }
}