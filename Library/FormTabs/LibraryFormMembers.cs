using Library.Models;
using Library.Repositories;
using Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// contains all methods and events from the Members tab of the form. LibraryForm.cs contains initialization of form.
    /// </summary>
    public partial class LibraryForm : Form
    {
        /// <summary>
        /// as you enter the members-tab the current members will display and the searchbox will reset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void membersTab_Enter(object sender, EventArgs e)
        {
            UpdateMemberList(memberService.All().ToList());
            findMemberSearchBox.ResetText();
        }

        /// <summary>
        /// Sets the current active backgroundPanel by changing panel colors
        /// </summary>
        /// <param name="panelNr">The panelNr that is to be selected. Starts from 0, based on the displayOrder from left to right.</param>
        private void SetActiveMemberPanel(int panelNr)
        {
            switch (panelNr)
            {
                case 0:
                    memberSearchBGPanel.BackColor = activePanelColor;
                    memberInfoBGPanel.BackColor = inactivePanelColor;
                    memberLoanBGPanel.BackColor = inactivePanelColor;
                    break;
                case 1:
                    memberSearchBGPanel.BackColor = inactivePanelColor;
                    memberInfoBGPanel.BackColor = activePanelColor;
                    memberLoanBGPanel.BackColor = inactivePanelColor;
                    break;
                case 2:
                    memberSearchBGPanel.BackColor = inactivePanelColor;
                    memberInfoBGPanel.BackColor = inactivePanelColor;
                    memberLoanBGPanel.BackColor = activePanelColor;
                    break;
                default:
                    memberSearchBGPanel.BackColor = inactivePanelColor;
                    memberInfoBGPanel.BackColor = inactivePanelColor;
                    memberLoanBGPanel.BackColor = inactivePanelColor;
                    break;
            }
        }

        /// <summary>
        /// When a control inside the panel gets focus it sets this panel as the focused panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memberSearchBGPanel_Enter(object sender, EventArgs e)
        {
            SetActiveMemberPanel(0);
        }

        /// <summary>
        /// When a control inside the panel gets focus it sets this panel as the focused panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memberInfoBGPanel_Enter(object sender, EventArgs e)
        {
            SetActiveMemberPanel(1);
        }

        /// <summary>
        /// When a control inside the panel gets focus it sets this panel as the focused panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memberLoanBGPanel_Enter(object sender, EventArgs e)
        {
            SetActiveMemberPanel(2);
        }

        private void UpdateMemberListEvent(object sender, EventArgs e)
        {
            UpdateMemberList(memberService.All().ToList());
        }

        /// <summary>
        /// Updates the member list with currently displayed members and resets member info
        /// </summary>
        /// <param name="memberList"></param>
        private void UpdateMemberList(List<Member> memberList)
        {
            currentMemberDisplay = memberList;
            lbMemberResults.Items.Clear();
            foreach (Member member in memberList)
            {
                lbMemberResults.Items.Add(member);
            }
            ClearMemberResultsPanel();

        }
        /// <summary>
        /// Method that clears the member info panel
        /// </summary>
        public void ClearMemberResultsPanel()
        {
            memberNameBox.ResetText();
            memberPersonnummerBox.ResetText();
        }
        /// <summary>
        /// clears the member loans panel (the info textboxes of loans)
        /// </summary>
        public void ClearMemberLoansPanel()
        {
            loanIdTB.ResetText();
            timeOfLoanTB.ResetText();
            timeOfReturnTB.ResetText();
            dueDateTB.ResetText();
            feesDueTB.ResetText();
        }


        //BUTTONS
        /// <summary>
        /// this button clears all windows in order to create a new member from scratch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newMemberBTN_Click(object sender, EventArgs e)
        {
            ClearMemberResultsPanel();
            lbMemberResults.ClearSelected();

        }
        /// <summary>
        /// Removes selected member after asking for confirmation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeMemberBTN_Click(object sender, EventArgs e)
        {
            // Can only remove book if a book is selected.
            if (lbMemberResults.SelectedItem != null)
            {
                string confirmBoxText = "By proceeding you will remove: '" + currentMemberDisplay[lbMemberResults.SelectedIndex] + "' from the database.\r\n" +
                                        "This process can not be reverted and may lead to problems with broken database references.";
                string confirmBoxTitle = "Confirm member removal";
                if (ConfirmedPopup(confirmBoxText, confirmBoxTitle))
                {
                    Member selectedMember = currentMemberDisplay[lbMemberResults.SelectedIndex];

                    memberService.Remove(selectedMember);
                    UpdateMemberList(memberService.All().ToList());
                }
            }
        }

        /// <summary>
        /// Saves the edited member info or new member.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveMemberBTN_Click(object sender, EventArgs e)
        {
            if (lbMemberResults.SelectedItem == null)
            {
                Member newMember = new Member()
                {
                    personalID = memberPersonnummerBox.Text,
                    Name = memberNameBox.Text
                };

                memberService.Add(newMember);
                UpdateMemberList(memberService.All().ToList());
            }
            else
            {
            
                string confirmBoxText = "You are about to edit: '" + currentMemberDisplay[lbMemberResults.SelectedIndex] + "'.\r\n" +
                                        "Please verify that all book information is correct before confirmation.";
                string confirmBoxTitle = "Confirm Member Info Update";
                if (ConfirmedPopup(confirmBoxText, confirmBoxTitle))
                {
                    if (lbMemberResults.SelectedItem is Member m)
                    {
                        m.personalID = memberPersonnummerBox.Text;
                        m.Name = memberNameBox.Text;
                        memberService.Edit(m);
                    }
                }
            }
        }

        //When you click the button the selected member will be inserted into the loans tab new loan info.
        private void memberLoanBTN_Click(object sender, EventArgs e)
        {
            if (lbMemberResults.SelectedItem != null) //If you have selected a member, otherwise it cant create a new loan
            {
                memberLoanTB.Text = lbMemberResults.SelectedItem.ToString();
                createNewLoan = true;
                if (bookCopyLoanTB.Text == "")
                {
                    tabControl1.SelectTab(0);
                    string confirmBoxText = "Select a book and a bookCopy and click New Loan to add the bookCopy to the loan.";
                    string confirmBoxTitle = "Select bookcopy to create a new loan";
                    InfoPopup(confirmBoxText, confirmBoxTitle);
                }
                else
                {
                    tabControl1.SelectTab(2);
                }
            }
            else
            {
                string confirmBoxText = "Select a bookcopy from the list before you click New Loan.";
                string confirmBoxTitle = "Select bookcopy";
                InfoPopup(confirmBoxText, confirmBoxTitle);
            }
        }



        /// <summary>
        /// Updates the members displayed in the listbox as you type the name you're looking for.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findMemberSearchBox_TextChanged(object sender, EventArgs e)
        {
            UpdateMemberList(memberService.GetAllThatContainsInName(findMemberSearchBox.Text).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMemberResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cleared selection
            if (lbMemberResults.SelectedItem == null)
            {
                ClearMemberResultsPanel();
                ClearMemberLoansPanel();
                lbMemberLoans.Items.Clear();

            }
            else // When a new member is selected
            {
                Member selectedMember = currentMemberDisplay[lbMemberResults.SelectedIndex];

                UpdateMemberInfoPanel(selectedMember);
                currentLoanDisplay = selectedMember.Loans;
                memberLoanTB.Text = selectedMember.ToString();
                createNewLoan = true;
                lbMemberLoans.Items.Clear();
                if (showActiveLoansCB.Checked)
                {   //only displays loans with no returndates = active loans
                    for (var i = 0; i < selectedMember.Loans.Count && selectedMember.Loans[i].ReturnDate == null; i++)
                    {
                        Loan lc = selectedMember.Loans[i];
                        lbMemberLoans.Items.Add(lc.BookCopy.Book.Title);
                    }
                }
                else
                {
                    foreach (Loan l in selectedMember.Loans)
                    {
                        lbMemberLoans.Items.Add(l.BookCopy.Book.Title);
                    }
                }                
            }
        }
        /// <summary>
        /// When you change selection of a member's loan, the panel displaying loan info changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMemberLoans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMemberLoans.SelectedItem == null)
            {
                ClearMemberLoansPanel();
            }
            else
            {
                Loan selectedLoan = currentLoanDisplay[lbMemberLoans.SelectedIndex];
                UpdateMemberLoanPanel(selectedLoan);
            }
        }

        public void UpdateMemberInfoPanel(Member selectedMember)
        {
            memberPersonnummerBox.Text = selectedMember.personalID;
            memberNameBox.Text = selectedMember.Name;


        }
        /// <summary>
        /// Updates the loan info panel with information about the selected member loan
        /// </summary>
        /// <param name="selectedLoan"></param>
        public void UpdateMemberLoanPanel(Loan selectedLoan)
        {
            loanIdTB.Text = selectedLoan.Id.ToString();
            timeOfLoanTB.Text = selectedLoan.StartDate.Date.ToShortDateString();
            string returnDate = "";
            if (selectedLoan.ReturnDate != null)
                returnDate = ((DateTime)selectedLoan.ReturnDate).Date.ToShortDateString();
            timeOfReturnTB.Text = returnDate;
            dueDateTB.Text = selectedLoan.DueDate.Date.ToShortDateString();
            feesDueTB.Text = CalculateLoanFine(selectedLoan).ToString();
        }

        /// <summary>
        /// Displays different results in the member loans listbox depending on checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showActiveLoansCB_CheckedChanged(object sender, EventArgs e)
        {
            Member selectedMember = currentMemberDisplay[lbMemberResults.SelectedIndex];
            lbMemberLoans.Items.Clear();
            if (showActiveLoansCB.Checked)
            {   //only displays loans with no returndates = active loans
                for (var i = 0; i < selectedMember.Loans.Count && selectedMember.Loans[i].ReturnDate == null; i++)
                {
                    Loan lc = selectedMember.Loans[i];
                    lbMemberLoans.Items.Add(lc.BookCopy.Book.Title);
                }
            }
            else
            {
                foreach (Loan l in selectedMember.Loans)
                {
                    lbMemberLoans.Items.Add(l.BookCopy.Book.Title);
                }
            }
        }
    }
}
