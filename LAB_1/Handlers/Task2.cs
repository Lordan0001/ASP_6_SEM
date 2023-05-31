﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LAB_1.Handlers
{
    public class Task2 : IHttpHandler
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
            response.Write("POST-Http-BVD:ParmA = " + request.Form.Get("ParmA") + " ParmB = " + request.Form.Get("ParmB"));

        }
    }
}