using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using ZMG.Blog.Mvc.ViewModels;

namespace ZMG.Blog.Mvc.Controllers
{
    public class AccountController : Controller
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
        public AccountController(ILogger<HomeController> logger, IConfiguration Config)
        {
            _logger = logger;
            _Config = Config;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    string stringData = JsonConvert.SerializeObject(model);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(URLBase + "user/login", contentData);
                    var result = response.IsSuccessStatusCode;
                    if (result)
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<System.IdentityModel.Tokens.Jwt.JwtPayload>(stringJWT);
                        var jwtString = jwt["token"].ToString();
                        HttpContext.Session.SetString("token", jwtString);
                        HttpContext.Session.SetString("email", jwt["email"].ToString());
                        ViewBag.Message = $"User logged in successfully!  {jwt["firstname"]} {jwt["lastname"]}";
                    }
                    return View(model);
                }
            }

            return View(model);
        }
        public IActionResult LogOff()
        {
            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }
        
        
    }
}
