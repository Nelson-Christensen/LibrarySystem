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
        /// Retrieves the names of all of the books authors in a string and seperates them by a comma.
        /// </summary>
        /// <returns>Returns a string of all author names. If no author has been set, returns empty string.</returns>
        public string AllAuthorsToString()
        {
            string authors = "";

            foreach (Author a in Authors)
            {
                authors += a.Name;
                authors += ",";
            }
            authors = authors.TrimEnd(','); // Removes the last comma after all authors has been added to the string
            return authors;
        }

        /// <summary>
        /// Useful for adding the book objects directly to a ListBox.
        /// </summary>
        public override string ToString() {
            return String.Format("{0}", this.Title);
        }
    }
}