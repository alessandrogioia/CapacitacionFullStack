using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models.Domain
{
    public class Book : Entity
    {
        #region Constructors
        public Book() 
        {
            Authors = new List<Author>();
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        
        [StringLength(13)]
        public string ISBN { get; set; }

        public Guid PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        public List<Author> Authors { get; set; }
        public string Photo { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}