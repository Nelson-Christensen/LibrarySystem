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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.booksTab = new System.Windows.Forms.TabPage();
            this.booksNewLoanBTN = new System.Windows.Forms.Button();
            this.lbCopies = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.removeCopyBTN = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.editBookIDTB = new System.Windows.Forms.TextBox();
            this.saveChangesBTN = new System.Windows.Forms.Button();
            this.removeBookBTN = new System.Windows.Forms.Button();
            this.addCopyBTN = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.editDescriptionTB = new System.Windows.Forms.RichTextBox();
            this.editAuthorTB = new System.Windows.Forms.TextBox();
            this.editTitleTB = new System.Windows.Forms.TextBox();
            this.editISBNTB = new System.Windows.Forms.TextBox();
            this.addBookBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.findISBNTB = new System.Windows.Forms.TextBox();
            this.findAuthorTB = new System.Windows.Forms.TextBox();
            this.findTitleTB = new System.Windows.Forms.TextBox();
            this.findBooksLabel = new System.Windows.Forms.Label();
            this.lbBooks = new System.Windows.Forms.ListBox();
            this.BTNChangeBook = new System.Windows.Forms.Button();
            this.membersTab = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lbMemberLoans = new System.Windows.Forms.ListBox();
            this.memberNameBox = new System.Windows.Forms.TextBox();
            this.memberPersonnummerBox = new System.Windows.Forms.TextBox();
            this.memberIdBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.removeMemberBTN = new System.Windows.Forms.Button();
            this.memberLoanBTN = new System.Windows.Forms.Button();
            this.newMemberBTN = new System.Windows.Forms.Button();
            this.lbMemberResults = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.findMemberSearchBox = new System.Windows.Forms.TextBox();
            this.loansTab = new System.Windows.Forms.TabPage();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.closeBTN = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.booksTab.SuspendLayout();
            this.membersTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.loansTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.booksTab);
            this.tabControl1.Controls.Add(this.membersTab);
            this.tabControl1.Controls.Add(this.loansTab);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(30, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 583);
            this.tabControl1.TabIndex = 2;
            // 
            // booksTab
            // 
            this.booksTab.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.booksTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.booksTab.Controls.Add(this.booksNewLoanBTN);
            this.booksTab.Controls.Add(this.lbCopies);
            this.booksTab.Controls.Add(this.label15);
            this.booksTab.Controls.Add(this.label13);
            this.booksTab.Controls.Add(this.removeCopyBTN);
            this.booksTab.Controls.Add(this.label9);
            this.booksTab.Controls.Add(this.editBookIDTB);
            this.booksTab.Controls.Add(this.saveChangesBTN);
            this.booksTab.Controls.Add(this.removeBookBTN);
            this.booksTab.Controls.Add(this.addCopyBTN);
            this.booksTab.Controls.Add(this.label7);
            this.booksTab.Controls.Add(this.label6);
            this.booksTab.Controls.Add(this.label5);
            this.booksTab.Controls.Add(this.label4);
            this.booksTab.Controls.Add(this.editDescriptionTB);
            this.booksTab.Controls.Add(this.editAuthorTB);
            this.booksTab.Controls.Add(this.editTitleTB);
            this.booksTab.Controls.Add(this.editISBNTB);
            this.booksTab.Controls.Add(this.addBookBTN);
            this.booksTab.Controls.Add(this.label3);
            this.booksTab.Controls.Add(this.label2);
            this.booksTab.Controls.Add(this.label1);
            this.booksTab.Controls.Add(this.findISBNTB);
            this.booksTab.Controls.Add(this.findAuthorTB);
            this.booksTab.Controls.Add(this.findTitleTB);
            this.booksTab.Controls.Add(this.findBooksLabel);
            this.booksTab.Controls.Add(this.lbBooks);
            this.booksTab.Controls.Add(this.BTNChangeBook);
            this.booksTab.Location = new System.Drawing.Point(4, 30);
            this.booksTab.Margin = new System.Windows.Forms.Padding(2);
            this.booksTab.Name = "booksTab";
            this.booksTab.Padding = new System.Windows.Forms.Padding(2);
            this.booksTab.Size = new System.Drawing.Size(942, 549);
            this.booksTab.TabIndex = 0;
            this.booksTab.Text = "Books";
            // 
            // booksNewLoanBTN
            // 
            this.booksNewLoanBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.booksNewLoanBTN.Location = new System.Drawing.Point(826, 19);
            this.booksNewLoanBTN.Margin = new System.Windows.Forms.Padding(2);
            this.booksNewLoanBTN.Name = "booksNewLoanBTN";
            this.booksNewLoanBTN.Size = new System.Drawing.Size(86, 37);
            this.booksNewLoanBTN.TabIndex = 37;
            this.booksNewLoanBTN.Text = "New loan";
            this.booksNewLoanBTN.UseVisualStyleBackColor = true;
            this.booksNewLoanBTN.Click += new System.EventHandler(this.booksNewLoanBTN_Click);
            // 
            // lbCopies
            // 
            this.lbCopies.BackColor = System.Drawing.SystemColors.Window;
            this.lbCopies.FormattingEnabled = true;
            this.lbCopies.ItemHeight = 21;
            this.lbCopies.Location = new System.Drawing.Point(697, 92);
            this.lbCopies.Name = "lbCopies";
            this.lbCopies.Size = new System.Drawing.Size(216, 256);
            this.lbCopies.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Georgia", 12F);
            this.label15.Location = new System.Drawing.Point(694, 69);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 18);
            this.label15.TabIndex = 35;
            this.label15.Text = "Copies";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Georgia", 12F);
            this.label13.Location = new System.Drawing.Point(193, 69);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 18);
            this.label13.TabIndex = 34;
            this.label13.Text = "Results";
            // 
            // removeCopyBTN
            // 
            this.removeCopyBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.removeCopyBTN.Location = new System.Drawing.Point(782, 364);
            this.removeCopyBTN.Margin = new System.Windows.Forms.Padding(2);
            this.removeCopyBTN.Name = "removeCopyBTN";
            this.removeCopyBTN.Size = new System.Drawing.Size(106, 37);
            this.removeCopyBTN.TabIndex = 33;
            this.removeCopyBTN.Text = "Remove copy";
            this.removeCopyBTN.UseVisualStyleBackColor = true;
            this.removeCopyBTN.Click += new System.EventHandler(this.removeCopyBTN_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 12F);
            this.label9.Location = new System.Drawing.Point(400, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 32;
            this.label9.Text = "Book ID";
            // 
            // editBookIDTB
            // 
            this.editBookIDTB.BackColor = System.Drawing.SystemColors.Info;
            this.editBookIDTB.Location = new System.Drawing.Point(404, 93);
            this.editBookIDTB.Margin = new System.Windows.Forms.Padding(2);
            this.editBookIDTB.Name = "editBookIDTB";
            this.editBookIDTB.ReadOnly = true;
            this.editBookIDTB.Size = new System.Drawing.Size(99, 28);
            this.editBookIDTB.TabIndex = 31;
            // 
            // saveChangesBTN
            // 
            this.saveChangesBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.saveChangesBTN.Location = new System.Drawing.Point(591, 454);
            this.saveChangesBTN.Margin = new System.Windows.Forms.Padding(2);
            this.saveChangesBTN.Name = "saveChangesBTN";
            this.saveChangesBTN.Size = new System.Drawing.Size(88, 37);
            this.saveChangesBTN.TabIndex = 30;
            this.saveChangesBTN.Text = "Save";
            this.saveChangesBTN.UseVisualStyleBackColor = true;
            this.saveChangesBTN.Click += new System.EventHandler(this.saveChangesBTN_Click);
            // 
            // removeBookBTN
            // 
            this.removeBookBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.removeBookBTN.Location = new System.Drawing.Point(126, 19);
            this.removeBookBTN.Margin = new System.Windows.Forms.Padding(2);
            this.removeBookBTN.Name = "removeBookBTN";
            this.removeBookBTN.Size = new System.Drawing.Size(96, 37);
            this.removeBookBTN.TabIndex = 29;
            this.removeBookBTN.Text = "Remove";
            this.removeBookBTN.UseVisualStyleBackColor = true;
            this.removeBookBTN.Click += new System.EventHandler(this.removeBookBTN_Click);
            // 
            // addCopyBTN
            // 
            this.addCopyBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.addCopyBTN.Location = new System.Drawing.Point(697, 364);
            this.addCopyBTN.Margin = new System.Windows.Forms.Padding(2);
            this.addCopyBTN.Name = "addCopyBTN";
            this.addCopyBTN.Size = new System.Drawing.Size(80, 37);
            this.addCopyBTN.TabIndex = 28;
            this.addCopyBTN.Text = "Add copy";
            this.addCopyBTN.UseVisualStyleBackColor = true;
            this.addCopyBTN.Click += new System.EventHandler(this.addCopyBTN_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 12F);
            this.label7.Location = new System.Drawing.Point(400, 227);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 27;
            this.label7.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 12F);
            this.label6.Location = new System.Drawing.Point(503, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "ISBN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 12F);
            this.label5.Location = new System.Drawing.Point(400, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Author";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 12F);
            this.label4.Location = new System.Drawing.Point(400, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Title";
            // 
            // editDescriptionTB
            // 
            this.editDescriptionTB.BackColor = System.Drawing.SystemColors.Info;
            this.editDescriptionTB.Location = new System.Drawing.Point(404, 249);
            this.editDescriptionTB.Margin = new System.Windows.Forms.Padding(2);
            this.editDescriptionTB.Name = "editDescriptionTB";
            this.editDescriptionTB.Size = new System.Drawing.Size(277, 195);
            this.editDescriptionTB.TabIndex = 23;
            this.editDescriptionTB.Text = "";
            // 
            // editAuthorTB
            // 
            this.editAuthorTB.BackColor = System.Drawing.SystemColors.Info;
            this.editAuthorTB.Location = new System.Drawing.Point(404, 197);
            this.editAuthorTB.Margin = new System.Windows.Forms.Padding(2);
            this.editAuthorTB.Name = "editAuthorTB";
            this.editAuthorTB.Size = new System.Drawing.Size(277, 28);
            this.editAuthorTB.TabIndex = 21;
            // 
            // editTitleTB
            // 
            this.editTitleTB.BackColor = System.Drawing.SystemColors.Info;
            this.editTitleTB.Location = new System.Drawing.Point(404, 145);
            this.editTitleTB.Margin = new System.Windows.Forms.Padding(2);
            this.editTitleTB.Name = "editTitleTB";
            this.editTitleTB.Size = new System.Drawing.Size(277, 28);
            this.editTitleTB.TabIndex = 20;
            // 
            // editISBNTB
            // 
            this.editISBNTB.BackColor = System.Drawing.SystemColors.Info;
            this.editISBNTB.Location = new System.Drawing.Point(506, 93);
            this.editISBNTB.Margin = new System.Windows.Forms.Padding(2);
            this.editISBNTB.Name = "editISBNTB";
            this.editISBNTB.Size = new System.Drawing.Size(174, 28);
            this.editISBNTB.TabIndex = 19;
            // 
            // addBookBTN
            // 
            this.addBookBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.addBookBTN.Location = new System.Drawing.Point(18, 19);
            this.addBookBTN.Margin = new System.Windows.Forms.Padding(2);
            this.addBookBTN.Name = "addBookBTN";
            this.addBookBTN.Size = new System.Drawing.Size(96, 37);
            this.addBookBTN.TabIndex = 11;
            this.addBookBTN.Text = "Add";
            this.addBookBTN.UseVisualStyleBackColor = true;
            this.addBookBTN.Click += new System.EventHandler(this.addBookBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 12F);
            this.label3.Location = new System.Drawing.Point(19, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "By title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 12F);
            this.label2.Location = new System.Drawing.Point(19, 200);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "By ISBN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F);
            this.label1.Location = new System.Drawing.Point(19, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "By author";
            // 
            // findISBNTB
            // 
            this.findISBNTB.Location = new System.Drawing.Point(22, 222);
            this.findISBNTB.Margin = new System.Windows.Forms.Padding(2);
            this.findISBNTB.Name = "findISBNTB";
            this.findISBNTB.Size = new System.Drawing.Size(161, 28);
            this.findISBNTB.TabIndex = 15;
            this.findISBNTB.TextChanged += new System.EventHandler(this.findISBNTB_TextChanged);
            // 
            // findAuthorTB
            // 
            this.findAuthorTB.Location = new System.Drawing.Point(22, 170);
            this.findAuthorTB.Margin = new System.Windows.Forms.Padding(2);
            this.findAuthorTB.Name = "findAuthorTB";
            this.findAuthorTB.Size = new System.Drawing.Size(161, 28);
            this.findAuthorTB.TabIndex = 14;
            this.findAuthorTB.TextChanged += new System.EventHandler(this.findAuthorTB_TextChanged);
            // 
            // findTitleTB
            // 
            this.findTitleTB.Location = new System.Drawing.Point(22, 118);
            this.findTitleTB.Margin = new System.Windows.Forms.Padding(2);
            this.findTitleTB.Name = "findTitleTB";
            this.findTitleTB.Size = new System.Drawing.Size(161, 28);
            this.findTitleTB.TabIndex = 13;
            this.findTitleTB.TextChanged += new System.EventHandler(this.findTitleTB_TextChanged);
            // 
            // findBooksLabel
            // 
            this.findBooksLabel.AutoSize = true;
            this.findBooksLabel.Location = new System.Drawing.Point(18, 70);
            this.findBooksLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findBooksLabel.Name = "findBooksLabel";
            this.findBooksLabel.Size = new System.Drawing.Size(101, 23);
            this.findBooksLabel.TabIndex = 12;
            this.findBooksLabel.Text = "Find book:";
            // 
            // lbBooks
            // 
            this.lbBooks.BackColor = System.Drawing.SystemColors.Window;
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.ItemHeight = 21;
            this.lbBooks.Location = new System.Drawing.Point(196, 92);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(196, 382);
            this.lbBooks.TabIndex = 0;
            this.lbBooks.SelectedIndexChanged += new System.EventHandler(this.lbBooks_SelectedIndexChanged);
            // 
            // BTNChangeBook
            // 
            this.BTNChangeBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNChangeBook.Location = new System.Drawing.Point(33, 378);
            this.BTNChangeBook.Margin = new System.Windows.Forms.Padding(2);
            this.BTNChangeBook.Name = "BTNChangeBook";
            this.BTNChangeBook.Size = new System.Drawing.Size(81, 35);
            this.BTNChangeBook.TabIndex = 1;
            this.BTNChangeBook.Text = "TEST: Change the book title";
            this.BTNChangeBook.UseVisualStyleBackColor = true;
            this.BTNChangeBook.Click += new System.EventHandler(this.BTNChangeBook_Click);
            // 
            // membersTab
            // 
            this.membersTab.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.membersTab.Controls.Add(this.label16);
            this.membersTab.Controls.Add(this.checkBox1);
            this.membersTab.Controls.Add(this.label24);
            this.membersTab.Controls.Add(this.groupBox1);
            this.membersTab.Controls.Add(this.label18);
            this.membersTab.Controls.Add(this.lbMemberLoans);
            this.membersTab.Controls.Add(this.memberNameBox);
            this.membersTab.Controls.Add(this.memberPersonnummerBox);
            this.membersTab.Controls.Add(this.memberIdBox);
            this.membersTab.Controls.Add(this.label14);
            this.membersTab.Controls.Add(this.label12);
            this.membersTab.Controls.Add(this.label11);
            this.membersTab.Controls.Add(this.label10);
            this.membersTab.Controls.Add(this.button4);
            this.membersTab.Controls.Add(this.removeMemberBTN);
            this.membersTab.Controls.Add(this.memberLoanBTN);
            this.membersTab.Controls.Add(this.newMemberBTN);
            this.membersTab.Controls.Add(this.lbMemberResults);
            this.membersTab.Controls.Add(this.label8);
            this.membersTab.Controls.Add(this.findMemberSearchBox);
            this.membersTab.Location = new System.Drawing.Point(4, 30);
            this.membersTab.Margin = new System.Windows.Forms.Padding(2);
            this.membersTab.Name = "membersTab";
            this.membersTab.Padding = new System.Windows.Forms.Padding(2);
            this.membersTab.Size = new System.Drawing.Size(942, 549);
            this.membersTab.TabIndex = 1;
            this.membersTab.Text = "Members";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Georgia", 12F);
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.Location = new System.Drawing.Point(520, 441);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 18);
            this.label16.TabIndex = 47;
            this.label16.Text = "*Previous loans";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(524, 392);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(201, 27);
            this.checkBox1.TabIndex = 46;
            this.checkBox1.Text = "Show previous loans";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Georgia", 12F);
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(520, 422);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 18);
            this.label24.TabIndex = 45;
            this.label24.Text = "*Overdue loan";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Location = new System.Drawing.Point(721, 99);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(203, 288);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Georgia", 12F);
            this.label23.Location = new System.Drawing.Point(10, 216);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 18);
            this.label23.TabIndex = 48;
            this.label23.Text = "Fees due";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Georgia", 12F);
            this.label22.Location = new System.Drawing.Point(20, 216);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 18);
            this.label22.TabIndex = 47;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Georgia", 12F);
            this.label21.Location = new System.Drawing.Point(10, 164);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 18);
            this.label21.TabIndex = 46;
            this.label21.Text = "Due date";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Georgia", 12F);
            this.label20.Location = new System.Drawing.Point(10, 112);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 18);
            this.label20.TabIndex = 45;
            this.label20.Text = "Time of return";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Georgia", 12F);
            this.label19.Location = new System.Drawing.Point(10, 60);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 18);
            this.label19.TabIndex = 44;
            this.label19.Text = "Time of loan";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(13, 238);
            this.textBox10.Margin = new System.Windows.Forms.Padding(2);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(177, 28);
            this.textBox10.TabIndex = 43;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(13, 26);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(177, 28);
            this.textBox5.TabIndex = 38;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(13, 82);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(177, 28);
            this.textBox6.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Georgia", 12F);
            this.label17.Location = new System.Drawing.Point(10, 8);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 18);
            this.label17.TabIndex = 42;
            this.label17.Text = "Loan ID";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(13, 134);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(177, 28);
            this.textBox8.TabIndex = 40;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(13, 186);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(177, 28);
            this.textBox9.TabIndex = 41;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Georgia", 12F);
            this.label18.Location = new System.Drawing.Point(520, 77);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(148, 18);
            this.label18.TabIndex = 43;
            this.label18.Text = "Current loans (title)";
            // 
            // lbMemberLoans
            // 
            this.lbMemberLoans.FormattingEnabled = true;
            this.lbMemberLoans.ItemHeight = 21;
            this.lbMemberLoans.Location = new System.Drawing.Point(524, 99);
            this.lbMemberLoans.Margin = new System.Windows.Forms.Padding(2);
            this.lbMemberLoans.Name = "lbMemberLoans";
            this.lbMemberLoans.Size = new System.Drawing.Size(185, 277);
            this.lbMemberLoans.TabIndex = 37;
            // 
            // memberNameBox
            // 
            this.memberNameBox.BackColor = System.Drawing.SystemColors.Info;
            this.memberNameBox.Location = new System.Drawing.Point(247, 151);
            this.memberNameBox.Margin = new System.Windows.Forms.Padding(2);
            this.memberNameBox.Name = "memberNameBox";
            this.memberNameBox.Size = new System.Drawing.Size(264, 28);
            this.memberNameBox.TabIndex = 34;
            // 
            // memberPersonnummerBox
            // 
            this.memberPersonnummerBox.BackColor = System.Drawing.SystemColors.Info;
            this.memberPersonnummerBox.Location = new System.Drawing.Point(350, 99);
            this.memberPersonnummerBox.Margin = new System.Windows.Forms.Padding(2);
            this.memberPersonnummerBox.Name = "memberPersonnummerBox";
            this.memberPersonnummerBox.Size = new System.Drawing.Size(162, 28);
            this.memberPersonnummerBox.TabIndex = 33;
            // 
            // memberIdBox
            // 
            this.memberIdBox.BackColor = System.Drawing.SystemColors.Info;
            this.memberIdBox.Location = new System.Drawing.Point(247, 99);
            this.memberIdBox.Margin = new System.Windows.Forms.Padding(2);
            this.memberIdBox.Name = "memberIdBox";
            this.memberIdBox.Size = new System.Drawing.Size(99, 28);
            this.memberIdBox.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Georgia", 12F);
            this.label14.Location = new System.Drawing.Point(244, 129);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 18);
            this.label14.TabIndex = 30;
            this.label14.Text = "Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 12F);
            this.label12.Location = new System.Drawing.Point(33, 129);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 18);
            this.label12.TabIndex = 29;
            this.label12.Text = "Results";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 12F);
            this.label11.Location = new System.Drawing.Point(244, 77);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 18);
            this.label11.TabIndex = 28;
            this.label11.Text = "ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 12F);
            this.label10.Location = new System.Drawing.Point(346, 77);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "Personnummer";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Georgia", 12F);
            this.button4.Location = new System.Drawing.Point(414, 184);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 37);
            this.button4.TabIndex = 24;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // removeMemberBTN
            // 
            this.removeMemberBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.removeMemberBTN.Location = new System.Drawing.Point(136, 22);
            this.removeMemberBTN.Margin = new System.Windows.Forms.Padding(2);
            this.removeMemberBTN.Name = "removeMemberBTN";
            this.removeMemberBTN.Size = new System.Drawing.Size(96, 37);
            this.removeMemberBTN.TabIndex = 23;
            this.removeMemberBTN.Text = "Remove";
            this.removeMemberBTN.UseVisualStyleBackColor = true;
            // 
            // memberLoanBTN
            // 
            this.memberLoanBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.memberLoanBTN.Location = new System.Drawing.Point(814, 22);
            this.memberLoanBTN.Margin = new System.Windows.Forms.Padding(2);
            this.memberLoanBTN.Name = "memberLoanBTN";
            this.memberLoanBTN.Size = new System.Drawing.Size(96, 37);
            this.memberLoanBTN.TabIndex = 22;
            this.memberLoanBTN.Text = "New loan";
            this.memberLoanBTN.UseVisualStyleBackColor = true;
            // 
            // newMemberBTN
            // 
            this.newMemberBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.newMemberBTN.Location = new System.Drawing.Point(35, 22);
            this.newMemberBTN.Margin = new System.Windows.Forms.Padding(2);
            this.newMemberBTN.Name = "newMemberBTN";
            this.newMemberBTN.Size = new System.Drawing.Size(96, 37);
            this.newMemberBTN.TabIndex = 21;
            this.newMemberBTN.Text = "New";
            this.newMemberBTN.UseVisualStyleBackColor = true;
            // 
            // lbMemberResults
            // 
            this.lbMemberResults.FormattingEnabled = true;
            this.lbMemberResults.ItemHeight = 21;
            this.lbMemberResults.Location = new System.Drawing.Point(36, 151);
            this.lbMemberResults.Margin = new System.Windows.Forms.Padding(2);
            this.lbMemberResults.Name = "lbMemberResults";
            this.lbMemberResults.Size = new System.Drawing.Size(198, 277);
            this.lbMemberResults.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 12F);
            this.label8.Location = new System.Drawing.Point(33, 77);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Find member";
            // 
            // findMemberSearchBox
            // 
            this.findMemberSearchBox.Location = new System.Drawing.Point(36, 99);
            this.findMemberSearchBox.Margin = new System.Windows.Forms.Padding(2);
            this.findMemberSearchBox.Name = "findMemberSearchBox";
            this.findMemberSearchBox.Size = new System.Drawing.Size(198, 28);
            this.findMemberSearchBox.TabIndex = 14;
            // 
            // loansTab
            // 
            this.loansTab.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.loansTab.Controls.Add(this.radioButton3);
            this.loansTab.Controls.Add(this.label25);
            this.loansTab.Controls.Add(this.radioButton2);
            this.loansTab.Controls.Add(this.radioButton1);
            this.loansTab.Controls.Add(this.textBox1);
            this.loansTab.Location = new System.Drawing.Point(4, 30);
            this.loansTab.Margin = new System.Windows.Forms.Padding(2);
            this.loansTab.Name = "loansTab";
            this.loansTab.Size = new System.Drawing.Size(942, 549);
            this.loansTab.TabIndex = 2;
            this.loansTab.Text = "Loans";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(37, 211);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(148, 27);
            this.radioButton3.TabIndex = 31;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Overdue loans";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Georgia", 12F);
            this.label25.Location = new System.Drawing.Point(34, 79);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(178, 18);
            this.label25.TabIndex = 30;
            this.label25.Text = "Find specific loan (book)";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(37, 180);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(150, 27);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Previous loans";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(37, 148);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(143, 27);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Current loans";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 101);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 28);
            this.textBox1.TabIndex = 0;
            // 
            // closeBTN
            // 
            this.closeBTN.BackColor = System.Drawing.Color.Red;
            this.closeBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeBTN.Location = new System.Drawing.Point(970, 1);
            this.closeBTN.Margin = new System.Windows.Forms.Padding(2);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(33, 26);
            this.closeBTN.TabIndex = 3;
            this.closeBTN.Text = "X";
            this.closeBTN.UseVisualStyleBackColor = false;
            this.closeBTN.Click += new System.EventHandler(this.closeBTN_Click);
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1003, 633);
            this.Controls.Add(this.closeBTN);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LibraryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library";
            this.tabControl1.ResumeLayout(false);
            this.booksTab.ResumeLayout(false);
            this.booksTab.PerformLayout();
            this.membersTab.ResumeLayout(false);
            this.membersTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.loansTab.ResumeLayout(false);
            this.loansTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbBooks;
        private System.Windows.Forms.Button BTNChangeBook;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage booksTab;
        private System.Windows.Forms.TabPage membersTab;
        private System.Windows.Forms.TabPage loansTab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox editDescriptionTB;
        private System.Windows.Forms.TextBox editAuthorTB;
        private System.Windows.Forms.TextBox editTitleTB;
        private System.Windows.Forms.TextBox editISBNTB;
        private System.Windows.Forms.Button addBookBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox findISBNTB;
        private System.Windows.Forms.TextBox findAuthorTB;
        private System.Windows.Forms.TextBox findTitleTB;
        private System.Windows.Forms.Label findBooksLabel;
        private System.Windows.Forms.Button saveChangesBTN;
        private System.Windows.Forms.Button removeBookBTN;
        private System.Windows.Forms.Button addCopyBTN;
        private System.Windows.Forms.TextBox findMemberSearchBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button removeCopyBTN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox editBookIDTB;
        private System.Windows.Forms.ListBox lbCopies;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button removeMemberBTN;
        private System.Windows.Forms.Button memberLoanBTN;
        private System.Windows.Forms.Button newMemberBTN;
        private System.Windows.Forms.ListBox lbMemberResults;
        private System.Windows.Forms.TextBox memberPersonnummerBox;
        private System.Windows.Forms.TextBox memberIdBox;
        private System.Windows.Forms.TextBox memberNameBox;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.Button booksNewLoanBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox lbMemberLoans;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

