using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatterProject.Models
{
    public class Content
    {
        internal ICollection<object> Followers;

        [Key]
        public int ContentID { get; set; }
        [MaxLength(150)]
        public string Message { get; set; }
        public string Photo { get; set; }
        public DateTime DateTime { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public class User
        {
            public int ID { get; set; }
            public ICollection<User> Followers { get; set; }
            public ICollection<User> Following { get; set; }
        }
    }
}