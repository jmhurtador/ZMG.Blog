using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ZMG.Blog.Mvc.Models;
using ZMG.Blog.Mvc.ViewModels;

namespace ZMG.Blog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _Config;
        private string URLBase
        {
            get
            {
                return _Config.GetSection("BaseURL").GetSection("URL").Value;
            }
        }
        public HomeController(ILogger<HomeController> logger, IConfiguration Config)
        {
            _logger = logger;
            _Config = Config;
        }

        public async Task<IActionResult> Index()
        {
            var listPost = new ListPostViewModel();
            var postList = new List<Post>();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(URLBase + "post"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    postList = JsonConvert.DeserializeObject<List<Post>>(apiResponse);
                }
            }
            listPost.ListPost = postList;
            return View(listPost);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
