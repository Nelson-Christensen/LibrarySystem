using Library.Models;
using Library.Repositories;
using Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Library
{
    public partial class LibraryForm : Form
    {
        bool createNewLoan = true; // Bool that controls whether the GUI should show that user is creating a new loan or handling an already existing loan.
        private void returnCreateLoanBTN_Click(object sender, EventArgs e)
        {
            if (createNewLoan)
            {
                Member newMember = new Member()
                {
                    Name = "Nelson",
                    personalID = "12348181"
                };
                Loan newLoan = new Loan(lbCopies.SelectedItem as BookCopy, newMember, timeOfLoanDTP.Value);
                loanService.Add(newLoan);
            }
            else //Return Loan
            {

            }
        }


        private void UpdatedLoansEvent(object sender, EventArgs e)
        {

        }
    }
}
