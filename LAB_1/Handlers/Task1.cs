using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace LAB_1.Handlers
{
    public class Task1 : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }


        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            response.ContentType = "text/plain";
            response.StatusCode = 200;
            response.Write("GET-Http-BVD:ParmA = " + request.QueryString.Get("ParmA") + " ParmB = " + request.QueryString.Get("ParmB"));
            //https://localhost:44331/BVD/Task1?ParmA=www&ParmB=rrr


        }
    }
}