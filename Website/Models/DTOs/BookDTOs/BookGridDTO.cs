using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models.DTOs.BookDTOs
{
    public class BookGridDTO : EntityDTO
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public List<string> Authors { get; set; }

    }
}