using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Data;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
    public class BookReository
    {
        private readonly BookStoreContext _context = null;

        public BookReository(BookStoreContext context)
        {
            _context = context;
        }
        
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Category = model.Category,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdaedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach(var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }

            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title ="MVC", Author="Nitish", Description="This is description for MVC book", Category="Programming", Language="English", TotalPages=134},
                new BookModel(){Id = 2, Title ="Dot Net Core", Author="Nitish", Description="This is description for Dot Net Core book", Category="Framwork", Language="French", TotalPages=180},
                new BookModel(){Id = 3, Title ="C#", Author="Monica", Description="This is description for C# book", Category="Development", Language="Greek", TotalPages=155},
                new BookModel(){Id = 4, Title ="Java", Author="Webgentle", Description="This is description for Java book", Category="Programming", Language="English", TotalPages=300},
                new BookModel(){Id = 5, Title ="Php", Author="Webgentle", Description="This is description for Php book", Category="Programming", Language="English", TotalPages=234},
                new BookModel(){Id = 6, Title ="Asure DevOps", Author="Webgentle", Description="This is description for Asure DevOps book", Category="Programming", Language="English", TotalPages=90}
            };
        }
    }
}
