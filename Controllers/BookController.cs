using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            var books = new List<String>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS Responsive web Design cookbook- Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }

        public string HelloTeacher(string university)
        {
            return "Hello Lại Huy Hà - University: "+university;
        }

        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/OIP.jpg"));
            books.Add(new Book(2,"HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/OIP (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/images/OIP (2).jpg"));
            books.Add(new Book(4, "Professional ASP.NET MVC5 2", "Author Name Book 3", "/Content/images/OIP(3).jpg"));
            return View(books);
        }

        public ActionResult EditBookModel(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/OIP.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/OIP (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/images/OIP (2).jpg"));
            Book book = new Book();
            foreach (Book b in books )
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("EditBookModel")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBookModel(int id, string Title, string author, string Images_Cover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/OIP.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/OIP (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/images/OIP (2).jpg"));
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = author;
                    b.Images_Cover = Images_Cover;
                    break;
                }
            }

            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id, Title, Author, Images_Cover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/OIP.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/OIP (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/images/OIP (2).jpg"));

            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return View("ListBookModel", books);
        }

        public ActionResult DeleteBookModel(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/OIP.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/OIP (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/images/OIP (2).jpg"));
            books.Add(new Book(4, "Professional ASP.NET MVC5 2", "Author Name Book 3", "/Content/images/OIP(3).jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("DeleteBookModel")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBookModel(int id, string Title, string author, string Images_Cover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/OIP.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/OIP (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/images/OIP (2).jpg"));
            books.Add(new Book(4, "Professional ASP.NET MVC5 2", "Author Name Book 3", "/Content/images/OIP(3).jpg"));
            Book b = books.Find(d => d.Id == id);
            books.Remove(b);
            return View("ListBookModel", books);
        }
    }
}