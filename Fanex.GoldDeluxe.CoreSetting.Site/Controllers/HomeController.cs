namespace Fanex.GoldDeluxe.CoreSetting.Site.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FormsAuthentication.SetAuthCookie("demo username", true);
            return View();
        }
    }
}
