namespace OnlineXOGame_Client.WinForms.Forms.User {
    partial class UserProfileForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblUsername = new Label();
            lblUserId = new Label();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50F));
            tableLayoutPanel1.Controls.Add(lblUsername,1,2);
            tableLayoutPanel1.Controls.Add(lblUserId,1,1);
            tableLayoutPanel1.Controls.Add(label1,0,1);
            tableLayoutPanel1.Controls.Add(label3,0,0);
            tableLayoutPanel1.Controls.Add(label2,0,2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0,0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent,66.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent,33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute,20F));
            tableLayoutPanel1.Size = new Size(382,227);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblUsername,2);
            lblUsername.Dock = DockStyle.Fill;
            lblUsername.Font = new Font("Segoe UI",9F);
            lblUsername.Location = new Point(87,144);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(292,20);
            lblUsername.TabIndex = 8;
            lblUsername.Text = "Ali";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblUserId,2);
            lblUserId.Dock = DockStyle.Fill;
            lblUserId.Font = new Font("Segoe UI",9F);
            lblUserId.Location = new Point(87,124);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(292,20);
            lblUserId.TabIndex = 7;
            lblUserId.Text = "01ktcvjrezdfcyryc4jffvcf0cq36";
            lblUserId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI",9F);
            label1.Location = new Point(3,124);
            label1.Name = "label1";
            label1.Size = new Size(78,20);
            label1.TabIndex = 4;
            label1.Text = "User ID:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            tableLayoutPanel1.SetColumnSpan(label3,3);
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI",16F,FontStyle.Bold,GraphicsUnit.Point,0);
            label3.ForeColor = Color.DarkRed;
            label3.Location = new Point(3,0);
            label3.Name = "label3";
            label3.Size = new Size(376,124);
            label3.TabIndex = 6;
            label3.Text = "Profile Info";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI",9F);
            label2.Location = new Point(3,144);
            label2.Name = "label2";
            label2.Size = new Size(78,20);
            label2.TabIndex = 5;
            label2.Text = "Username:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UserProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F,20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382,253);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserProfileForm";
            Text = "UserProfileForm";
            Shown += UserProfileForm_Shown;
            Controls.SetChildIndex(tableLayoutPanel1,0);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label lblUsername;
        private Label lblUserId;
    }
}