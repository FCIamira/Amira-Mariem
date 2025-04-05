using FreelanceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreelanceManager.Controllers
{
    public class TimeTrackingController : Controller
    {
        private readonly ITimeTrackingRepo _timer;
        public TimeTrackingController(ITimeTrackingRepo timer) {
        _timer =timer;
        }
        public IActionResult Index()
        {
            var tracking = _timer.GetAll().FirstOrDefault(t => !t.IsDeleted);

            if (tracking == null)
            {
                tracking = new TimeTracking
                {
                    Date = DateTime.Now,
                    Duration = TimeSpan.Zero,
                    EstimateTime = TimeSpan.Zero,
                    StartTime = DateTime.MinValue, 
                    EndTime = DateTime.MinValue
                };
                _timer.Add(tracking);
                //_timer.Save();
            }
                return View(tracking);
        }

        [HttpPost]
        public IActionResult Start(int id)
        {
            var tracking = _timer.GetById(id);
           
                tracking.StartTime = DateTime.Now;
                tracking.EndTime = null;
                tracking.Duration = TimeSpan.Zero;
                _timer.Save();
         
            return RedirectToAction("Index", new {Id=id});
        }

    }
}


