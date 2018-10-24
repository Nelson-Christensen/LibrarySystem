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
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.loansTab = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.editBookIDTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.removeCopyBTN = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.newMemberBTN = new System.Windows.Forms.Button();
            this.memberLoanBTN = new System.Windows.Forms.Button();
            this.removeMemberBTN = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbCopies = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.closeBTN = new System.Windows.Forms.Button();
            this.lbMemberLoans = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.booksNewLoanBTN = new System.Windows.Forms.Button();
            this.lbMemberCurrentLoans = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.booksTab.SuspendLayout();
            this.membersTab.SuspendLayout();
            this.loansTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.booksTab);
            this.tabControl1.Controls.Add(this.membersTab);
            this.tabControl1.Controls.Add(this.loansTab);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(40, 29);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1267, 718);
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
            this.booksTab.Location = new System.Drawing.Point(4, 36);
            this.booksTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.booksTab.Name = "booksTab";
            this.booksTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.booksTab.Size = new System.Drawing.Size(1259, 678);
            this.booksTab.TabIndex = 0;
            this.booksTab.Text = "Books";
            // 
            // saveChangesBTN
            // 
            this.saveChangesBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.saveChangesBTN.Location = new System.Drawing.Point(788, 559);
            this.saveChangesBTN.Name = "saveChangesBTN";
            this.saveChangesBTN.Size = new System.Drawing.Size(118, 45);
            this.saveChangesBTN.TabIndex = 30;
            this.saveChangesBTN.Text = "Save";
            this.saveChangesBTN.UseVisualStyleBackColor = true;
            // 
            // removeBookBTN
            // 
            this.removeBookBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.removeBookBTN.Location = new System.Drawing.Point(168, 23);
            this.removeBookBTN.Name = "removeBookBTN";
            this.removeBookBTN.Size = new System.Drawing.Size(128, 45);
            this.removeBookBTN.TabIndex = 29;
            this.removeBookBTN.Text = "Remove";
            this.removeBookBTN.UseVisualStyleBackColor = true;
            // 
            // addCopyBTN
            // 
            this.addCopyBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.addCopyBTN.Location = new System.Drawing.Point(929, 448);
            this.addCopyBTN.Name = "addCopyBTN";
            this.addCopyBTN.Size = new System.Drawing.Size(107, 45);
            this.addCopyBTN.TabIndex = 28;
            this.addCopyBTN.Text = "Add copy";
            this.addCopyBTN.UseVisualStyleBackColor = true;
            this.addCopyBTN.Click += new System.EventHandler(this.addCopyBTN_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 12F);
            this.label7.Location = new System.Drawing.Point(534, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 24);
            this.label7.TabIndex = 27;
            this.label7.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 12F);
            this.label6.Location = new System.Drawing.Point(671, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 24);
            this.label6.TabIndex = 26;
            this.label6.Text = "ISBN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 12F);
            this.label5.Location = new System.Drawing.Point(534, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 24);
            this.label5.TabIndex = 25;
            this.label5.Text = "Author";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 12F);
            this.label4.Location = new System.Drawing.Point(534, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "Title";
            // 
            // editDescriptionTB
            // 
            this.editDescriptionTB.BackColor = System.Drawing.SystemColors.Info;
            this.editDescriptionTB.Location = new System.Drawing.Point(538, 306);
            this.editDescriptionTB.Name = "editDescriptionTB";
            this.editDescriptionTB.Size = new System.Drawing.Size(368, 239);
            this.editDescriptionTB.TabIndex = 23;
            this.editDescriptionTB.Text = "";
            // 
            // editAuthorTB
            // 
            this.editAuthorTB.BackColor = System.Drawing.SystemColors.Info;
            this.editAuthorTB.Location = new System.Drawing.Point(538, 242);
            this.editAuthorTB.Name = "editAuthorTB";
            this.editAuthorTB.Size = new System.Drawing.Size(368, 34);
            this.editAuthorTB.TabIndex = 21;
            // 
            // editTitleTB
            // 
            this.editTitleTB.BackColor = System.Drawing.SystemColors.Info;
            this.editTitleTB.Location = new System.Drawing.Point(538, 178);
            this.editTitleTB.Name = "editTitleTB";
            this.editTitleTB.Size = new System.Drawing.Size(368, 34);
            this.editTitleTB.TabIndex = 20;
            // 
            // editISBNTB
            // 
            this.editISBNTB.BackColor = System.Drawing.SystemColors.Info;
            this.editISBNTB.Location = new System.Drawing.Point(675, 114);
            this.editISBNTB.Name = "editISBNTB";
            this.editISBNTB.Size = new System.Drawing.Size(231, 34);
            this.editISBNTB.TabIndex = 19;
            // 
            // addBookBTN
            // 
            this.addBookBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.addBookBTN.Location = new System.Drawing.Point(34, 23);
            this.addBookBTN.Name = "addBookBTN";
            this.addBookBTN.Size = new System.Drawing.Size(128, 45);
            this.addBookBTN.TabIndex = 11;
            this.addBookBTN.Text = "Add";
            this.addBookBTN.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 12F);
            this.label3.Location = new System.Drawing.Point(25, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "By title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 12F);
            this.label2.Location = new System.Drawing.Point(25, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "By ISBN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F);
            this.label1.Location = new System.Drawing.Point(25, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "By author";
            // 
            // findISBNTB
            // 
            this.findISBNTB.Location = new System.Drawing.Point(29, 273);
            this.findISBNTB.Name = "findISBNTB";
            this.findISBNTB.Size = new System.Drawing.Size(213, 34);
            this.findISBNTB.TabIndex = 15;
            // 
            // findAuthorTB
            // 
            this.findAuthorTB.Location = new System.Drawing.Point(29, 209);
            this.findAuthorTB.Name = "findAuthorTB";
            this.findAuthorTB.Size = new System.Drawing.Size(213, 34);
            this.findAuthorTB.TabIndex = 14;
            // 
            // findTitleTB
            // 
            this.findTitleTB.Location = new System.Drawing.Point(29, 145);
            this.findTitleTB.Name = "findTitleTB";
            this.findTitleTB.Size = new System.Drawing.Size(213, 34);
            this.findTitleTB.TabIndex = 13;
            // 
            // findBooksLabel
            // 
            this.findBooksLabel.AutoSize = true;
            this.findBooksLabel.Location = new System.Drawing.Point(24, 86);
            this.findBooksLabel.Name = "findBooksLabel";
            this.findBooksLabel.Size = new System.Drawing.Size(128, 29);
            this.findBooksLabel.TabIndex = 12;
            this.findBooksLabel.Text = "Find book:";
            // 
            // lbBooks
            // 
            this.lbBooks.BackColor = System.Drawing.SystemColors.Window;
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.ItemHeight = 27;
            this.lbBooks.Location = new System.Drawing.Point(261, 113);
            this.lbBooks.Margin = new System.Windows.Forms.Padding(4);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(260, 490);
            this.lbBooks.TabIndex = 0;
            // 
            // BTNChangeBook
            // 
            this.BTNChangeBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNChangeBook.Location = new System.Drawing.Point(44, 465);
            this.BTNChangeBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTNChangeBook.Name = "BTNChangeBook";
            this.BTNChangeBook.Size = new System.Drawing.Size(108, 43);
            this.BTNChangeBook.TabIndex = 1;
            this.BTNChangeBook.Text = "TEST: Change the book title";
            this.BTNChangeBook.UseVisualStyleBackColor = true;
            this.BTNChangeBook.Click += new System.EventHandler(this.BTNChangeBook_Click);
            // 
            // membersTab
            // 
            this.membersTab.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.membersTab.Controls.Add(this.groupBox1);
            this.membersTab.Controls.Add(this.label18);
            this.membersTab.Controls.Add(this.lbMemberCurrentLoans);
            this.membersTab.Controls.Add(this.label16);
            this.membersTab.Controls.Add(this.lbMemberLoans);
            this.membersTab.Controls.Add(this.textBox4);
            this.membersTab.Controls.Add(this.textBox3);
            this.membersTab.Controls.Add(this.textBox2);
            this.membersTab.Controls.Add(this.label14);
            this.membersTab.Controls.Add(this.label12);
            this.membersTab.Controls.Add(this.label11);
            this.membersTab.Controls.Add(this.label10);
            this.membersTab.Controls.Add(this.button4);
            this.membersTab.Controls.Add(this.removeMemberBTN);
            this.membersTab.Controls.Add(this.memberLoanBTN);
            this.membersTab.Controls.Add(this.newMemberBTN);
            this.membersTab.Controls.Add(this.listBox1);
            this.membersTab.Controls.Add(this.label8);
            this.membersTab.Controls.Add(this.textBox7);
            this.membersTab.Location = new System.Drawing.Point(4, 36);
            this.membersTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.membersTab.Name = "membersTab";
            this.membersTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.membersTab.Size = new System.Drawing.Size(1259, 678);
            this.membersTab.TabIndex = 1;
            this.membersTab.Text = "Members";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(48, 54);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(262, 34);
            this.textBox7.TabIndex = 14;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // loansTab
            // 
            this.loansTab.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.loansTab.Controls.Add(this.textBox1);
            this.loansTab.Location = new System.Drawing.Point(4, 36);
            this.loansTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loansTab.Name = "loansTab";
            this.loansTab.Size = new System.Drawing.Size(1259, 678);
            this.loansTab.TabIndex = 2;
            this.loansTab.Text = "Loans";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 12F);
            this.label8.Location = new System.Drawing.Point(44, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 24);
            this.label8.TabIndex = 19;
            this.label8.Text = "Find member";
            // 
            // editBookIDTB
            // 
            this.editBookIDTB.BackColor = System.Drawing.SystemColors.Info;
            this.editBookIDTB.Location = new System.Drawing.Point(538, 114);
            this.editBookIDTB.Name = "editBookIDTB";
            this.editBookIDTB.Size = new System.Drawing.Size(131, 34);
            this.editBookIDTB.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 12F);
            this.label9.Location = new System.Drawing.Point(534, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 24);
            this.label9.TabIndex = 32;
            this.label9.Text = "Book ID";
            // 
            // removeCopyBTN
            // 
            this.removeCopyBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.removeCopyBTN.Location = new System.Drawing.Point(1042, 448);
            this.removeCopyBTN.Name = "removeCopyBTN";
            this.removeCopyBTN.Size = new System.Drawing.Size(142, 45);
            this.removeCopyBTN.TabIndex = 33;
            this.removeCopyBTN.Text = "Remove copy";
            this.removeCopyBTN.UseVisualStyleBackColor = true;
            this.removeCopyBTN.Click += new System.EventHandler(this.removeCopyBTN_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 27;
            this.listBox1.Location = new System.Drawing.Point(48, 118);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(262, 409);
            this.listBox1.TabIndex = 20;
            // 
            // newMemberBTN
            // 
            this.newMemberBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.newMemberBTN.Location = new System.Drawing.Point(48, 564);
            this.newMemberBTN.Name = "newMemberBTN";
            this.newMemberBTN.Size = new System.Drawing.Size(128, 45);
            this.newMemberBTN.TabIndex = 21;
            this.newMemberBTN.Text = "New";
            this.newMemberBTN.UseVisualStyleBackColor = true;
            // 
            // memberLoanBTN
            // 
            this.memberLoanBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.memberLoanBTN.Location = new System.Drawing.Point(1085, 27);
            this.memberLoanBTN.Name = "memberLoanBTN";
            this.memberLoanBTN.Size = new System.Drawing.Size(128, 45);
            this.memberLoanBTN.TabIndex = 22;
            this.memberLoanBTN.Text = "New loan";
            this.memberLoanBTN.UseVisualStyleBackColor = true;
            // 
            // removeMemberBTN
            // 
            this.removeMemberBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.removeMemberBTN.Location = new System.Drawing.Point(182, 564);
            this.removeMemberBTN.Name = "removeMemberBTN";
            this.removeMemberBTN.Size = new System.Drawing.Size(128, 45);
            this.removeMemberBTN.TabIndex = 23;
            this.removeMemberBTN.Text = "Remove";
            this.removeMemberBTN.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Georgia", 12F);
            this.button4.Location = new System.Drawing.Point(552, 226);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 45);
            this.button4.TabIndex = 24;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 12F);
            this.label10.Location = new System.Drawing.Point(462, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 24);
            this.label10.TabIndex = 27;
            this.label10.Text = "Personnummer";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 12F);
            this.label11.Location = new System.Drawing.Point(325, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 24);
            this.label11.TabIndex = 28;
            this.label11.Text = "ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 12F);
            this.label12.Location = new System.Drawing.Point(44, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 24);
            this.label12.TabIndex = 29;
            this.label12.Text = "Results";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Georgia", 12F);
            this.label13.Location = new System.Drawing.Point(257, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 24);
            this.label13.TabIndex = 34;
            this.label13.Text = "Results";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Georgia", 12F);
            this.label14.Location = new System.Drawing.Point(325, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 24);
            this.label14.TabIndex = 30;
            this.label14.Text = "Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Georgia", 12F);
            this.label15.Location = new System.Drawing.Point(925, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 24);
            this.label15.TabIndex = 35;
            this.label15.Text = "Copies";
            // 
            // lbCopies
            // 
            this.lbCopies.BackColor = System.Drawing.SystemColors.Window;
            this.lbCopies.FormattingEnabled = true;
            this.lbCopies.ItemHeight = 27;
            this.lbCopies.Location = new System.Drawing.Point(929, 113);
            this.lbCopies.Margin = new System.Windows.Forms.Padding(4);
            this.lbCopies.Name = "lbCopies";
            this.lbCopies.Size = new System.Drawing.Size(287, 328);
            this.lbCopies.TabIndex = 36;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Info;
            this.textBox2.Location = new System.Drawing.Point(329, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(131, 34);
            this.textBox2.TabIndex = 32;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Info;
            this.textBox3.Location = new System.Drawing.Point(466, 122);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(214, 34);
            this.textBox3.TabIndex = 33;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Info;
            this.textBox4.Location = new System.Drawing.Point(329, 186);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(351, 34);
            this.textBox4.TabIndex = 34;
            // 
            // closeBTN
            // 
            this.closeBTN.BackColor = System.Drawing.Color.Red;
            this.closeBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeBTN.Location = new System.Drawing.Point(1293, 1);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(44, 32);
            this.closeBTN.TabIndex = 3;
            this.closeBTN.Text = "X";
            this.closeBTN.UseVisualStyleBackColor = false;
            // 
            // lbMemberLoans
            // 
            this.lbMemberLoans.FormattingEnabled = true;
            this.lbMemberLoans.ItemHeight = 27;
            this.lbMemberLoans.Location = new System.Drawing.Point(329, 280);
            this.lbMemberLoans.Name = "lbMemberLoans";
            this.lbMemberLoans.Size = new System.Drawing.Size(351, 247);
            this.lbMemberLoans.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Georgia", 12F);
            this.label16.Location = new System.Drawing.Point(325, 253);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(198, 24);
            this.label16.TabIndex = 36;
            this.label16.Text = "Previous loans (title)";
            // 
            // booksNewLoanBTN
            // 
            this.booksNewLoanBTN.Font = new System.Drawing.Font("Georgia", 12F);
            this.booksNewLoanBTN.Location = new System.Drawing.Point(1102, 23);
            this.booksNewLoanBTN.Name = "booksNewLoanBTN";
            this.booksNewLoanBTN.Size = new System.Drawing.Size(114, 45);
            this.booksNewLoanBTN.TabIndex = 37;
            this.booksNewLoanBTN.Text = "New loan";
            this.booksNewLoanBTN.UseVisualStyleBackColor = true;
            // 
            // lbMemberCurrentLoans
            // 
            this.lbMemberCurrentLoans.FormattingEnabled = true;
            this.lbMemberCurrentLoans.ItemHeight = 27;
            this.lbMemberCurrentLoans.Location = new System.Drawing.Point(698, 122);
            this.lbMemberCurrentLoans.Name = "lbMemberCurrentLoans";
            this.lbMemberCurrentLoans.Size = new System.Drawing.Size(245, 409);
            this.lbMemberCurrentLoans.TabIndex = 37;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 34);
            this.textBox1.TabIndex = 0;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(31, 33);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(221, 34);
            this.textBox5.TabIndex = 38;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(31, 94);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(221, 34);
            this.textBox6.TabIndex = 39;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(31, 188);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(221, 34);
            this.textBox8.TabIndex = 40;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(31, 249);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(221, 34);
            this.textBox9.TabIndex = 41;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Georgia", 12F);
            this.label17.Location = new System.Drawing.Point(27, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 24);
            this.label17.TabIndex = 42;
            this.label17.Text = "ID";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Georgia", 12F);
            this.label18.Location = new System.Drawing.Point(694, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(190, 24);
            this.label18.TabIndex = 43;
            this.label18.Text = "Current loans (title)";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Location = new System.Drawing.Point(961, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 409);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(31, 315);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(221, 34);
            this.textBox10.TabIndex = 43;
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1337, 779);
            this.Controls.Add(this.closeBTN);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LibraryForm";
            this.Text = "Library";
            this.Load += new System.EventHandler(this.LibraryForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.booksTab.ResumeLayout(false);
            this.booksTab.PerformLayout();
            this.membersTab.ResumeLayout(false);
            this.membersTab.PerformLayout();
            this.loansTab.ResumeLayout(false);
            this.loansTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox7;
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
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.ListBox lbMemberLoans;
        private System.Windows.Forms.Button booksNewLoanBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox lbMemberCurrentLoans;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox1;
    }
}

