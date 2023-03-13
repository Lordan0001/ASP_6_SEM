using LAB_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace LAB_2.Controllers
{
    public class DictController : Controller
    {
        // GET: Dict
        public ActionResult Index()
        {           
            List<DictModel> dictModels = new List<DictModel>();
            using(StreamReader r = new StreamReader(Server.MapPath("/DB/PhoneNumber.json")))
            {
                string json = r.ReadToEnd();
                dictModels = JsonConvert.DeserializeObject<List<DictModel>>(json);
                ViewBag.NumberList = dictModels;
            
            }
     
            ViewData["Head"] = "Привет мир!";
            ViewBag.Second = "Hey cruel world!";
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(int Id,string Name,string Number)
        {
            DictModel newDictModel = new DictModel();
            newDictModel.Id = Id;
            newDictModel.Name = Name;
            newDictModel.Number = Number;

            List<DictModel> dictModels = new List<DictModel>();
            using (StreamReader r = new StreamReader(Server.MapPath("/DB/PhoneNumber.json")))
            {
                string json = r.ReadToEnd();
                dictModels = JsonConvert.DeserializeObject<List<DictModel>>(json);
                dictModels.Add(newDictModel);
                json = JsonConvert.SerializeObject(dictModels, Formatting.Indented);//TODO Serialize this into file beach
                ViewBag.NumberList = dictModels;

            }




            return View("Index");
        }




    }
}