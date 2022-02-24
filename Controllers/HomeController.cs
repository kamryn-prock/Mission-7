using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookProject.Models;
using static BookProject.Models.BookProjectRepository;
using BookProject.Models.ViewModels;

namespace BookProject.Controllers
{
    public class HomeController : Controller
    {

        private IBookProjectRepository repo;
        public HomeController (IBookProjectRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string projectType, int pageNum = 1) //do not use "page" as your variable name. = 1 is default
        {
            int pageSize = 5;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == Category)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
  
        //public IActionResult Index() => View();
    }
}
