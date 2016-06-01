namespace BookShop
{
    partial class Bill_Create
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
            this.txt_billID = new System.Windows.Forms.TextBox();
            this.txt_bookID = new System.Windows.Forms.TextBox();
            this.txt_slBill = new System.Windows.Forms.TextBox();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_idNV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_createBill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_billID
            // 
            this.txt_billID.Location = new System.Drawing.Point(99, 31);
            this.txt_billID.Name = "txt_billID";
            this.txt_billID.Size = new System.Drawing.Size(148, 20);
            this.txt_billID.TabIndex = 0;
            // 
            // txt_bookID
            // 
            this.txt_bookID.Location = new System.Drawing.Point(99, 57);
            this.txt_bookID.Name = "txt_bookID";
            this.txt_bookID.Size = new System.Drawing.Size(148, 20);
            this.txt_bookID.TabIndex = 0;
            // 
            // txt_slBill
            // 
            this.txt_slBill.Location = new System.Drawing.Point(99, 83);
            this.txt_slBill.Name = "txt_slBill";
            this.txt_slBill.Size = new System.Drawing.Size(148, 20);
            this.txt_slBill.TabIndex = 0;
            // 
            // txt_time
            // 
            this.txt_time.Location = new System.Drawing.Point(99, 111);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(148, 20);
            this.txt_time.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MÃ HÓA ĐƠN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MÃ SÁCH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "SỐ LƯỢNG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "NGÀY NHẬP";
            // 
            // txt_idNV
            // 
            this.txt_idNV.Location = new System.Drawing.Point(99, 137);
            this.txt_idNV.Name = "txt_idNV";
            this.txt_idNV.Size = new System.Drawing.Size(148, 20);
            this.txt_idNV.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "MÃ NHÂN VIÊN";
            // 
            // btn_createBill
            // 
            this.btn_createBill.Location = new System.Drawing.Point(99, 174);
            this.btn_createBill.Name = "btn_createBill";
            this.btn_createBill.Size = new System.Drawing.Size(101, 30);
            this.btn_createBill.TabIndex = 6;
            this.btn_createBill.Text = "+THÊM MỚI";
            this.btn_createBill.UseVisualStyleBackColor = true;
            this.btn_createBill.Click += new System.EventHandler(this.btn_createBill_Click);
            // 
            // Bill_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 217);
            this.Controls.Add(this.btn_createBill);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_idNV);
            this.Controls.Add(this.txt_time);
            this.Controls.Add(this.txt_slBill);
            this.Controls.Add(this.txt_bookID);
            this.Controls.Add(this.txt_billID);
            this.Name = "Bill_Create";
            this.Text = "Bill_Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_billID;
        private System.Windows.Forms.TextBox txt_bookID;
        private System.Windows.Forms.TextBox txt_slBill;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_idNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_createBill;
    }
}