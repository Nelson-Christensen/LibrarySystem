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

        BookService bookService;
        BookCopyService bookCopyService;
        AuthorService authorService;
        List<Book> currentBookDisplay;
        List<BookCopy> currentBookCopyDisplay;

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

            //Adds event listener to bookservice.
            this.bookService.Updated += UpdateBookListEvent;
            this.bookCopyService.Updated += UpdateBookCopyListEvent;
            UpdateBookList(bookService.All().ToList());
            currentBookDisplay = bookService.All().ToList();
            currentBookCopyDisplay = new List<BookCopy>();
        }

        private void BTNChangeBook_Click(object sender, EventArgs e)
        {
            Book b = lbBooks.SelectedItem as Book;
            if (b != null)
            {
                b.Title = "Yoyoma";
                bookService.Edit(b);
            }
        }

        private void UpdateBookListEvent(object sender, EventArgs e)
        {
            UpdateBookList(bookService.All().ToList());
        }

        private void UpdateBookCopyListEvent(object sender, EventArgs e)
        {
            Book selectedBook = currentBookDisplay[lbBooks.SelectedIndex];

            // Updates the bookCopy listbox to reflect the changes by displaying all(including the new) book copies of the aforementioned book
            UpdateBookCopyList(bookCopyService.GetAllCopiesByBook(selectedBook).ToList());
        }

        private void addBookBTN_Click(object sender, EventArgs e)
        {
            ClearBookInfoPanel();
            lbBooks.ClearSelected();
            editTitleTB.Select();
        }

        private void removeBookBTN_Click(object sender, EventArgs e)
        {
            // Can only remove book if a book is selected.
            if (lbBooks.SelectedItem != null)
            {
                string confirmBoxText = "By proceeding you will remove: '" + currentBookDisplay[lbBooks.SelectedIndex].ToString() + "' from the database.\r\n" +
                "This process can not be reverted and may lead to problems with broken database references.";
                string confirmBoxTitle = "Confirm book removal";
                if (ConfirmedPopup(confirmBoxText, confirmBoxTitle))
                {
                    Book selectedBook = currentBookDisplay[lbBooks.SelectedIndex];

                    bookService.Remove(selectedBook);
                    UpdateBookList(bookService.All().ToList());
                }
            }
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

        private void closeBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void booksNewLoanBTN_Click(object sender, EventArgs e)
        {

        }

        private void addCopyBTN_Click(object sender, EventArgs e)
        {
            // Can only add new copy if a book has been selected
            if (lbBooks.SelectedItem != null)
            {
                string confirmBoxText = "Do you want to add a new copy of the book: '" + currentBookDisplay[lbBooks.SelectedIndex].ToString() + "'?";
                string confirmBoxTitle = "Add new book copy";
                if (ConfirmedPopup(confirmBoxText, confirmBoxTitle))
                {
                    Book selectedBook = currentBookDisplay[lbBooks.SelectedIndex];
                    BookCopy newBookCopy = new BookCopy()
                    {
                        Book = selectedBook
                    };
                    // Adds the new copy to the database
                    bookCopyService.Add(newBookCopy);

                    // Makes the newly created copy the selected item in the listbox
                    lbCopies.SelectedIndex = currentBookCopyDisplay.IndexOf(newBookCopy);

                }
            }
            else
                InfoPopup("You need to select a book to add a copy of.", "Can't create book Copy");
        }

        private void removeCopyBTN_Click(object sender, EventArgs e)
        {
            if (lbCopies.SelectedItem != null)
            {
                string confirmBoxText = "By proceeding you will remove the selected book copy from the database.\r\n" +
                "This process can not be reverted and may lead to problems with broken database references.";
                string confirmBoxTitle = "Confirm book copy removal";
                if (ConfirmedPopup(confirmBoxText, confirmBoxTitle))
                {
                    bookCopyService.Remove(currentBookCopyDisplay[lbCopies.SelectedIndex]);
                }
            }
            else
                InfoPopup("You need to select a book copy to remove.", "Can't remove book Copy");
        }

        private void findTitleTB_TextChanged(object sender, EventArgs e)
        {
            UpdateBookList(bookService.GetAllThatContainsInTitle(findTitleTB.Text).ToList());
        }

        private void UpdateBookList(List<Book> bookList)
        {
            currentBookDisplay = bookList;
            lbBooks.Items.Clear();
            foreach (Book book in bookList)
            {
                lbBooks.Items.Add(book);
            }

            // Clears book info panel when you lose book selection.
            editISBNTB.ResetText();
            editTitleTB.ResetText();
            editAuthorTB.ResetText();
            editDescriptionTB.ResetText();
            // Updates the bookCopy listbox to an empty listBox because we dont want to display any copies when no book is selected
            UpdateBookCopyList(new List<BookCopy>());
        }


        private void UpdateBookCopyList(List<BookCopy> bookCopyList)
        {
            currentBookCopyDisplay = bookCopyList;
            lbCopies.Items.Clear();
            foreach (BookCopy bc in bookCopyList)
            {
                lbCopies.Items.Add(bc);
            }
        }

        private void saveChangesBTN_Click(object sender, EventArgs e)
        {
            string[] authorNames = editAuthorTB.Text.Split(',');
            bool createNewAuthor = false;
            List<Author> authorlist = new List<Author>();
            foreach (string an in authorNames)
            {
                Author auth = authorService.GetAuthorByName(an); // Checks to see if author with same name exists, if so, uses that author instead of creating a duplicate.
                if (auth == null) // If no author with the name was found
                {
                    createNewAuthor = true;
                    auth = new Author()
                    {
                        Name = an.Trim(' ') // Trim value to remove potential space before and after name
                    };
                }
                authorlist.Add(auth);
            }
            // Create new book
            if (lbBooks.SelectedItem == null)
            {
                string confirmBoxText = createNewAuthor ? "No author that matches your input was found, by continiuing you will create a new Author entry as well as a new book entry." :
                "Continuing will add a new book to the database. Please verify that all book information is correct before confirmation.";
                string confirmBoxTitle = "Confirm addition of new book";
                if (ConfirmedPopup(confirmBoxText, confirmBoxTitle))
                {
                    Book newBook = new Book()
                    {
                        Title = editTitleTB.Text,
                        ISBN = editISBNTB.Text,
                        Authors = authorlist,
                        Description = editDescriptionTB.Text
                    };

                    bookService.Add(newBook);
                    UpdateBookList(bookService.All().ToList());
                }
            }
            else //Update Book
            {
                string confirmBoxText = "You are about to edit: '" + currentBookDisplay[lbBooks.SelectedIndex].ToString() + "'.\r\n" +
                    "Please verify that all book information is correct before confirmation.";
                string confirmBoxTitle = "Confirm Book Info Update";
                if (ConfirmedPopup(confirmBoxText, confirmBoxTitle))
                {
                    Book b = lbBooks.SelectedItem as Book;
                    if (b != null)
                    {
                        b.Title = editTitleTB.Text;
                        b.ISBN = editISBNTB.Text;
                        b.Authors = authorlist;
                        b.Description = editDescriptionTB.Text;
                        bookService.Edit(b);
                    }
                }
            }
        }

        private void findAuthorTB_TextChanged(object sender, EventArgs e)
        {
            UpdateBookList(bookService.GetAllThatContainsAuthor(findAuthorTB.Text).ToList());
        }

        private void findISBNTB_TextChanged(object sender, EventArgs e)
        {
            UpdateBookList(bookService.GetAllThatContainsISBN(findISBNTB.Text).ToList());
        }

        private void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cleared selection
            if (lbBooks.SelectedItem == null)
            {
                ClearBookInfoPanel();
            }
            else // New Book Selected
            {
                Book selectedBook = currentBookDisplay[lbBooks.SelectedIndex];
                UpdateBookInfoPanel(selectedBook);
            }
        }

        public void UpdateBookInfoPanel(Book selectedBook)
        {
            editTitleTB.Text = selectedBook.Title;
            editISBNTB.Text = selectedBook.ISBN;
            editAuthorTB.Text = selectedBook.AllAuthorsToString();
            editDescriptionTB.Text = selectedBook.Description;

            // Updates the bookCopy listbox to reflect the changes by displaying all(including the new) book copies of the aforementioned book
            UpdateBookCopyList(bookCopyService.GetAllCopiesByBook(selectedBook).ToList());
        }

        public void ClearBookInfoPanel()
        {
            editISBNTB.ResetText();
            editTitleTB.ResetText();
            editAuthorTB.ResetText();
            editDescriptionTB.ResetText();

            // Updates the bookCopy listbox to an empty listBox because we dont want to display any copies when no book is selected
            UpdateBookCopyList(new List<BookCopy>());
        }
    }
}
