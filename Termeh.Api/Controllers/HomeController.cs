using System.Data.Entity;
using System.Web.Mvc;
using JobTrack.Api.Data.Commands;
using JobTrack.Api.Data.Context;

namespace JobTrack.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDB()
        {
            var context = (JobTrackDbContext)StructureMap.ObjectFactory.GetInstance<DbContext>();
            context.CreateDataBase();
            return View("Index");
        }
    }
}
