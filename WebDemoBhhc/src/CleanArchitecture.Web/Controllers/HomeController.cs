using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.Interfaces;
//using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeViewModelService _homeViewModelService;

        [BindProperty]
        public int LanguageOption { get; set; }

        public HomeController(IHomeViewModelService reasonViewModelService)
        {
            _homeViewModelService = reasonViewModelService;
        }

        public IActionResult Index()
        {
            var items = _homeViewModelService.GetReasons(LanguageOption);
            
            return View(items);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
