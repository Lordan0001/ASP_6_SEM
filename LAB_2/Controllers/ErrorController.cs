using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB_2.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public void ErrorPage()
        {
            string method = HttpContext.Request.HttpMethod;
            Response.Write(method+ " : "+ Request.RawUrl + "- не поддерживатеся");
        }


    }
}