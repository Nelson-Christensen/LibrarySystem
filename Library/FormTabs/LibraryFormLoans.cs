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
        int dailyFine = 15;

        // Non eventbound methods ---------------------------------------------------------

        /// <summary>
        /// Sets the current active backgroundPanel by changing panel colors
        /// </summary>
        /// <param name="panelNr">The panelNr that is to be selected. Starts from 0, based on the displayOrder from left to right.</param>
        private void SetActiveLoanPanel(int panelNr)
        {
            switch (panelNr)
            {
                case 0:
                    loanSearchBGPanel.BackColor = activePanelColor;
                    loanInfoBGPanel.BackColor = inactivePanelColor;
                    break;
                case 1:
                    loanSearchBGPanel.BackColor = inactivePanelColor;
                    loanInfoBGPanel.BackColor = activePanelColor;
                    break;
                default:
                    loanSearchBGPanel.BackColor = inactivePanelColor;
                    loanInfoBGPanel.BackColor = inactivePanelColor;
                    break;
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


        /// <summary>
        /// Updates the loanInfoPanel based on input loan
        /// </summary>
        /// <param name="loan">The loan to be displayed in the loanInfoPanel</param>
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

        /// <summary>
        /// Clears the LoanInfoPanel of current loan, and sets it back to the default values. Also marks the loanInfoPanel as createNewLoan,
        /// which tells returnCreateLoanBTN that we are creating a new loan and not returning an existing loan.
        /// </summary>
        private void ClearLoanInfoPanel()
        {
            createNewLoan = true;

            bookCopyLoanTB.ResetText();
            memberLoanTB.ResetText();
            timeOfLoanDTP.Value = DateTime.Now; //Default timeOfLoan is today
            dueDateDTP.Value = DateTime.Now.AddDays(15); //Default dueDate is in 15days
            timeOfReturnDTP.Value = DateTime.Now;
            bookCopyLoanTB.Enabled = true;
            memberLoanTB.Enabled = true;
            timeOfLoanDTP.Enabled = true;
            dueDateDTP.Enabled = true;
            timeOfReturnDTP.Enabled = false;

            returnCreateLoanBTN.Text = "Add Loan";
        }

        /// <summary>
        /// Reads the current textboxFilter and reads the checkboxes and based on that it will combine the searchresults to narrow it down.
        /// </summary>
        /// <returns>Returns a collection of Loans that fit the active search criteria.</returns>
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


        /// <summary>
        /// Updates the ListView that displays all loans. Also colors the rows based on loan status.
        /// </summary>
        /// <param name="loanList">The LoanList that will be displayed in the ListView</param>
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
                // Color row based on if loan has been returned or not, and if the book is due or not.
                if (!loan.IsReturned)
                {
                    if (DateTime.Now.Date > loan.DueDate.Date) // If due date has passed.
                        lvi.ForeColor = unavailableColor;
                    else
                        lvi.ForeColor = availableColor;
                }
                else
                    lvi.ForeColor = inactiveColor;
                LoansLV.Items.Add(lvi);
            }
        }

        private int CalculateLoanFine(Loan loan)
        {
            if (loan.ReturnDate != null) //Book has been returned
            {
                DateTime returnDate = (DateTime)loan.ReturnDate; // Has to cast it to DateTime to allow operations and comparisons
                if (returnDate.Date > loan.DueDate.Date)
                {
                    int daysLate = (returnDate - loan.DueDate).Days;
                    return daysLate * dailyFine;
                }
                else
                    return 0;
            }
            else
                return 0;
        }


        // Eventbound methods ------------------------------------------------------------

        /// <summary>
        /// Adds all current bookCopies and members to the autoComplete for loan input textboxes. Also clears LoanInfoPanel if a loan is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When a control inside the panel gets focus it sets this panel as the focused panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loanSearchBGPanel_Enter(object sender, EventArgs e)
        {
            SetActiveLoanPanel(0);
        }

        /// <summary>
        /// When a control inside the panel gets focus it sets this panel as the focused panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loanInfoBGPanel_Enter(object sender, EventArgs e)
        {
            SetActiveLoanPanel(1);
        }

        /// <summary>
        /// ButtonEvent that creates a new loan if the user is in the process of creating a loan, or as returnbutton if the user has an existing loan selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                        UpdateLoanInfoPanel(newLoan); // Update info panel to reflect the loan return.
                        UpdateLoansList(currentLoanDisplay);

                        int loanIndex = currentLoanDisplay.FindIndex(a => a == newLoan);
                        LoansLV.Items[loanIndex].Selected = true;// Reselects the loan from the LoansListView

                        UpdateAvailableBookCopiesAutoComplete();
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
                loanService.ReturnLoan(loan, timeOfReturnDTP.Value);
                if (CalculateLoanFine(loan) > 0)
                {
                    string confirmBoxText = string.Format("The Book was returned {0} days late. Fine for a {0} day late return is {1}.", CalculateLoanFine(loan)/dailyFine, CalculateLoanFine(loan));
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
                UpdateLoansList(currentLoanDisplay);

                int loanIndex = currentLoanDisplay.FindIndex(a => a == loan);
                LoansLV.Items[loanIndex].Selected = true;// Reselects the loan from the LoansListView
            }
            UpdateAvailableBookCopiesAutoComplete();
        }

        private void UpdateAvailableBookCopiesAutoComplete()
        {
            bookCopyLoanTB.AutoCompleteCustomSource.AddRange(bookCopyService.GetAllAvailableBookCopyNames().ToArray()); //Adds all the current bookCopies to autocomplete list.
        }

        /// <summary>
        /// Removes the loan from the database if a loan has been selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Clears currently Selected loan and moves focus to BookCopyLoanTB so that the user can begin creating the new loan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newLoanBTN_Click(object sender, EventArgs e)
        {
            ClearLoanInfoPanel();
            LoansLV.SelectedItems.Clear();
            bookCopyLoanTB.Focus();
        }

        /// <summary>
        /// Updates the searchResults based on current input to allow instant search.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findTitleLoanTB_TextChanged(object sender, EventArgs e)
        {
            loanFilterByField = findTitleLoanTB;
            UpdateLoansList(LoanSearchResult().ToList());
        }

        /// <summary>
        /// Updates the searchResults based on current input to allow instant search.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findMemberLoanTB_TextChanged(object sender, EventArgs e)
        {
            loanFilterByField = findMemberLoanTB;
            UpdateLoansList(LoanSearchResult().ToList());
        }

        /// <summary>
        /// Updates the searchResults when check changes to reflect the new searchcriteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void activeLoansCHK_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLoansList(LoanSearchResult().ToList());
        }

        /// <summary>
        /// Updates the searchResults when check changes to reflect the new searchcriteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void overdueLoansCHK_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLoansList(LoanSearchResult().ToList());
        }

        /// <summary>
        /// Checks that an actual item has been selected, if so, it displays the selected loan in the loanInfo panel, if no loan has been selected (user deselects), it clears the loanInfo panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Update Event whenever a loan is Added/Removed/Changed from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdatedLoansEvent(object sender, EventArgs e)
        {
            UpdateLoansList(loanService.All().ToList());
        }
    }
}
