using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.Models.Domain;

namespace Website.Models.DTOs.BookDTOs
{
    public class BookFormDTO : EntityDTO
    {

        #region Constructors
        public BookFormDTO() { }
        public BookFormDTO(Book book)
        {
            this.Id = book.Id;
            this.Description = book.Description;
            this.ISBN = book.ISBN;
            this.ReleaseDate = book.ReleaseDate;
            this.Title = book.Name;
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

        #endregion

        #region Methods

        public void SetProperties(Book book) 
        {
            if (this.Id == Guid.Empty)
                book.Id = Guid.NewGuid();

            book.Description = this.Description;
            book.ISBN = this.ISBN;
            book.Name = this.Title;
            book.ReleaseDate = this.ReleaseDate.Value;        
        }

        public Book ToEntity() 
        {
            Book book = new Book();

            SetProperties(book);

            return book;
        }

        #endregion

    }
}