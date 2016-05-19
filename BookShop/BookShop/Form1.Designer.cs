namespace BookShop
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcl_Home = new System.Windows.Forms.TabControl();
            this.tpe_Home = new System.Windows.Forms.TabPage();
            this.tpe_function = new System.Windows.Forms.TabPage();
            this.tpe_Book = new System.Windows.Forms.TabPage();
            this.tpe_Author = new System.Windows.Forms.TabPage();
            this.tpe_Publisher = new System.Windows.Forms.TabPage();
            this.tpe_Promotion = new System.Windows.Forms.TabPage();
            this.tpe_Login = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpe_sale = new System.Windows.Forms.TabPage();
            this.tpe_buy = new System.Windows.Forms.TabPage();
            this.tpe_Account = new System.Windows.Forms.TabPage();
            this.tpe_report = new System.Windows.Forms.TabPage();
            this.tpe_Statistical = new System.Windows.Forms.TabPage();
            this.tcl_Home.SuspendLayout();
            this.tpe_function.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcl_Home
            // 
            this.tcl_Home.Controls.Add(this.tpe_Home);
            this.tcl_Home.Controls.Add(this.tpe_function);
            this.tcl_Home.Controls.Add(this.tpe_Book);
            this.tcl_Home.Controls.Add(this.tpe_Author);
            this.tcl_Home.Controls.Add(this.tpe_Publisher);
            this.tcl_Home.Controls.Add(this.tpe_Promotion);
            this.tcl_Home.Controls.Add(this.tpe_Login);
            this.tcl_Home.ItemSize = new System.Drawing.Size(80, 25);
            this.tcl_Home.Location = new System.Drawing.Point(8, 12);
            this.tcl_Home.Name = "tcl_Home";
            this.tcl_Home.SelectedIndex = 0;
            this.tcl_Home.Size = new System.Drawing.Size(939, 388);
            this.tcl_Home.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcl_Home.TabIndex = 0;
            // 
            // tpe_Home
            // 
            this.tpe_Home.Location = new System.Drawing.Point(4, 29);
            this.tpe_Home.Name = "tpe_Home";
            this.tpe_Home.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_Home.Size = new System.Drawing.Size(931, 355);
            this.tpe_Home.TabIndex = 0;
            this.tpe_Home.Text = "Home";
            this.tpe_Home.UseVisualStyleBackColor = true;
            // 
            // tpe_function
            // 
            this.tpe_function.Controls.Add(this.tabControl1);
            this.tpe_function.Location = new System.Drawing.Point(4, 29);
            this.tpe_function.Name = "tpe_function";
            this.tpe_function.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_function.Size = new System.Drawing.Size(931, 355);
            this.tpe_function.TabIndex = 1;
            this.tpe_function.Text = "Chức năng";
            this.tpe_function.UseVisualStyleBackColor = true;
            // 
            // tpe_Book
            // 
            this.tpe_Book.Location = new System.Drawing.Point(4, 34);
            this.tpe_Book.Name = "tpe_Book";
            this.tpe_Book.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_Book.Size = new System.Drawing.Size(931, 350);
            this.tpe_Book.TabIndex = 2;
            this.tpe_Book.Text = "Sách";
            this.tpe_Book.UseVisualStyleBackColor = true;
            // 
            // tpe_Author
            // 
            this.tpe_Author.Location = new System.Drawing.Point(4, 34);
            this.tpe_Author.Name = "tpe_Author";
            this.tpe_Author.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_Author.Size = new System.Drawing.Size(931, 350);
            this.tpe_Author.TabIndex = 3;
            this.tpe_Author.Text = "Tác giả";
            this.tpe_Author.UseVisualStyleBackColor = true;
            // 
            // tpe_Publisher
            // 
            this.tpe_Publisher.Location = new System.Drawing.Point(4, 34);
            this.tpe_Publisher.Name = "tpe_Publisher";
            this.tpe_Publisher.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_Publisher.Size = new System.Drawing.Size(931, 350);
            this.tpe_Publisher.TabIndex = 4;
            this.tpe_Publisher.Text = "Nhà xuất bản";
            this.tpe_Publisher.UseVisualStyleBackColor = true;
            // 
            // tpe_Promotion
            // 
            this.tpe_Promotion.Location = new System.Drawing.Point(4, 34);
            this.tpe_Promotion.Name = "tpe_Promotion";
            this.tpe_Promotion.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_Promotion.Size = new System.Drawing.Size(931, 350);
            this.tpe_Promotion.TabIndex = 5;
            this.tpe_Promotion.Text = "Khuyến mại";
            this.tpe_Promotion.UseVisualStyleBackColor = true;
            // 
            // tpe_Login
            // 
            this.tpe_Login.Location = new System.Drawing.Point(4, 34);
            this.tpe_Login.Name = "tpe_Login";
            this.tpe_Login.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_Login.Size = new System.Drawing.Size(931, 350);
            this.tpe_Login.TabIndex = 6;
            this.tpe_Login.Text = "Đăng nhập";
            this.tpe_Login.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpe_sale);
            this.tabControl1.Controls.Add(this.tpe_buy);
            this.tabControl1.Controls.Add(this.tpe_Account);
            this.tabControl1.Controls.Add(this.tpe_report);
            this.tabControl1.Controls.Add(this.tpe_Statistical);
            this.tabControl1.ItemSize = new System.Drawing.Size(70, 20);
            this.tabControl1.Location = new System.Drawing.Point(-4, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(939, 349);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tpe_sale
            // 
            this.tpe_sale.Location = new System.Drawing.Point(4, 24);
            this.tpe_sale.Name = "tpe_sale";
            this.tpe_sale.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_sale.Size = new System.Drawing.Size(931, 321);
            this.tpe_sale.TabIndex = 0;
            this.tpe_sale.Text = "Bán hàng";
            this.tpe_sale.UseVisualStyleBackColor = true;
            // 
            // tpe_buy
            // 
            this.tpe_buy.Location = new System.Drawing.Point(4, 24);
            this.tpe_buy.Name = "tpe_buy";
            this.tpe_buy.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_buy.Size = new System.Drawing.Size(931, 321);
            this.tpe_buy.TabIndex = 1;
            this.tpe_buy.Text = "Nhập hàng";
            this.tpe_buy.UseVisualStyleBackColor = true;
            // 
            // tpe_Account
            // 
            this.tpe_Account.Location = new System.Drawing.Point(4, 24);
            this.tpe_Account.Name = "tpe_Account";
            this.tpe_Account.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_Account.Size = new System.Drawing.Size(931, 321);
            this.tpe_Account.TabIndex = 2;
            this.tpe_Account.Text = "Tài khoản";
            this.tpe_Account.UseVisualStyleBackColor = true;
            // 
            // tpe_report
            // 
            this.tpe_report.Location = new System.Drawing.Point(4, 24);
            this.tpe_report.Name = "tpe_report";
            this.tpe_report.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_report.Size = new System.Drawing.Size(931, 321);
            this.tpe_report.TabIndex = 3;
            this.tpe_report.Text = "Báo cáo";
            this.tpe_report.UseVisualStyleBackColor = true;
            // 
            // tpe_Statistical
            // 
            this.tpe_Statistical.Location = new System.Drawing.Point(4, 24);
            this.tpe_Statistical.Name = "tpe_Statistical";
            this.tpe_Statistical.Padding = new System.Windows.Forms.Padding(3);
            this.tpe_Statistical.Size = new System.Drawing.Size(931, 321);
            this.tpe_Statistical.TabIndex = 4;
            this.tpe_Statistical.Text = "Thống kê";
            this.tpe_Statistical.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 425);
            this.Controls.Add(this.tcl_Home);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Shop";
            this.tcl_Home.ResumeLayout(false);
            this.tpe_function.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcl_Home;
        private System.Windows.Forms.TabPage tpe_Home;
        private System.Windows.Forms.TabPage tpe_function;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpe_sale;
        private System.Windows.Forms.TabPage tpe_buy;
        private System.Windows.Forms.TabPage tpe_Account;
        private System.Windows.Forms.TabPage tpe_report;
        private System.Windows.Forms.TabPage tpe_Statistical;
        private System.Windows.Forms.TabPage tpe_Book;
        private System.Windows.Forms.TabPage tpe_Author;
        private System.Windows.Forms.TabPage tpe_Publisher;
        private System.Windows.Forms.TabPage tpe_Promotion;
        private System.Windows.Forms.TabPage tpe_Login;
    }
}

