using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Webgentle.Bookstore.Models;
using Webgentle.Bookstore.Repository;

namespace Webgentle.Bookstore.Controllers
{
    public class BookController : Controller
    {
        private BookReository _bookRepository;

        public BookController(BookReository reository)
        {
            _bookRepository = reository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel()
            {
               // Language = "1"
            };

            var group1 = new SelectListGroup() { Name = "Group 1" };
            var group2 = new SelectListGroup() { Name = "Group 2", Disabled = true };
            var group3 = new SelectListGroup() { Name = "Group 3" };

            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem(){Text="English", Value="1", Group = group1},
                new SelectListItem(){Text="French", Value="2", Group = group1},
                new SelectListItem(){Text="Dutch", Value="3", Group = group2},
                new SelectListItem(){Text="Spanish", Value="4", Group = group2},
                new SelectListItem(){Text="Greek", Value="5", Group = group3},
                new SelectListItem(){Text="Chinese", Value="6", Group = group3},
                new SelectListItem(){Text="German", Value="7", Group = group3}
            };

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");

            //ModelState.AddModelError("", "This is my custom error message");
            //ModelState.AddModelError("", "This is my second custom error message");

            return View();
        }

        private static List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>() {
                new LanguageModel(){Id = 1, Text = "English"},
                new LanguageModel(){Id = 2, Text = "French"},
                new LanguageModel(){Id = 3, Text = "Spanish"}
            };
        }
    }
}
