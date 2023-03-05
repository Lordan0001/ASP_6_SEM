using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_1.Handlers
{
    public class Task6 : IHttpHandler
    {

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            if (request.HttpMethod == "GET")
            {
                response.ContentType = "text/html";
                response.WriteFile("~\\Forms\\form6.html");
            }
            else if (request.HttpMethod == "POST")
            {
                try
                {
                    int x = int.Parse(request.Form.Get("X")), y = int.Parse(request.Form.Get("Y"));

                    response.ContentType = "text/plain";
                    response.Write("MULT = " + (x * y));
                }
                catch (Exception ex)
                {
                    response.Write(ex.Message);
                }
            }
        }
    }
}