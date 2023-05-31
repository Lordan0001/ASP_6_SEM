using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB_5.Controllers
{
    public class CResearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET:     /CResearch
        ///CResearch?param=value&param2=value2
        //          /CResearch/C01
        [AcceptVerbs("post", "get")]
        public ActionResult C01()
        {
            HttpContextBase c = this.HttpContext;
            HttpRequestBase rq = c.Request;
            ViewBag.Request = rq;
            return View();
        }



        // GET:     /CResearch/C02
        [AcceptVerbs("post", "get")]
        public ActionResult C02()
        {
            HttpContextBase c = this.HttpContext;
            HttpResponseBase rs = c.Response;
            ViewBag.Response = rs;
            return View();
        }
    }
}