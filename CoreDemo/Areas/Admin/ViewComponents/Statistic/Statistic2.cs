using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.v3 = c.Comments.Count();
            return View();
        }
    }
}
