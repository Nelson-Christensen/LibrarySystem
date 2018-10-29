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
            this.authorService.Updated += UpdatedAuthorEvent;
            UpdateBookList(bookService.All().ToList());
            currentBookDisplay = bookService.All().ToList();
            currentBookCopyDisplay = new List<BookCopy>();

            editAuthorTB.AutoCompleteCustomSource.AddRange(authorService.GetAllAuthorNames().ToArray()); //Adds all the current authors to autocomplete list.
        }


    }
}
