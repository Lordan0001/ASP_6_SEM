using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5a.Controllers
{
    public class MResearchController : Controller
    {
        //ERROR
        public string MXX()
        {
            return "MXX";
        }
        // /MResearch/M01/1
        // /MResearch/M01
        // /MResearch
        // /
        // /V2/MResearch/M01
        // /V3/MResearch/X/M01
        
        [HttpGet]
        public string M01()
        {
            return "GET:M01";
        }
        // /V2
        // /V2/MResearch
        // /V2/MResearch/M02
        // /MResearch/M02
        // /V3/MResearch/X/M02

        [HttpGet]
        public string M02()
        {
            return "GET:M02";
        }
        // /V3
        // /V3/MResearch/X/
        // /V3/MResearch/X/M03

        [HttpGet]
        public string M03()
        {
            return "GET:M03";
        }


    }
}