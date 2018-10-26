using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Member
    {

        public int Id { get; set; }
        public string personalID { get; set; }
        public string Name { get; set; }
        public virtual List<Loan> Loans { get; set; }

        /// <summary>
        /// Returns Name of Member
        /// </summary>
        /// <returns>Returns members full name in a string</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}