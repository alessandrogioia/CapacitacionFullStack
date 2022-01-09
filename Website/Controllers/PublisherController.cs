using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.Models.Domain;
using Website.Models.DTOs.PublisherDTOs;

namespace Website.Controllers
{
    public class PublisherController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
            List<PublisherGridDTO> publishers = db.Publishers.ToList().Select(b => new PublisherGridDTO
            {
                Id = b.Id,
                Name = b.Name
            }).ToList();

            return View(publishers);
        }

        public ActionResult Create()
        {
            PublisherFormDTO model = new PublisherFormDTO();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PublisherFormDTO model)
        {
            if (ModelState.IsValid)
            {
                Publisher publisher = model.ToEntity();

                db.Publishers.Add(publisher);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            Publisher dbPublisher = db.Publishers.Find(id);

            PublisherFormDTO model = new PublisherFormDTO(dbPublisher);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PublisherFormDTO model)
        {
            if (ModelState.IsValid)
            {
                Publisher dbPublisher = db.Publishers.Find(model.Id);
                model.SetProperties(dbPublisher);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}