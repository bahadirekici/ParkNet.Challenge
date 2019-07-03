using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ParkNet.Challenge.Web.Classes;
using ParkNet.Challenge.Web.Models;

namespace ParkNet.Challenge.Web.Controllers
{
    public class HomeController : Controller
    {
        IHostingEnvironment _environment;
        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            var xmlReader = new MobyXMLReader();
            var webPath = _environment.WebRootPath + "\\mobydick.xml";
            var wordList = xmlReader.Read(webPath);

            //cache
            Startup._WORDCACHE = wordList;

            return View(wordList.Take(10).ToList());
        }



    }
}
