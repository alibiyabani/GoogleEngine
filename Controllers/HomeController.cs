using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoogleEngine.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using GoogleEngine.Data;


namespace GoogleEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly GoogleEngineContext _context;

        public HomeController(GoogleEngineContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string terms)
        {
            string apiKey = "AIzaSyArtzl7iFwKpdmFcZ6C452XJ3ozrJxMP68";
            //This cx Code searching Google And Yahoo.(we can add more source from google Search API control Panel)
            string cx = "d2a8a6359d5de0864";
            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + terms);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);

            var resultList = new List<Search>();

            if (jsonData.items != null)
            {
                foreach (var item in jsonData.items)
                {
                    resultList.Add(new Search
                    {
                        Title = item.title,
                        Link = item.link,
                        Snippet = item.snippet,
                        Term = terms,
                        SearchDate = DateTime.Now
                    });
                }

                Result obj = new Result();
                //keep top 10 Result to search Modal(one by one)
                obj.SearchResult = resultList;


                //keep Search Result and terms to Result Model as (json ROW)// string format 
                obj.ObjectResult = responseString.ToString();
                obj.SearchDate = DateTime.Now;
                obj.Terms = terms;

                //Save Objects to Db
                _context.Result.Add(obj);
                _context.SaveChanges();

                return View(resultList.ToList());
            }
            else
            {
                return View();
            }
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
