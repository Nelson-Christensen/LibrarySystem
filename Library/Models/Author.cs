using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Author
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }

        /// <summary>
        /// Returns the name of the author.
        /// </summary>
        /// <returns>Name of Author</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}