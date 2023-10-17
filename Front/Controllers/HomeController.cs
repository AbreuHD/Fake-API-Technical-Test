using Core.Application.DTOs;
using Core.Application.Services.API;
using Front.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly APICallService _apiCallService;
        
        public HomeController(APICallService apiCallService)
        {
            _apiCallService = apiCallService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiCallService.GetBooks();
            ViewBag.status = TempData["status"];
            ViewBag.errors = TempData["errors"];
            return View(response.Data);
        }

        public async Task<IActionResult> Info(int Id)
        {
            var response = await _apiCallService.GetBookById(Id);
            return View(response.Data);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _apiCallService.DeleteBook(Id);
            if (((int)response.StatusCode) == 200)
            {
                TempData["status"] = 3;
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookDTO request, int Id)
        {
            if (!ModelState.IsValid)
            {
                List<string> errores = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errores.Add(error.ErrorMessage);
                    }
                }
                TempData["errors"] = errores;
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var response = await _apiCallService.UpdateBook(Id, request);
            return View(response.Data);
        }

        public async Task<IActionResult> Add(BookDTO request, int Id)
        {
            if (!ModelState.IsValid)
            {
                List<string> errores = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errores.Add(error.ErrorMessage);
                    }
                }
                TempData["errors"] = errores;
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var response = await _apiCallService.AddBook(request);
            return View(response.Data);
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