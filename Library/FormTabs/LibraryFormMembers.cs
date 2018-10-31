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
    public partial class LibraryForm : Form
    {

        private void membersTab_Enter(object sender, EventArgs e)
        {
            UpdateMemberList(memberService.All().ToList());
            findMemberSearchBox.ResetText();
        }

        private void UpdateMemberListEvent(object sender, EventArgs e)
        {
            UpdateMemberList(memberService.All().ToList());
        }

        private void UpdateMemberList(List<Member> memberList)
        {
            currentMemberDisplay = memberList;
            lbMemberResults.Items.Clear();
            foreach (Member member in memberList)
            {
                lbMemberResults.Items.Add(member);
            }
            memberIdBox.ResetText();
            memberNameBox.ResetText();
            memberPersonnummerBox.ResetText();

        }

        public void ClearMemberResultsPanel()
        {
            memberIdBox.ResetText();
            memberNameBox.ResetText();
            memberPersonnummerBox.ResetText();
        }

        public void ClearMemberLoansPanel()
        {
            loanIdTB.ResetText();
            timeOfLoanTB.ResetText();
            timeOfReturnTB.ResetText();
            dueDateTB.ResetText();
            
        }


        //BUTTONS
        private void newMemberBTN_Click(object sender, EventArgs e)
        {
            ClearMemberResultsPanel();
            lbMemberResults.ClearSelected();
            memberIdBox.Select();
        }

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



        //Searchbox
        private void findMemberSearchBox_TextChanged(object sender, EventArgs e)
        {
            UpdateMemberList(memberService.GetAllThatContainsInTitle(findMemberSearchBox.Text).ToList());
        }

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
                memberLoanTB.Text = selectedMember.ToString();
                createNewLoan = true;
                lbMemberLoans.Items.Clear();
                foreach (Loan l in selectedMember.Loans)
                {
                    lbMemberLoans.Items.Add(l.BookCopy.Book.Title);
                }
            }
        }

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

            // Updates the bookCopy listbox to reflect the changes by displaying all(including the new) book copies of the aforementioned book
            //UpdateBookCopyList(bookCopyService.GetAllCopiesByBook(selectedBook).ToList());
        }

        public void UpdateMemberLoanPanel(Loan selectedLoan)
        {
            
            loanIdTB.Text = selectedLoan.Id.ToString();
            timeOfLoanTB.Text = selectedLoan.StartDate.ToString(CultureInfo.InvariantCulture);
            timeOfReturnTB.Text = selectedLoan.ReturnDate.ToString();
            dueDateTB.Text = selectedLoan.DueDate.ToString(CultureInfo.CurrentCulture);
            //feesDueTB.Text = selectedLoan.
        }



        private void memberIdBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void memberPersonnummerBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void memberNameBox_TextChanged(object sender, EventArgs e)
        {

        }



        private void showPreviousLoans_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void loanIdTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void timeOfLoanTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void timeOfReturnTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void dueDateTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void feesDueTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
