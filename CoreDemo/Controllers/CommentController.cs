using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
	public class CommentController : Controller
	{
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogID = 9;
            cm.CommentAdd(p);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
			var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
