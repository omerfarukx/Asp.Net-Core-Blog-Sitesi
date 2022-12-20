using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
		Context c = new Context();
		public IActionResult Index()
        {
			var username = User.Identity.Name;
			ViewBag.v = username;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x=>x.WriterMail == usermail).Select(y=>y.WriterID).FirstOrDefault();

            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerid).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
