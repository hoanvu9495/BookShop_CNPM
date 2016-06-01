namespace BookShop
{
    partial class Bill_newCreate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_billID = new System.Windows.Forms.TextBox();
            this.txt_nxbID = new System.Windows.Forms.TextBox();
            this.btn_billCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã nhà xuất bản";
            // 
            // txt_billID
            // 
            this.txt_billID.Location = new System.Drawing.Point(105, 27);
            this.txt_billID.Name = "txt_billID";
            this.txt_billID.Size = new System.Drawing.Size(100, 20);
            this.txt_billID.TabIndex = 2;
            // 
            // txt_nxbID
            // 
            this.txt_nxbID.Location = new System.Drawing.Point(105, 60);
            this.txt_nxbID.Name = "txt_nxbID";
            this.txt_nxbID.Size = new System.Drawing.Size(100, 20);
            this.txt_nxbID.TabIndex = 3;
            // 
            // btn_billCreate
            // 
            this.btn_billCreate.Location = new System.Drawing.Point(105, 100);
            this.btn_billCreate.Name = "btn_billCreate";
            this.btn_billCreate.Size = new System.Drawing.Size(75, 34);
            this.btn_billCreate.TabIndex = 6;
            this.btn_billCreate.Text = "+Thêm";
            this.btn_billCreate.UseVisualStyleBackColor = true;
            this.btn_billCreate.Click += new System.EventHandler(this.btn_billCreate_Click);
            // 
            // Bill_newCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 149);
            this.Controls.Add(this.btn_billCreate);
            this.Controls.Add(this.txt_nxbID);
            this.Controls.Add(this.txt_billID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Bill_newCreate";
            this.Text = "New Bill";
            this.Load += new System.EventHandler(this.Bill_newCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_billID;
        private System.Windows.Forms.TextBox txt_nxbID;
        private System.Windows.Forms.Button btn_billCreate;
    }
}