using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookCopy
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public virtual List<Loan> Loans { get; set; }

        /// <summary>
        /// Display book name and copy id to distinguish between copies.
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0} -- {1}", this.Id, this.Book);
        }
    }
}
