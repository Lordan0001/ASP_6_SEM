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
using LAB_2.App_Logic;

namespace LAB_2.Controllers
{
    public class DictController : Controller
    {
        ManageDictionary manageDict = new ManageDictionary();
        public ActionResult Index()
        {
            ViewBag.NumberList = manageDict.GetList();
            ViewBag.Second = "List of phone numbers";
            return View("Index");
        }

        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult AddSave(int id, string name, string number)
        {
            List<DictModel> dictModels = new List<DictModel>();
            dictModels = manageDict.GetList();

            DictModel newDictModel = manageDict.CreateModel(id, name, number);

            foreach (var item in dictModels)
            {
                if (item.Id == newDictModel.Id || item.Number == newDictModel.Number)
                {
                    ViewBag.Error = "user with this id or number alredy exist!";
                    return View("ValidError");
                }
            }
            dictModels.Add(newDictModel);
            manageDict.SerializeList(dictModels);
            ViewBag.NumberList = dictModels;

            return Redirect("/Dict/Index");
        }

        public ActionResult Update()
        {
            return View("Update");
        }
        [HttpPost]
        public ActionResult UpdateSave(int id, string name, string number)
        {
            List<DictModel> dictModels = new List<DictModel>();


            dictModels = manageDict.GetList();

            foreach (DictModel dictModel in dictModels)
            {
                if (dictModel.Id == id)
                {
                    dictModel.Name = name;
                    dictModel.Number = number;
                    ViewBag.Error = "No user with this id";
                    ViewBag.NumberList = dictModels;
                    manageDict.SerializeList(dictModels);
                    return Redirect("/Dict/Index");
                }

            }
            return View("ValidError");

        }

        public ActionResult Delete()
        {

            return View("Delete");
        }
        [HttpPost]
        public ActionResult DeleteSave(int id)
        {

            List<DictModel> dictModels = new List<DictModel>();


            dictModels = manageDict.GetList();

            foreach (DictModel dictModel in dictModels)
            {
                if (dictModel.Id == id)
                {
                    dictModels.Remove(dictModel);
                    ViewBag.NumberList = dictModels;
                    manageDict.SerializeList(dictModels);
                    return Redirect("/Dict/Index");
                }

            }
            ViewBag.Error = "No user to delete. Check id";
            return View("ValidError");

        }
    }
}
