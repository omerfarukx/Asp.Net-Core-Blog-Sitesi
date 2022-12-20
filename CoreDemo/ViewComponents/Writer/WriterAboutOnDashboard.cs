using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writermanager = new WriterManager(new EfWriterRepository());

		Context c = new Context();

		public IViewComponentResult Invoke()
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var username = User.Identity.Name;
            ViewBag.v = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = writermanager.GetWriterById(writerID);
            return View(values);
        }
    }
}
