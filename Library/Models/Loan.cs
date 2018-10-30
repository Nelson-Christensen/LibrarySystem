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
        public DateTime? ReturnDate { get; set; } //Allow null as a returnDate if it hasnt been returned yet.
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

        /// <summary>
        /// Must include parameterless constructor for Entity Framework to function. It cannot be initialized from outside though.
        /// </summary>
        private Loan()
        {

        }

        /// <summary>
        /// Creates a new Loan where DueDate is 15days after startDate.
        /// </summary>
        /// <param name="copy">BookCopy that the loan is based on</param>
        /// <param name="member">The member that takes the loan</param>
        /// <param name="start">The DateTime when the loan started</param>
        public Loan (BookCopy copy, Member member, DateTime start) : this(copy, member, start, start.AddDays(15))
        {

        }

        /// <summary>
        /// Creates a new Loan
        /// </summary>
        /// <param name="copy">BookCopy that the loan is based on</param>
        /// <param name="member">The member that takes the loan</param>
        /// <param name="start">The DateTime when the loan started</param>
        /// <param name="due">The DateTime when the loan is due, if parameter is skipped it defaults to 15days after start</param>
        public Loan(BookCopy copy, Member member, DateTime start, DateTime due)
        {
            this.BookCopy = copy;
            this.Member = member;
            this.StartDate = start;
            this.DueDate = due;
        }

        /// <summary>
        /// Useful for adding the book objects directly to a ListBox.
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0} -- {1}", this.BookCopy.ToString(), this.Member.ToString());
        }
    }
}