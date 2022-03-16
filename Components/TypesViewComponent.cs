using BookProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookProject.Models.IBookProjectRepository;

namespace BookProject.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookProjectRepository repo { get; set; }
      
        public TypesViewComponent(IBookProjectRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData.Values["category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
