using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models.Domain;

namespace Website.Models.DTOs.BookDTOs
{
    public class BookDetailsDTO : EntityDTO
    {

        #region Constructors
        public BookDetailsDTO()
        {
            Authors = new List<string>();
        }
        public BookDetailsDTO(Book book)
        {
            this.Id = book.Id;
            this.Description = book.Description;
            this.ISBN = book.ISBN;
            this.ReleaseDate = book.ReleaseDate.ToString("yyyy-MM-dd");
            this.Title = book.Name;
            this.Authors = book.Authors != null ? book.Authors.OrderBy(a => a.Name).Select(a => a.Name).ToList() : new List<string>();
            this.PhotoUrl = "/File/DownloadImage?filename=" + book.Photo;
            this.Publisher = book.Publisher.Name;
        }
        #endregion

        #region Properties

        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public List<string> Authors { get; set; }
        public string PhotoUrl { get; set; }

        #endregion

        #region Methods


      
        #endregion

    }
}