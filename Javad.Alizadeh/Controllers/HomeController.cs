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

        public HomeController(IActivityRepostory activityRepostory, IActivityService activityService)
        {
            _activityRepostory = activityRepostory;
            _activityService = activityService;
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
            //   _activityRepostory.Create(type);

           var createResualt = _activityService.Create(type);

            //return RedirectToAction("AppActivity");
            try
            {
                return MyResult(200, new OutPutResualt
                {
                    Status = createResualt.Status,
                    Messages = createResualt.Messages,
                    Output = type
                });
            }
            catch (Exception ex)
            {

                return MyResult(400, new OutPutResualt
                {
                    Status = createResualt.Status,
                    Messages =new List<string>() { ex.Message },
                    Output = type
                });
            }
         

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