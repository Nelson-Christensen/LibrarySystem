namespace Library {
    partial class LibraryForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lbBooks = new System.Windows.Forms.ListBox();
            this.BTNChangeBook = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.booksTab = new System.Windows.Forms.TabPage();
            this.membersTab = new System.Windows.Forms.TabPage();
            this.loansTab = new System.Windows.Forms.TabPage();
            this.addBookBTN = new System.Windows.Forms.Button();
            this.RemoveBookBTN = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.booksTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbBooks
            // 
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.ItemHeight = 20;
            this.lbBooks.Location = new System.Drawing.Point(34, 122);
            this.lbBooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(271, 244);
            this.lbBooks.TabIndex = 0;
            // 
            // BTNChangeBook
            // 
            this.BTNChangeBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNChangeBook.Location = new System.Drawing.Point(481, 482);
            this.BTNChangeBook.Name = "BTNChangeBook";
            this.BTNChangeBook.Size = new System.Drawing.Size(122, 54);
            this.BTNChangeBook.TabIndex = 1;
            this.BTNChangeBook.Text = "TEST: Change the book title";
            this.BTNChangeBook.UseVisualStyleBackColor = true;
            this.BTNChangeBook.Click += new System.EventHandler(this.BTNChangeBook_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.booksTab);
            this.tabControl1.Controls.Add(this.membersTab);
            this.tabControl1.Controls.Add(this.loansTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1199, 586);
            this.tabControl1.TabIndex = 2;
            // 
            // booksTab
            // 
            this.booksTab.Controls.Add(this.RemoveBookBTN);
            this.booksTab.Controls.Add(this.addBookBTN);
            this.booksTab.Controls.Add(this.lbBooks);
            this.booksTab.Controls.Add(this.BTNChangeBook);
            this.booksTab.Location = new System.Drawing.Point(4, 29);
            this.booksTab.Name = "booksTab";
            this.booksTab.Padding = new System.Windows.Forms.Padding(3);
            this.booksTab.Size = new System.Drawing.Size(1191, 553);
            this.booksTab.TabIndex = 0;
            this.booksTab.Text = "Books";
            this.booksTab.UseVisualStyleBackColor = true;
            // 
            // membersTab
            // 
            this.membersTab.Location = new System.Drawing.Point(4, 29);
            this.membersTab.Name = "membersTab";
            this.membersTab.Padding = new System.Windows.Forms.Padding(3);
            this.membersTab.Size = new System.Drawing.Size(903, 351);
            this.membersTab.TabIndex = 1;
            this.membersTab.Text = "Members";
            this.membersTab.UseVisualStyleBackColor = true;
            // 
            // loansTab
            // 
            this.loansTab.Location = new System.Drawing.Point(4, 29);
            this.loansTab.Name = "loansTab";
            this.loansTab.Size = new System.Drawing.Size(903, 351);
            this.loansTab.TabIndex = 2;
            this.loansTab.Text = "Loans";
            this.loansTab.UseVisualStyleBackColor = true;
            // 
            // addBookBTN
            // 
            this.addBookBTN.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBookBTN.Location = new System.Drawing.Point(54, 26);
            this.addBookBTN.Name = "addBookBTN";
            this.addBookBTN.Size = new System.Drawing.Size(87, 38);
            this.addBookBTN.TabIndex = 2;
            this.addBookBTN.Text = "Add";
            this.addBookBTN.UseVisualStyleBackColor = true;
            // 
            // RemoveBookBTN
            // 
            this.RemoveBookBTN.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveBookBTN.Location = new System.Drawing.Point(185, 26);
            this.RemoveBookBTN.Name = "RemoveBookBTN";
            this.RemoveBookBTN.Size = new System.Drawing.Size(120, 38);
            this.RemoveBookBTN.TabIndex = 3;
            this.RemoveBookBTN.Text = "Remove";
            this.RemoveBookBTN.UseVisualStyleBackColor = true;
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 599);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LibraryForm";
            this.Text = "Library";
            this.tabControl1.ResumeLayout(false);
            this.booksTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbBooks;
        private System.Windows.Forms.Button BTNChangeBook;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage booksTab;
        private System.Windows.Forms.TabPage membersTab;
        private System.Windows.Forms.TabPage loansTab;
        private System.Windows.Forms.Button RemoveBookBTN;
        private System.Windows.Forms.Button addBookBTN;
    }
}

