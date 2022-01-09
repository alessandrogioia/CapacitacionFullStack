using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.Models.Domain;

namespace Website.Models.DTOs.PublisherDTOs
{
    public class PublisherFormDTO : EntityDTO
    {

        #region Constructors
        public PublisherFormDTO() { }
        public PublisherFormDTO(Publisher publisher)
        {
            this.Id = publisher.Id;
            this.Name = publisher.Name;
        }
        #endregion

        #region Properties

        [Required(ErrorMessage = "Please provide a Name")]
        public string Name { get; set; }

        #endregion

        #region Methods

        public void SetProperties(Publisher publisher) 
        {
            if (this.Id == Guid.Empty)
                publisher.Id = Guid.NewGuid();

            publisher.Name = this.Name;        
        }

        public Publisher ToEntity() 
        {
            Publisher publisher = new Publisher();

            SetProperties(publisher);

            return publisher;
        }

        #endregion

    }
}