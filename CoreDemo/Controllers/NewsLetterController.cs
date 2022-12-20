using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter p)
        {
            p.MailStatus = true;
            nm.AddNewsLetter(p);
            return PartialView();
        }
    }
}
