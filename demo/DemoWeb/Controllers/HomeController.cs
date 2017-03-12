using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private List<data> Data;
        public HomeController()
        {
            this.Data = new List<data>();
            for(var i = 1; i < 100; i++)
            {
                Data.Add(new data()
                {
                    Title = $"Title--{i}",
                    Type = (i % 20).ToString()
                });
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RawTypeSelector(string t)
        {
            if (!string.IsNullOrEmpty(t))
            {
                Data = Data.Where(c => c.Type == t).ToList();
            }
            return View(Data);
        }

        public IActionResult TagHelperTypeSelector(string t)
        {
            if (!string.IsNullOrEmpty(t))
            {
                Data = Data.Where(c => c.Type == t).ToList();
            }
            return View(Data);
        }

        

        public IActionResult Error()
        {
            return View();
        }
    }

    public class data
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; } = DateTime.Now; 
    }
}
