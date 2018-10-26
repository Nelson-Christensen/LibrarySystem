using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    /// <summary>
    /// Class to represent book loans made by members
    /// </summary>
    public class Loan
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public BookCopy BookCopy { get; set; }
        public Member Member { get; set; }

        /// <summary>
        /// Checks to see if loan has been returned
        /// </summary>
        /// <returns>Returns true if ReturnDate has been registered, else false.</returns>
        public bool IsReturned()
        {
            return ReturnDate != null;
        }
    }
}