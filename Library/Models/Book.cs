using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models {
    public class Book {

        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<Author> Authors { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public virtual List<BookCopy> BookCopies { get; set; }

        /// <summary>
        /// Useful for adding the book objects directly to a ListBox.
        /// </summary>
        public override string ToString() {
            return String.Format("{0}", this.Title);
        }
    }
}