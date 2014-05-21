using System.Web.Mvc;
using JobTrack.Api.Data.Context;

namespace JobTrack.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var sqlInitial = new SqlTablesInitializer();
            //sqlInitial.InitializeDatabase(new JobTrackDbContext("JobTrackDbContext"));
            return View();
        }
    }
}
