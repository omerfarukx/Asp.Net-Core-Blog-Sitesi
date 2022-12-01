using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
	public class CommentList: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment
				{
					id =1,
					Username="Ömer"
				},
				new UserComment
				{
					id=2,
					Username="Mesut",
				},
				new UserComment
				{
					id=3,
					Username="Merve",
				}
			};
			return View(commentvalues);
		}
	}
}
