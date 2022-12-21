using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{

	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;
        Context c = new Context();
        public WriterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Authorize]
		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;
			var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
			ViewBag.v2 = writerName;
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult WriterMail()
		{
			return View();
		}
		public IActionResult Test()
		{
            return View();
		}
		public PartialViewResult WriterNavbarPartial()
		{
            return PartialView();
		}
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}
		[HttpGet]
		public async Task<IActionResult> WriterEditProfile()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserUpdateViewModel model = new UserUpdateViewModel();
			model.mail = values.Email;
			model.namesurname = values.NameSurname;
			model.imageurl = values.ImageUrl;
			model.username = values.UserName;
            return View(model);
		}
		[HttpPost]
		public async Task <IActionResult> WriterEditProfile(UserUpdateViewModel model)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			values.NameSurname = model.namesurname;
			values.ImageUrl = model.imageurl;
			values.Email = model.mail;
            var PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
			return RedirectToAction("Index","Dashboard");
		}
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult WriterAdd(AddProfileImage p)
		{
			Writer w = new Writer();
			if (p.WriterImage != null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName);
				var newimagename = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
				var stream = new FileStream(location, FileMode.Create);
				p.WriterImage.CopyTo(stream);
				w.WriterImage = newimagename;
			}
			w.WriterMail = p.WriterMail;
			w.WriterName = p.WriterName;
			w.WriterPassword = p.WriterPassword;
			w.WriterStatus = true;
			w.WriterAbout = p.WriterAbout;
			wm.TUpdate(w);
			return RedirectToAction("Index", "Dashboard");
		}

	}
}
