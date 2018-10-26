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

            //Adds event listener to bookservice.
            this.bookService.Updated += UpdateBookListEvent;
            this.bookCopyService.Updated += UpdateBookCopyListEvent;
            ShowAllBooks(bookService.All());
            currentBookDisplay = bookService.All().ToList();
            currentBookCopyDisplay = new List<BookCopy>();
        }
        

        private void ShowAllBooks(IEnumerable<Book> books)
        {
            lbBooks.Items.Clear();
            foreach (Book book in books)
            {
                lbBooks.Items.Add(book);
            }
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
            //lbBooks.Items.Clear();
            //foreach (Book book in bookService.All())
            //{
            //    lbBooks.Items.Add(book);
            //}
        }

        private void UpdateBookCopyListEvent(object sender, EventArgs e)
        {
            //UpdateBookList(bookService.All().ToList());
        }

        private void addBookBTN_Click(object sender, EventArgs e)
        {

        }

        private void removeBookBTN_Click(object sender, EventArgs e)
        {

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
                Book selectedBook = currentBookDisplay[lbBooks.SelectedIndex];
                BookCopy newBookCopy = new BookCopy()
                {
                    Book = selectedBook
                };
                // Adds the new copy to the database
                bookCopyService.Add(newBookCopy);

                // Updates the bookCopy listbox to reflect the changes by displaying all(including the new) book copies of the aforementioned book
                UpdateBookCopyList(bookCopyService.GetAllCopiesByBook(selectedBook).ToList());

                // Makes the newly created copy the selected item in the listbox
                lbCopies.SelectedIndex = currentBookCopyDisplay.IndexOf(newBookCopy);

            }
            
        }

        private void removeCopyBTN_Click(object sender, EventArgs e)
        {

        }

        private void findTitleTB_TextChanged(object sender, EventArgs e)
        {
            UpdateBookList(bookService.GetAllThatContainsInTitle(findTitleTB.Text).ToList());
        }

        private void UpdateBookList(List<Book> bookList)
        {
            currentBookDisplay = bookList;
            Debug.WriteLine("Attempting to Update bookList");
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
            Debug.WriteLine("Attempting to Update bookCopyList");
            lbCopies.Items.Clear();
            foreach (BookCopy bc in bookCopyList)
            {
                lbCopies.Items.Add(bc);
            }
        }

        private void saveChangesBTN_Click(object sender, EventArgs e)
        {
            Author auth = new Author()
            {
                Name = editAuthorTB.Text
            };
            List<Author> authorlist = new List<Author>();
            authorlist.Add(auth);
            // Create new book
            if (lbBooks.SelectedItem == null)
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
            else //Update Book
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
                editISBNTB.ResetText();
                editTitleTB.ResetText();
                editAuthorTB.ResetText();
                editDescriptionTB.ResetText();

                // Updates the bookCopy listbox to an empty listBox because we dont want to display any copies when no book is selected
                UpdateBookCopyList(new List<BookCopy>());
            }
            else
            {
                Book selectedBook = currentBookDisplay[lbBooks.SelectedIndex];
                editTitleTB.Text = selectedBook.Title;
                editISBNTB.Text = selectedBook.ISBN;
                if (selectedBook.Authors.Any()) // If Author has been set for the book -> display the first authors name.
                    editAuthorTB.Text = selectedBook.Authors[0].ToString();
                else // If the book has no registered Author then display empty string
                    editAuthorTB.Text = "";
                editDescriptionTB.Text = selectedBook.Description;

                // Updates the bookCopy listbox to reflect the changes by displaying all(including the new) book copies of the aforementioned book
                UpdateBookCopyList(bookCopyService.GetAllCopiesByBook(selectedBook).ToList());
            }
        }
    }
}
