using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models.Domain
{
    public class Author : Entity
    {
        #region Constructors
        #endregion

        #region Properties
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}