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
    /// <summary>
    /// Contains all methods and events from the Books tab of the Form. LibraryForm.cs contains initialization of form.
    /// </summary>
    public partial class LibraryForm : Form
    {
        int authorFields = 1;
        int maxAuthors = 4;
        TextBox bookFilterByField;

        // Non eventbound methods ---------------------------------------------------------

        /// <summary>
        /// Sets the current active backgroundPanel by changing panel colors
        /// </summary>
        /// <param name="panelNr">The panelNr that is to be selected. Starts from 0, based on the displayOrder from left to right.</param>
        private void SetActiveBookPanel(int panelNr)
        {
            switch (panelNr)
            {
                case 0:
                    booksSearchBGPanel.BackColor = activePanelColor;
                    bookInfoBGPanel.BackColor = inactivePanelColor;
                    bookCopiesBGPanel.BackColor = inactivePanelColor;
                    break;
                case 1:
                    booksSearchBGPanel.BackColor = inactivePanelColor;
                    bookInfoBGPanel.BackColor = activePanelColor;
                    bookCopiesBGPanel.BackColor = inactivePanelColor;
                    break;
                case 2:
                    booksSearchBGPanel.BackColor = inactivePanelColor;
                    bookInfoBGPanel.BackColor = inactivePanelColor;
                    bookCopiesBGPanel.BackColor = activePanelColor;
                    break;
                default:
                    booksSearchBGPanel.BackColor = inactivePanelColor;
                    bookInfoBGPanel.BackColor = inactivePanelColor;
                    bookCopiesBGPanel.BackColor = inactivePanelColor;
                    break;
            }
        }

        /// <summary>
        /// Updates the ListBox that displays Books. Also clears the BookInfoPanel, since no book is selected. Also Clears BookCopyList.
        /// </summary>
        /// <param name="bookList">The BookList that will be displayed in the ListBox</param>
        private void UpdateBookList(List<Book> bookList)
        {
            currentBookDisplay = bookList;
            lbBooks.Items.Clear();
            foreach (Book book in bookList)
            {
                lbBooks.Items.Add(book);
            }

            ClearBookInfoPanel();

            // Updates the bookCopy listbox to an empty listBox because we dont want to display any copies when no book is selected
            UpdateBookCopyList(new List<BookCopy>());
        }

        /// <summary>
        /// Updates the bookCopyList to display the input bookCopyList.
        /// </summary>
        /// <param name="bookCopyList">The BookCopyList to be displayed in the listbox</param>
        private void UpdateBookCopyList(List<BookCopy> bookCopyList)
        {
            currentBookCopyDisplay = bookCopyList;
            lbCopies.Items.Clear();
            for (int i = 0; i < bookCopyList.Count; i++)
            {
                lbCopies.Items.Add(bookCopyList[i]);
            }
        }

        /// <summary>
        /// Runs through checks to see if any of the bookinfo textboxes contains invalid input, if so it returns false. If all checks are passed, returns true.
        /// </summary>
        /// <returns>Returns true if all bookinfo textboxes contains valid input, otherwise returns false.</returns>
        private bool ValidBookInfo()
        {
            if (editTitleTB.Text.Trim().Length == 0)
                return false;
            if (editAuthorTB.Text.Trim().Length <= 2)
                return false;

            return true;
        }

        /// <summary>
        /// Clears all BookInfo and removes all excessive authorFields. Also clears the bookCopy list.
        /// </summary>
        public void ClearBookInfoPanel()
        {
            editISBNTB.ResetText();
            editTitleTB.ResetText();
            editAuthorTB.ResetText();
            editDescriptionTB.ResetText();
            RemoveAuthorFields();

            // Updates the bookCopy listbox to an empty listBox because we dont want to display any copies when no book is selected
            UpdateBookCopyList(new List<BookCopy>());
        }

        /// <summary>
        /// Creates a new input field for author, this will automatically be placed beneath the former authorField.
        /// </summary>
        /// <param name="text">The text that the authorField should contain</param>
        private void CreateAuthorField(string text)
        {
            TextBox newAuthorField = new System.Windows.Forms.TextBox();
            int authorTBIndex = BookInfoFLP.Controls.IndexOf(editAuthorTB);
            newAuthorField.BackColor = System.Drawing.SystemColors.Info;
            newAuthorField.Location = new System.Drawing.Point(47, 152);
            newAuthorField.Margin = new System.Windows.Forms.Padding(2);
            newAuthorField.Size = new System.Drawing.Size(226, 28);
            newAuthorField.AutoCompleteCustomSource.AddRange(authorService.GetAllAuthorNames().ToArray()); //Adds all the current authors to autocomplete list.
            newAuthorField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            newAuthorField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            newAuthorField.Text = text;

            BookInfoFLP.Controls.Add(newAuthorField);
            BookInfoFLP.Controls.SetChildIndex(newAuthorField, authorTBIndex + authorFields);

            authorFields++;
        }

        /// <summary>
        /// Creates a new empty input field for another author.
        /// </summary>
        private void CreateAuthorField()
        {
            CreateAuthorField("");
        }

        /// <summary>
        /// Updates the bookInfo Panel to reflect the information from the input book.
        /// </summary>
        /// <param name="selectedBook">The book that is to be displayed in bookInfoPanel</param>
        public void UpdateBookInfoPanel(Book selectedBook)
        {
            editTitleTB.Text = selectedBook.Title;
            editISBNTB.Text = selectedBook.ISBN;
            if (selectedBook.Authors.Count > 0) //Can only display author if the book has a author registered
                editAuthorTB.Text = selectedBook.Authors[0].ToString();
            editDescriptionTB.Text = selectedBook.Description;

            for (int i = 1; i < selectedBook.Authors.Count; i++) // Populate additional author fields if multiple authors are registered.
            {
                string authorName = selectedBook.Authors[i].ToString();
                if (i < authorFields)
                {
                    int currentFieldIndex = BookInfoFLP.Controls.IndexOf(editAuthorTB) + i;
                    BookInfoFLP.Controls[currentFieldIndex].Text = authorName;
                }
                else
                {
                    CreateAuthorField(authorName);
                }
            }
            int deleteAuthorFieldCount = authorFields - selectedBook.Authors.Count;
            if (deleteAuthorFieldCount > 0 && authorFields > 1)
                RemoveAuthorFields(authorFields - selectedBook.Authors.Count); // Remove Leftover Fields.

            // Updates the bookCopy listbox to reflect the changes by displaying all(including the new) book copies of the aforementioned book
            UpdateBookCopyList(bookCopyService.GetAllCopiesByBook(selectedBook).ToList());
        }

        /// <summary>
        /// Removes a specific amount of authorFields from BookInfoPanel.
        /// </summary>
        /// <param name="count">The amount of authorFields that is to be removed</param>
        private void RemoveAuthorFields(int count)
        {
            // Removes additional author textboxes.
            int authorTBIndex = BookInfoFLP.Controls.IndexOf(editAuthorTB);
            for (int i = authorTBIndex + authorFields; i > authorTBIndex + authorFields - count; i--)
            {
                BookInfoFLP.Controls.RemoveAt(i - 1);
            }
            authorFields -= count;
        }

        /// <summary>
        /// Removes all authorFields except for one. 
        /// </summary>
        private void RemoveAuthorFields()
        {
            if (authorFields > 1)
                RemoveAuthorFields(authorFields - 1);
        }

        /// <summary>
        /// Reads the current textboxFilter and checks if the onlyAvailable checkbox is ticket, and combines the results of the filters and returns the result as a book Collection.
        /// </summary>
        /// <returns>Returns a collection of Books that fit the active search criteria.</returns>
        private IEnumerable<Book> SearchResult()
        {
            IEnumerable<Book> activeFilter;
            if (bookFilterByField != null)
            {
                switch (bookFilterByField.Name)
                {
                    case "findAuthorTB":
                        activeFilter = bookService.GetAllThatContainsAuthor(findAuthorTB.Text);
                        break;

                    case "findTitleTB":
                        activeFilter = bookService.GetAllThatContainsInTitle(findTitleTB.Text);
                        break;

                    case "findISBNTB":
                        activeFilter = bookService.GetAllThatContainsISBN(findISBNTB.Text);
                        break;

                    default:
                        activeFilter = bookService.All();
                        break;
                }
            }
            else
                activeFilter = bookService.All();
            if (AvailableCHK.Checked)
            {
                IEnumerable<Book> availableFiltered = bookService.GetAllAvailableBooks().ToList();
                activeFilter = bookService.CombineFilteredLists(activeFilter, availableFiltered);
            }
            return activeFilter;
        }



        // Eventbound methods ---------------------------------------------------------

        /// <summary>
        /// Resets the tab to empty search parameters and lists all books.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void booksTab_Enter(object sender, EventArgs e)
        {
            UpdateBookList(bookService.All().ToList());
            findTitleTB.ResetText();
            findAuthorTB.ResetText();
            findISBNTB.ResetText();
        }

        /// <summary>
        /// When a control inside the panel gets focus it sets this panel as the focused panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void booksSearchBGPanel_Enter(object sender, EventArgs e)
        {
            SetActiveBookPanel(0);
        }

        /// <summary>
        /// When a control inside the panel gets focus it sets this panel as the focused panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookInfoBGPanel_Enter(object sender, EventArgs e)
        {
            SetActiveBookPanel(1);
        }

        /// <summary>
        /// When a control inside the panel gets focus it sets this panel as the focused panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookCopiesBGPanel_Enter(object sender, EventArgs e)
        {
            SetActiveBookPanel(2);
        }

        /// <summary>
        /// Updates the BookList whenever a book is Added/Removed/Changed in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBookListEvent(object sender, EventArgs e)
        {
            UpdateBookList(bookService.All().ToList());
        }

        /// <summary>
        /// Updates the bookCopyList based on selected book whenever a BookCopy is Added/Removed/Changed in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBookCopyListEvent(object sender, EventArgs e)
        {
            Book selectedBook = currentBookDisplay[lbBooks.SelectedIndex];

            // Updates the bookCopy listbox to reflect the changes by displaying all(including the new) book copies of the aforementioned book
            UpdateBookCopyList(bookCopyService.GetAllCopiesByBook(selectedBook).ToList());
        }

        /// <summary>
        /// Clears the BookInfoPanel to allow for new input and moves the focus to the editTitle textbox to allow the user to instantly start entering the new bookinformation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBookBTN_Click(object sender, EventArgs e)
        {
            ClearBookInfoPanel();
            lbBooks.ClearSelected();
            editTitleTB.Select();
        }

        /// <summary>
        /// If a book is selected, it removes the book from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// If a book has been selected, it adds a new copy of that book to the database, and makes the new bookcopy the selected bookCopy in the bookCopyListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// If a bookCopy has been selected, it removes the bookCopy from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Whenever the text in the BookTitle searchbox is modified a new search is made based on the updated input. Also sets the active searchfilter field to this textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findTitleTB_TextChanged(object sender, EventArgs e)
        {
            bookFilterByField = findTitleTB;
            UpdateBookList(SearchResult().ToList());
        }

        /// <summary>
        /// Whenever the text in the AuthorName searchbox is modified a new search is made based on the updated input. Also sets the active searchfilter field to this textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findAuthorTB_TextChanged(object sender, EventArgs e)
        {
            bookFilterByField = findAuthorTB;
            UpdateBookList(SearchResult().ToList());
        }

        /// <summary>
        /// Whenever the text in the ISBN searchbox is modified a new search is made based on the updated input. Also sets the active searchfilter field to this textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findISBNTB_TextChanged(object sender, EventArgs e)
        {
            bookFilterByField = findISBNTB;
            UpdateBookList(SearchResult().ToList());
        }

        /// <summary>
        /// Validates the input fields and then if a book has been selected it Saves the changes made to that book, otherwise it creates a new Book.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveChangesBTN_Click(object sender, EventArgs e)
        {
            if (ValidBookInfo()) // Confirms that all input fields are valid before continuing.
            {

                // Reads all author input fields that are open and saves the author names in a string list
                List<string> authorNames = new List<string>(); 
                int authorTBIndex = BookInfoFLP.Controls.IndexOf(editAuthorTB);
                for (int i = 0; i < authorFields; i++)
                {
                    TextBox currentTB = (TextBox)BookInfoFLP.Controls[authorTBIndex + i];
                    authorNames.Add(currentTB.Text);
                }
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
            else // If not all input fields were valid entries.
            {
                string confirmBoxText = "All fields did not contain valid data. Make sure your Author and Title fields are filled out.";
                string confirmBoxTitle = "Invalid book entry";
                InfoPopup(confirmBoxText, confirmBoxTitle);
            }
        }

        /// <summary>
        /// Clears bookInfoPanel if no item was selected, otherwise updates BookInfoPanel to reflect the selected book.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Updates the BookList based on a new SearchResult(which reads the AvailableCHK and filters based on the CheckStatus)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AvailableCHK_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBookList(SearchResult().ToList());
        }

        /// <summary>
        /// If an item is selected it puts the value into the bookCopyLoan textbox on the loans tab. So that the user doesnt manually have to enter the bookCopy when creating a new loan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCopies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCopies.SelectedItem != null)
            {
                bookCopyLoanTB.Text = lbCopies.SelectedItem.ToString();
                createNewLoan = true;
            }
        }

        /// <summary>
        /// Moves the user to the Loans tab and fills in bookCopy for the new Loan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCopies_DoubleClick(object sender, EventArgs e)
        {
            if (lbCopies.SelectedItem != null) //If you double clicked on a item
            {
                tabControl1.SelectTab(2);
                bookCopyLoanTB.Text = lbCopies.SelectedItem.ToString();
                createNewLoan = true;
            }
        }

        /// <summary>
        /// Creates a new AuthorField if the current authorFieldCount is less than maxAuthors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAuthorBTN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (authorFields < maxAuthors)
            {
                CreateAuthorField();
            }
        }

        /// <summary>
        /// Removes the last authorField if there are more than one existing authorFields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAuthorBTN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (authorFields > 1) // Checks to make sure you dont delete last authorField
            {
                int lastAuthorFieldIndex = BookInfoFLP.Controls.IndexOf((Control)sender) + 1 + authorFields; //Place after last authorField
                BookInfoFLP.Controls.RemoveAt(lastAuthorFieldIndex);

                authorFields--;
            }
        }

        /// <summary>
        /// If a bookCopy is selected, it fills in the bookCopy for the new loan and moves user to the Member Panel if no member has been selected for the loan,
        /// otherwise it moves the user to the loan tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewLoanBooksBTN_Click(object sender, EventArgs e)
        {
            if (lbCopies.SelectedItem != null) //If you have selected a bookCopy, otherwise it cant create a new loan
            {
                bookCopyLoanTB.Text = lbCopies.SelectedItem.ToString();
                createNewLoan = true;
                if (memberLoanTB.Text == "") // If no member has been selected for the loan, go to the members tab
                {
                    tabControl1.SelectTab(1);
                    string confirmBoxText = "Select a member to add the loan to and click New Loan.";
                    string confirmBoxTitle = "Select member to create a new loan";
                    InfoPopup(confirmBoxText, confirmBoxTitle);
                }
                else // Otherwise, go to loan tab
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
        /// Updates the autoComplete options for all authorFields so that they include all authors in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdatedAuthorEvent(object sender, EventArgs e)
        {
            foreach (TextBox authorField in BookInfoFLP.Controls) // Checks for all author textboxes in BookInfo panel.
            {
                if (authorField.AutoCompleteMode == AutoCompleteMode.SuggestAppend) 
                {
                    authorField.AutoCompleteCustomSource.AddRange(authorService.GetAllAuthorNames().ToArray()); //Adds all the current authors to autocomplete list.
                }
            }
        }

        /// <summary>
        /// Custom draw mode to enable text coloring based on bookCopy availability.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCopies_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1) // If user clicked on an actual item from the listbox.
            {
                BookCopy item = lbCopies.Items[e.Index] as BookCopy; // Get the current item and cast it to MyListBoxItem
                e.DrawBackground();
                e.DrawFocusRectangle();
                if (item != null)
                {
                    Color color = availableColor;
                    if (item.OnActiveLoan())
                        color = unavailableColor;
                    e.Graphics.DrawString( // Draw the appropriate text in the ListBox
                        item.ToString(), // The message linked to the item
                        lbCopies.Font, // Take the font from the listbox
                        new SolidBrush(color), // Set the color 
                        0, // X pixel coordinate
                        e.Index * lbCopies.ItemHeight // Y pixel coordinate.  Multiply the index by the ItemHeight defined in the listbox.
                    );
                }
                else
                {
                    e.Graphics.DrawString( // Draw the appropriate text in the ListBox
                        lbCopies.Items[e.Index].ToString(), // The message linked to the item
                        lbCopies.Font, // Take the font from the listbox
                        new SolidBrush(Color.Black), // Set the color 
                        0, // X pixel coordinate
                        e.Index * lbCopies.ItemHeight // Y pixel coordinate.  Multiply the index by the ItemHeight defined in the listbox.
                    );
                }
            }
        }
    }
}
