using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        AdminManager am = new AdminManager(new EfAdminRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Admins.Where(x => x.AdminID == 2).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x => x.AdminID == 2).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x => x.AdminID == 2).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
