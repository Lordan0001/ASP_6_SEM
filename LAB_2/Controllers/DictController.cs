using LAB_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Ajax.Utilities;
using System.Xml.Linq;

namespace LAB_2.Controllers
{
    public class DictController : Controller
    {
        public List<DictModel> DeserializeJson()
        {
            List<DictModel> dictModels = new List<DictModel>();
            string jsonData = System.IO.File.ReadAllText(Server.MapPath("/DB/PhoneNumber.json"));
            dictModels = JsonConvert.DeserializeObject<List<DictModel>>(jsonData);
            return dictModels;
        }
        // GET: Dict
        public ActionResult Index()
        {
            ViewBag.NumberList = DeserializeJson();
            //ViewData["Head"] = "Привет мир!";
            ViewBag.Second = "list of phone numbers";
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(int Id, string Name, string Number)
        {
            DictModel newDictModel = new DictModel();
            newDictModel.Id = Id;
            newDictModel.Name = Name;
            newDictModel.Number = Number;

            List<DictModel> dictModels = new List<DictModel>();
 
            string jsonData = System.IO.File.ReadAllText(Server.MapPath("/DB/PhoneNumber.json"));
            dictModels = JsonConvert.DeserializeObject<List<DictModel>>(jsonData);
            dictModels.Add(newDictModel);
            System.IO.File.WriteAllText(Server.MapPath("/DB/PhoneNumber.json"), JsonConvert.SerializeObject(dictModels));
            ViewBag.NumberList = dictModels;

            return View("Index");
        }

        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSave(int id,string name,string number)
        {
            List<DictModel> dictModels = new List<DictModel>();

            string jsonData = System.IO.File.ReadAllText(Server.MapPath("/DB/PhoneNumber.json"));
            dictModels = JsonConvert.DeserializeObject<List<DictModel>>(jsonData);

            foreach (DictModel dictModel in dictModels) {
                if (dictModel.Id == id) { 
                    dictModel.Name = name;
                    dictModel.Number = number;
                }
            }
            ViewBag.NumberList = dictModels;
            System.IO.File.WriteAllText(Server.MapPath("/DB/PhoneNumber.json"), JsonConvert.SerializeObject(dictModels));

            return View("Index");
        }

        public ActionResult Delete() { 
        
            return View();
        }

        public ActionResult DeleteSave(int id)
        {

            List<DictModel> dictModels = new List<DictModel>();

            string jsonData = System.IO.File.ReadAllText(Server.MapPath("/DB/PhoneNumber.json"));
            dictModels = JsonConvert.DeserializeObject<List<DictModel>>(jsonData);

            foreach (DictModel dictModel in dictModels)
            {
                if (dictModel.Id == id)
                {
                    dictModels.Remove(dictModel);
                    break;
                   
                }
            }
            ViewBag.NumberList = dictModels;
            System.IO.File.WriteAllText(Server.MapPath("/DB/PhoneNumber.json"), JsonConvert.SerializeObject(dictModels));


            return View("Index");
        }
    }
}


//temp cringe desirialize
/*         using (StreamReader r = new StreamReader(Server.MapPath("/DB/PhoneNumber.json")))
         {
             string json = r.ReadToEnd();
             dictModels = JsonConvert.DeserializeObject<List<DictModel>>(json);
             ViewBag.NumberList = dictModels;

         }*/