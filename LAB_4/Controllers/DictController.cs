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
using LAB_2.DB;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace LAB_2.Controllers
{
    public class DictController : Controller//todo remove all json
    {

        MainContext maincontext = new MainContext();
        public ActionResult Index()
        {
 
            return View(maincontext.numbers.OrderBy(o=>o.Name));
        }
        
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddSave([Bind(Include ="Id,Name,Number")] Phonebook phonebook)
        {
            if(ModelState.IsValid)
            {
                maincontext.numbers.Add(phonebook);
                maincontext.SaveChangesAsync();
                return Redirect("/Dict/Index");
                //return RedirectToAction("Index");
            }
            ViewBag.Error = "Failed to add"; 
            return View("ValidError");
        }

        public ActionResult Update(int? id)
        {
            Phonebook phonebook = maincontext.numbers.Find(id);
            return View(phonebook);
        }
        [HttpPost]
        public ActionResult UpdateSave([Bind(Include ="Id,Name,Number")] Phonebook phonebook)
        {
            if(ModelState.IsValid)
            {
                maincontext.Entry(phonebook).State = EntityState.Modified;
                maincontext.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect("/Dict/Index");

            }
            ViewBag.Error = "Failed to edit";
            return View("ValidError");
        }

        public ActionResult Delete(int? id)
        {
            Phonebook phonebook = new Phonebook();
            phonebook = maincontext.numbers.Find(id);

            return View(phonebook);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteSave(int? id)
        {
            Phonebook phonebook = maincontext.numbers.Find(id);
            maincontext.numbers.Remove(phonebook);
            maincontext.SaveChanges();
            //return RedirectToAction("Index");
            return Redirect("/Dict/Index");

        }
    }
}
