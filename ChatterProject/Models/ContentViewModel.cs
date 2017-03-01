using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatterProject.Models
{
    public class ContentViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }

        public Content Content { get; set; }
    }
}