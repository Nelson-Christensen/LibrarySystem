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
        BookCopy loanInputBookCopy;
        Member loanInputMember;

        private void loansTab_Enter(object sender, EventArgs e)
        {
            bookCopyLoanTB.AutoCompleteCustomSource.AddRange(bookCopyService.GetAllAvailableBookCopyNames().ToArray()); //Adds all the current bookCopies to autocomplete list.
            memberLoanTB.AutoCompleteCustomSource.AddRange(memberService.GetAllMemberNames().ToArray()); //Adds all the current Members to autocomplete list.
            UpdateLoansList(LoanSearchResult().ToList());

            if (createNewLoan == false)
            {
                ClearLoanInfoPanel();
            }
        }
        private void returnCreateLoanBTN_Click(object sender, EventArgs e)
        {
            if (createNewLoan)
            {
                if (ValidLoanInput())
                {
                    if (loanInputBookCopy.OnActiveLoan())
                    {
                        string confirmBoxText = "The Bookcopy you selected is already on loan";
                        string confirmBoxTitle = "Bookcopy already on loan";
                        InfoPopup(confirmBoxText, confirmBoxTitle);
                    }
                    else // Allowed to create a new loan
                    {
                        Loan newLoan = new Loan(loanInputBookCopy, loanInputMember, timeOfLoanDTP.Value, dueDateDTP.Value);
                        loanService.Add(newLoan);
                    }
                }
                else
                {
                    string confirmBoxText = "All fields did not contain valid data. Make sure your BookCopy and Member fields contain existing data.";
                    string confirmBoxTitle = "Invalid Loan Data.";
                    InfoPopup(confirmBoxText, confirmBoxTitle);
                }
            }
            else //Return Loan
            {
                ListViewItem item = LoansLV.SelectedItems[0];
                int loanID = Int32.Parse(item.SubItems[0].Text);
                Loan loan = loanService.Find(loanID);
                loanService.ReturnLoan(loan);
                DateTime returnDate = (DateTime)loan.ReturnDate; // Has to cast it to DateTime to allow operations and comparisons
                if (returnDate.Date > loan.DueDate.Date)
                {
                    int daysLate = (returnDate - loan.DueDate).Days;
                    string confirmBoxText = string.Format("The Book was returned {0} days late. Fine for a {0} day late return is {1}.", daysLate, daysLate*15);
                    string confirmBoxTitle = "Fine for late return";
                    InfoPopup(confirmBoxText, confirmBoxTitle);
                }
                else
                {
                    string confirmBoxText = "Loan return has successfully been registered.";
                    string confirmBoxTitle = "Loan has been returned";
                    InfoPopup(confirmBoxText, confirmBoxTitle);
                }

                UpdateLoanInfoPanel(loan); // Update info panel to reflect the loan return.
            }
        }

        /// <summary>
        /// Checks the database to make sure that the bookCopy and member exist there and returns true if they are found.
        /// </summary>
        /// <returns>Returns true if both of the parameter values are found in the database. Otherwise returns false.</returns>
        private bool ValidLoanInput()
        {
            string selectedBookCopyName = bookCopyLoanTB.Text;
            string[] selectedBookSplit = selectedBookCopyName.Split('-');
            int selectedBookID;
            if (!int.TryParse(selectedBookSplit[selectedBookSplit.Count() - 1].Trim(), out selectedBookID)) //If the string doesnt end with a number
                return false;
            loanInputBookCopy = bookCopyService.Find(selectedBookID);
            string selectedMemberName = memberLoanTB.Text;
            loanInputMember = memberService.GetMemberByName(selectedMemberName);
            if (!bookCopyService.All().Contains(loanInputBookCopy))
                return false;
            if (!memberService.All().Contains(loanInputMember))
                return false;

            //Date Validation
            //if (timeOfLoan.Value.Date <= DateTime.Now.Date) //Need to be able to set a passed date to create late loans for Demo.
            //    return false;
            if (dueDateDTP.Value.Date <= timeOfLoanDTP.Value.Date)
                return false;

            return true;
        }

            private void removeLoanBTN_Click(object sender, EventArgs e)
        {
            // Checks to make sure a loan is selected.
            if (LoansLV.SelectedItems.Count != 0)
            {
                ListViewItem item = LoansLV.SelectedItems[0];
                int loanID = Int32.Parse(item.SubItems[0].Text);
                Loan loan = loanService.Find(loanID);
                loanService.Remove(loan);
                UpdateLoansList(LoanSearchResult().ToList());
            }
        }

        private void newLoanBTN_Click(object sender, EventArgs e)
        {
            ClearLoanInfoPanel();
            bookCopyLoanTB.Focus();
        }

        private void findTitleLoanTB_TextChanged(object sender, EventArgs e)
        {
            loanFilterByField = findTitleLoanTB;
            UpdateLoansList(LoanSearchResult().ToList());
        }

        private void findMemberLoanTB_TextChanged(object sender, EventArgs e)
        {
            loanFilterByField = findMemberLoanTB;
            UpdateLoansList(LoanSearchResult().ToList());
        }

        private void activeLoansCHK_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLoansList(LoanSearchResult().ToList());
        }

        private void overdueLoansCHK_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLoansList(LoanSearchResult().ToList());
        }

        private void LoansLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cleared selection
            if (LoansLV.SelectedItems.Count == 0)
            {
                if (createNewLoan == false)
                {
                    ClearLoanInfoPanel();
                }
            }
            else // New Book Selected
            {
                ListViewItem item = LoansLV.SelectedItems[0];
                int loanID = Int32.Parse(item.SubItems[0].Text);
                Loan loan = loanService.Find(loanID);

                UpdateLoanInfoPanel(loan);
            }
        }

        private void UpdateLoanInfoPanel(Loan loan)
        {
            createNewLoan = false;

            bookCopyLoanTB.Text = loan.BookCopy.ToString();
            memberLoanTB.Text = loan.Member.ToString();
            timeOfLoanDTP.Value = loan.StartDate;
            dueDateDTP.Value = loan.DueDate;
            if (loan.IsReturned) //If Loan has been returned it will fill out returnDate and make it readOnly
            {
                timeOfReturnDTP.Value = (DateTime)loan.ReturnDate;
                timeOfReturnDTP.Enabled = false;
            }
            else //Otherwise returnDate will be defaulted to now, but the date will be modifiable.
            {
                timeOfReturnDTP.Value = DateTime.Now;
                timeOfReturnDTP.Enabled = true;
            }
            bookCopyLoanTB.Enabled = false;
            memberLoanTB.Enabled = false;
            timeOfLoanDTP.Enabled = false;
            dueDateDTP.Enabled = false;
            returnCreateLoanBTN.Text = "Return loan";
        }

        private void ClearLoanInfoPanel()
        {
            createNewLoan = true;

            bookCopyLoanTB.ResetText();
            memberLoanTB.ResetText();
            timeOfLoanDTP.Value = DateTime.Now;
            dueDateDTP.Value = DateTime.Now;
            timeOfReturnDTP.Value = DateTime.Now;
            bookCopyLoanTB.Enabled = true;
            memberLoanTB.Enabled = true;
            timeOfLoanDTP.Enabled = true;
            dueDateDTP.Enabled = true;
            timeOfReturnDTP.Enabled = false;

            returnCreateLoanBTN.Text = "Add Loan";

        }

        private IEnumerable<Loan> LoanSearchResult()
        {
            IEnumerable<Loan> activeLoanFilter;
            if (loanFilterByField != null)
            {
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
            }
            else
                activeLoanFilter = loanService.All();

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
            if (createNewLoan == false)
                ClearLoanInfoPanel();
            currentLoanDisplay = loanList;
            LoansLV.Items.Clear();
            foreach (Loan loan in loanList)
            {
                ListViewItem lvi = new ListViewItem(loan.Id.ToString());
                lvi.SubItems.Add(loan.BookCopy.Id.ToString());
                lvi.SubItems.Add(loan.BookCopy.Book.Title);
                lvi.SubItems.Add(loan.Member.ToString());
                lvi.SubItems.Add(loan.StartDate.ToShortDateString());
                LoansLV.Items.Add(lvi);
            }
        }
    }
}
