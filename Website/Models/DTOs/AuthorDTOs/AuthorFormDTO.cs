using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.Models.Domain;

namespace Website.Models.DTOs.AuthorDTOs
{
    public class AuthorFormDTO : EntityDTO
    {

        #region Constructors
        public AuthorFormDTO() { }
        public AuthorFormDTO(Author author)
        {
            this.Id = author.Id;
            this.Name = author.Name;
        }
        #endregion

        #region Properties

        [Required(ErrorMessage = "Please provide a Name")]
        public string Name { get; set; }

        #endregion

        #region Methods

        public void SetProperties(Author author) 
        {
            if (this.Id == Guid.Empty)
                author.Id = Guid.NewGuid();

            author.Name = this.Name;        
        }

        public Author ToEntity() 
        {
            Author author = new Author();

            SetProperties(author);

            return author;
        }

        #endregion

    }
}