﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Website.Models;
using Website.Models.Domain;
using Website.Models.DTOs.BookDTOs;
using Website.Models.DTOs.GenericDTOs;

namespace Website.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
            List<BookGridDTO> books = db.Books
                            .Include("Publisher")
                            .Include("Authors")
                            .ToList().Select(b => new BookGridDTO
            {
                Id = b.Id,
                ISBN = b.ISBN,
                ReleaseDate = b.ReleaseDate.ToString("dd-MM-yyyy"),
                Title = b.Name,
                Publisher = b.Publisher != null ? b.Publisher.Name : "-",
                Authors = b.Authors != null ? b.Authors.Select(a => a.Name).ToList() : new List<string>()
            }).ToList();

            return View(books);
        }

        public ActionResult Create() 
        {
            BookFormDTO model = new BookFormDTO();
            AddViewDataForForms();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookFormDTO model)
        {
            BookCustomValidations(model);

            if (ModelState.IsValid) 
            {
                Book book = model.ToEntity(db);

                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            AddViewDataForForms();
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            Book dbBook = db.Books.Include("Authors").FirstOrDefault(b => b.Id == id);

            BookFormDTO model = new BookFormDTO(dbBook);

            AddViewDataForForms();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookFormDTO model)
        {
            BookCustomValidations(model);

            if (ModelState.IsValid)
            {
                Book dbBook = db.Books.Include("Authors").FirstOrDefault(b => b.Id == model.Id);
                model.SetProperties(dbBook, db);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            AddViewDataForForms();
            return View(model);
        }

        private void BookCustomValidations(BookFormDTO model)
        {
            if (db.Books.Any(b => b.ISBN == model.ISBN && b.Id != model.Id))
                ModelState.AddModelError("ISBN", "There is already a book with this ISBN in the database");
        }
        private void AddViewDataForForms() 
        {
            ViewData["PublishersList"] = db.Publishers.Select(p => new ComboListItem { Text = p.Name, Value = p.Id }).ToList();
            ViewData["AuthorList"] = db.Authors.Select(p => new ComboListItem { Text = p.Name, Value = p.Id }).ToList();
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            Book dbBook = db.Books.Find(id);

            db.Books.Remove(dbBook);
            db.SaveChanges();

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

    }
}