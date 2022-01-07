using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Website.Models;
using Website.Models.Domain;
using Website.Models.DTOs.BookDTOs;

namespace Website.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
            List<BookGridDTO> books = db.Books.ToList().Select(b => new BookGridDTO
            {
                Id = b.Id,
                ISBN = b.ISBN,
                ReleaseDate = b.ReleaseDate.ToString("dd-MM-yyyy"),
                Title = b.Name
            }).ToList();

            return View(books);
        }

        public ActionResult Create() 
        {
            BookFormDTO model = new BookFormDTO();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookFormDTO model) 
        {
            if (ModelState.IsValid) 
            {
                Book book = model.ToEntity();

                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            Book dbBook = db.Books.Find(id);

            BookFormDTO model = new BookFormDTO(dbBook);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookFormDTO model)
        {
            if (ModelState.IsValid)
            {
                Book dbBook = db.Books.Find(model.Id);
                model.SetProperties(dbBook);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }


    }
}