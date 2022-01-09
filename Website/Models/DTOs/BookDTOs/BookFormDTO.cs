using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.Helpers;
using Website.Models.Domain;

namespace Website.Models.DTOs.BookDTOs
{
    public class BookFormDTO : EntityDTO
    {

        #region Constructors
        public BookFormDTO() 
        {
            SelectedAuthorIds = new List<Guid>();
        }
        public BookFormDTO(Book book)
        {
            this.Id = book.Id;
            this.Description = book.Description;
            this.ISBN = book.ISBN;
            this.ReleaseDate = book.ReleaseDate;
            this.Title = book.Name;
            this.SelectedPublisherId = book.PublisherId;
            this.PhotoUrl = "/File/DownloadImage?filename=" + book.Photo;

            SelectedAuthorIds = new List<Guid>();
            if (book.Authors != null)
            {
                foreach (var author in book.Authors)
                    SelectedAuthorIds.Add(author.Id);
            }

        }
        #endregion

        #region Properties

        [Required(ErrorMessage = "Please provide a Title")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Please provide a Release Date")]
        public DateTime? ReleaseDate { get; set; }


        public string Description { get; set; }


        [StringLength(13)]
        [Required(ErrorMessage = "Please provide a ISBN number")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please select a publisher")]
        public Guid? SelectedPublisherId { get; set; }
        public List<Guid> SelectedAuthorIds { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public string PhotoUrl { get; set; }

        #endregion

        #region Methods

        public void SetProperties(Book book, ApplicationDbContext db) 
        {
            if (this.Id == Guid.Empty)
                book.Id = Guid.NewGuid();

            book.Description = this.Description;
            book.ISBN = this.ISBN;
            book.Name = this.Title;
            book.ReleaseDate = this.ReleaseDate.Value;
            book.PublisherId = this.SelectedPublisherId.Value;

            book.Authors.Clear();
            foreach (Guid authorid in this.SelectedAuthorIds)
                book.Authors.Add(db.Authors.FirstOrDefault(a => a.Id == authorid));

            if (Photo != null)
                book.Photo = FileHelper.SubirArchivo(Photo);
        }

        public Book ToEntity(ApplicationDbContext db) 
        {
            Book book = new Book();

            SetProperties(book, db);

            return book;
        }

        #endregion

    }
}