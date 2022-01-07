using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models.Domain
{
    public class Book : Entity
    {
        #region Constructors
        #endregion

        #region Properties
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        
        [StringLength(13)]
        public string ISBN { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}