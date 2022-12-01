using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryList:ViewComponent
	{
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());
		public IViewComponentResult Invoke()
		{
			var values = cm.GetList();
			return View(values);
		}
	}
}
