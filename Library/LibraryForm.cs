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
    /// <summary>
    /// Contains Form initializer. All event handling and user interface handling is done by other partial classes found in the FormTabs folder.
    /// </summary>
    public partial class LibraryForm : Form
    {

        MemberService memberService;
        BookService bookService;
        BookCopyService bookCopyService;
        AuthorService authorService;
        LoanService loanService;
        List<Book> currentBookDisplay;
        List<BookCopy> currentBookCopyDisplay;
        List<Member> currentMemberDisplay;
        List<Loan> currentLoanDisplay;
        public Color unavailableColor = Color.Red;
        public Color inactiveColor = Color.DimGray;
        public Color availableColor = Color.Black;
        public Color activePanelColor = Color.FromArgb(240, 240, 240);
        public Color inactivePanelColor = Color.FromArgb(230, 230, 230);

        public Color windowColor; //Will be set when the program is run and taken from current forms bg color.
        public Color secondaryColor;

        // To Allow moving the window, even without default window border
        private bool mouseDown;
        private Point lastLocation;

        public LibraryForm()
        {
            InitializeComponent();

            // we create only one context in our application, which gets shared among repositories
            LibraryContext context = new LibraryContext();
            // we use a factory object that will create the repositories as they are needed, it also makes
            // sure all the repositories created use the same context.
            RepositoryFactory repFactory = new RepositoryFactory(context);

            this.bookService = new BookService(repFactory);
            this.bookCopyService = new BookCopyService(repFactory);
            this.authorService = new AuthorService(repFactory);
            this.memberService = new MemberService(repFactory);
            this.loanService = new LoanService(repFactory);

            //Adds event listener to bookService.
            this.bookService.Updated += UpdateBookListEvent;
            this.bookCopyService.Updated += UpdateBookCopyListEvent;
            this.authorService.Updated += UpdatedAuthorEvent;
            this.memberService.Updated += UpdateMemberListEvent;
            this.loanService.Updated += UpdatedLoansEvent;

            UpdateBookList(bookService.All().ToList());
            currentBookDisplay = bookService.All().ToList();
            currentBookCopyDisplay = new List<BookCopy>();
            currentMemberDisplay = memberService.All().ToList();
            currentLoanDisplay = loanService.All().ToList();

            SetAllColors();
            editAuthorTB.AutoCompleteCustomSource.AddRange(authorService.GetAllAuthorNames().ToArray()); //Adds all the current authors to autocomplete list.
        }

        /// <summary>
        /// Set Color of form elements based on variables to make the coloring more consistent across the form. Only needs to be executed once per session.
        /// </summary>
        private void SetAllColors()
        {
            windowColor = this.BackColor; // old values: 104; 0; 0
            secondaryColor = TopDragPanel.BackColor; // old values: 172; 30; 44
            minimizeBTN.FlatAppearance.MouseDownBackColor = windowColor;
            minimizeBTN.FlatAppearance.MouseOverBackColor = windowColor;
            closeBTN.FlatAppearance.MouseDownBackColor = windowColor;
            closeBTN.FlatAppearance.MouseOverBackColor = windowColor;


            SetActiveBookPanel(0);
            SetActiveMemberPanel(0);
            SetActiveLoanPanel(0);
            SetLegendColor();
        }
        private void SetLegendColor()
        {
            // Books tab
            availableCopyLegendLBL.ForeColor = availableColor;
            unavailableCopyLegendLBL.ForeColor = unavailableColor;

            //Members tab
            overdueLoanMLegendLBL.ForeColor = unavailableColor;
            returnedLoanMLegendLBL.ForeColor = inactiveColor;
            activeLoanMLegendLBL.ForeColor = availableColor;

            //Loans tab
            overdueLoanLegendLBL.ForeColor = unavailableColor;
            returnedLoanLegendLBL.ForeColor = inactiveColor;
            activeLoanLegendLBL.ForeColor = availableColor;
        }

        private bool ConfirmedPopup(string boxText, string boxTitle)
        {
            DialogResult dialog = MessageBox.Show(boxText, boxTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
                return true;
            else
                return false;
        }

        private void InfoPopup(string boxText, string boxTitle)
        {
            DialogResult dialog = MessageBox.Show(boxText, boxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        /// Taken from https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        private void TopDragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TopDragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void TopDragPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void minimizeBTN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
