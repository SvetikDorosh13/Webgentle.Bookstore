using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
    public class BookReository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
