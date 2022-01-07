using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models.Domain
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}