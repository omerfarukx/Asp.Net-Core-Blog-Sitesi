using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori içeriğini boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
        }
    }
}
