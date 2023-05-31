using LAB_2.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace LAB_2.App_Logic
{
    public class ManageDictionary
    {
        public List<DictModel> GetList()
        {
            List<DictModel> dictModels = new List<DictModel>();
            string jsonData = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/DB/PhoneNumber.json"));
            dictModels = JsonConvert.DeserializeObject<List<DictModel>>(jsonData);
            dictModels = dictModels.OrderBy(o => o.Name).ToList();
            return dictModels;
        }

        public DictModel CreateModel(int id, string name, string number)
        {
            DictModel newDictModel = new DictModel();
            newDictModel.Id = id;
            newDictModel.Name = name;
            newDictModel.Number = number;

            return newDictModel;
        }

        public void SerializeList(List<DictModel> model) {
            System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("/DB/PhoneNumber.json"), JsonConvert.SerializeObject(model));
        }

          
    }
}