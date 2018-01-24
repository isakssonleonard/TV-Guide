using System.Web.Mvc;
using TV_Guide.Data;

namespace TV_Guide.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            XmlHandler xmlHandler = new XmlHandler();
            xmlHandler.FindFile();
            return View(xmlHandler.GetPrograms());         
        }
    }
}