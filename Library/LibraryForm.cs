﻿using Library.Models;
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

namespace Library
{
    public partial class LibraryForm : Form
    {

        BookService bookService;

        public LibraryForm()
        {
            InitializeComponent();

            // we create only one context in our application, which gets shared among repositories
            LibraryContext context = new LibraryContext();
            // we use a factory object that will create the repositories as they are needed, it also makes
            // sure all the repositories created use the same context.
            RepositoryFactory repFactory = new RepositoryFactory(context);

            this.bookService = new BookService(repFactory);

            //Adds event listener to bookservice.
            this.bookService.Updated += UpdateBookListEvent;
            ShowAllBooks(bookService.All());
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
            lbBooks.Items.Clear();
            foreach (Book book in bookService.All())
            {
                lbBooks.Items.Add(book);
            }
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
            lbBooks.Items.Clear();
            foreach (Book book in bookList)
            {
                lbBooks.Items.Add(book);
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
                    Description = editDescriptionTB.ToString()
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
                    b.Description = editDescriptionTB.ToString();
                    bookService.Edit(b);
                }
            }
        }
    }
}
