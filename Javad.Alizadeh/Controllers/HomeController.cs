using AspNetCoreHero.ToastNotification.Abstractions;
using Javad.Alizadeh.Models;
using Javad.Alizadeh.Models.Entities;
using Javad.Alizadeh.Models.Repositories;
using Javad.Alizadeh.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Javad.Alizadeh.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IActivityRepostory _activityRepostory;
        private readonly IActivityService _activityService;
        private readonly INotyfService _notyf;


        public HomeController(IActivityRepostory activityRepostory, IActivityService activityService, INotyfService notyfService)
        {
            _activityRepostory = activityRepostory;
            _activityService = activityService;
            _notyf = notyfService;
        }

        protected IActionResult MyResult(int statusCode, OutPutResualt result)
        {
            var jsonResult = Json(result);
            jsonResult.StatusCode = statusCode;

            return jsonResult;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AppActivity()
        {
            var activities = _activityRepostory.GetAll();
            return View(activities);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ActivityType type)
        {
            if (!ModelState.IsValid)
            {
                return View(type);
            }

            var createResualt = _activityService.Create(type);

            MyResult(200, new OutPutResualt
            {
                Status = createResualt.Status,
                Messages = createResualt.Messages,
                Output = type,
            });

            string message = string.Join(" ", createResualt.Messages);

            if (createResualt.Status == 1)
            {
                _notyf.Error("Wrong input!", 5);
                _notyf.Error(message, 5);
                _notyf.Error("Your name and code most be unique", 8);
                _notyf.Error("Code most be between 100 and 10 million!", 8);
                return RedirectToAction("Create", createResualt.Messages);
            }
            else
            {
                _notyf.Success("Create was succsessful", 3);
                return RedirectToAction("AppActivity");
            }
        }
        public IActionResult ProceedCreate()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var activity = _activityRepostory.Get(id);
            return View(activity);
        }
        [HttpPost]
        public IActionResult Update(ActivityType type)
        {
            if (!ModelState.IsValid)
            {
                return View(type);
            }
            _activityRepostory.Update(type);
            return RedirectToAction("AppActivity");           
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _activityRepostory.Delete(id);
            return RedirectToAction("AppActivity");
        }
        public IActionResult Copy(int id)
        {
            var activity = _activityRepostory.Get(id);
            return View(activity);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}