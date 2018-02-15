using Newtonsoft.Json;
using SerializationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SerializationExample.Controllers
{
    public class HomeController : Controller
    {
        public Car MyCar => new Car() { ID = 1232, Make = "Honda", Model = "Civic", Year = 2018 };


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }


        public string Examplewithjson()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var cerealCar = js.Serialize(MyCar);
            cerealCar = cerealCar.ToLower();
            return cerealCar;
        }


        [HttpPost]
        public JsonResult ParsePayload(string lib, string payload)
        {
            var car = new Car();
            switch (lib)
            {
                case "1":
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    car = (Car)js.Deserialize(payload, typeof(Car));
                    break;
                case "2":
                    car = (Car)JsonConvert.DeserializeObject(payload, typeof(Car));
                    break;
            }
            return Json(car, JsonRequestBehavior.AllowGet);
        }

        public string Examplewithnsoft()
        {
            var t = JsonConvert.SerializeObject(MyCar);
            var cerealCar = t.Replace("ID", "id").Replace("Model", "model");
            return cerealCar;
        }
    }
}
