using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookProject.Models.BookProjectRepository;

namespace BookProject.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookProjectRepository repo { get; set; }
      
        public TypesViewComponent(IBookProjectRepository)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var typers = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View();
        }
    }
}
