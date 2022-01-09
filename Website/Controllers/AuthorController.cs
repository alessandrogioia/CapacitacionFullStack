using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Website.Models;
using Website.Models.Domain;
using Website.Models.DTOs.AuthorDTOs;

namespace Website.Controllers
{
    public class AuthorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
            List<AuthorGridDTO> authors = db.Authors.ToList().Select(b => new AuthorGridDTO
            {
                Id = b.Id,
                Name = b.Name
            }).ToList();

            return View(authors);
        }

        public ActionResult Create()
        {
            AuthorFormDTO model = new AuthorFormDTO();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AuthorFormDTO model)
        {
            if (ModelState.IsValid)
            {
                Author author = model.ToEntity();

                db.Authors.Add(author);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            Author dbAuthor = db.Authors.Find(id);

            AuthorFormDTO model = new AuthorFormDTO(dbAuthor);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AuthorFormDTO model)
        {
            if (ModelState.IsValid)
            {
                Author dbAuthor = db.Authors.Find(model.Id);
                model.SetProperties(dbAuthor);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            Author dbAuthor = db.Authors.Find(id);

            db.Authors.Remove(dbAuthor);
            db.SaveChanges();
            
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}