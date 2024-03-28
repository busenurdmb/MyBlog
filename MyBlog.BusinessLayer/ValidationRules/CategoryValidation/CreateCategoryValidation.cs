using FluentValidation;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.ValidationRules.CategoryValidation
{
   public class CreateCategoryValidation:AbstractValidator<Category>
    {
        public CreateCategoryValidation()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Litfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.CategoryName).MinimumLength(30).WithMessage("Litfen en fazla 30 karakter veri girişi yapınız");
        }
    }
}
