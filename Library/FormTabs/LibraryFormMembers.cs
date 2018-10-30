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

namespace Library
{
    public partial class LibraryForm : Form
    {

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


        //BUTTONS
        private void newMemberBTN_Click(object sender, EventArgs e)
        {
            ClearMemberResultsPanel();
            lbMemberResults.ClearSelected();
            memberNameBox.Select();
        }

        private void removeMemberBTN_Click(object sender, EventArgs e)
        {

        }

        private void saveMemberBTN_Click(object sender, EventArgs e)
        {

        }

        //Searchbox
        private void findMemberSearchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbMemberResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void memberIdBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void membersTab_Click(object sender, EventArgs e)
        {

        }

        private void memberPersonnummerBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void memberNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbMemberLoans_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void showPreviousLoans_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
