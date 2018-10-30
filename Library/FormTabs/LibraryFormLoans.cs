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
        TextBox loanFilterByField;
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

        private void findTitleLoanTB_TextChanged(object sender, EventArgs e)
        {
            loanFilterByField = findTitleLoanTB;
            UpdateLoansList(LoanSearchResult().ToList());
        }

        private void findMemberLoanTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void activeLoansCHK_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void overdueLoansCHK_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoansLV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private IEnumerable<Loan> LoanSearchResult()
        {
            IEnumerable<Loan> activeLoanFilter;
            switch (loanFilterByField.Name)
            {
                case "findTitleLoanTB":
                    activeLoanFilter = loanService.GetAllThatContainsTitle(findTitleLoanTB.Text);
                    break;

                case "findMemberLoanTB":
                    activeLoanFilter = loanService.GetAllThatContainsMember(findMemberLoanTB.Text);
                    break;

                default:
                    activeLoanFilter = loanService.All();
                    break;
            }
            if (activeLoansCHK.Checked)
            {
                IEnumerable<Loan> activeLoansOnlyFilter = loanService.GetAllActiveLoans().ToList();
                activeLoanFilter = loanService.CombineFilteredLists(activeLoanFilter, activeLoansOnlyFilter);
            }
            if (overdueLoansCHK.Checked)
            {
                IEnumerable<Loan> overDueLoansFilter = loanService.GetAllOverdueLoans().ToList();
                activeLoanFilter = loanService.CombineFilteredLists(activeLoanFilter, overDueLoansFilter);
            }
            return activeLoanFilter;
        }


        private void UpdatedLoansEvent(object sender, EventArgs e)
        {
            UpdateLoansList(loanService.All().ToList());
        }

        private void UpdateLoansList(List<Loan> loanList)
        {
            currentLoanDisplay = loanList;
            LoansLV.Items.Clear();
            foreach (Loan loan in loanList)
            {
                ListViewItem lvi = new ListViewItem(loan.Id.ToString());
                lvi.SubItems.Add(loan.BookCopy.Id.ToString());
                lvi.SubItems.Add(loan.BookCopy.Book.Title);
                lvi.SubItems.Add(loan.Member.ToString());
                lvi.SubItems.Add(loan.StartDate.ToString());
                LoansLV.Items.Add(lvi);
            }
        }
    }
}
