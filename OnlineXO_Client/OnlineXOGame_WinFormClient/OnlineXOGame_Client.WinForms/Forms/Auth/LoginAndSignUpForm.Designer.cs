namespace OnlineXOGame_Client.WinForms.Forms {
    partial class LoginAndSignUpForm {
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
            components = new System.ComponentModel.Container();
            btnLogin = new Button();
            btnSignUp = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            requiredErrorProvider = new ErrorProvider(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)requiredErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Dock = DockStyle.Top;
            btnLogin.Location = new Point(229,181);
            btnLogin.Margin = new Padding(8,3,8,3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(121,29);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Dock = DockStyle.Top;
            btnSignUp.Location = new Point(92,181);
            btnSignUp.Margin = new Padding(8,3,8,3);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(121,29);
            btnSignUp.TabIndex = 1;
            btnSignUp.Text = "Sign up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // txtPassword
            // 
            tableLayoutPanel1.SetColumnSpan(txtPassword,2);
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Location = new Point(89,146);
            txtPassword.Margin = new Padding(5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(264,27);
            txtPassword.TabIndex = 2;
            // 
            // txtUsername
            // 
            tableLayoutPanel1.SetColumnSpan(txtUsername,2);
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Location = new Point(89,109);
            txtUsername.Margin = new Padding(5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(264,27);
            txtUsername.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI",9F);
            label1.Location = new Point(3,104);
            label1.Name = "label1";
            label1.Size = new Size(78,37);
            label1.TabIndex = 4;
            label1.Text = "Username:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI",9F);
            label2.Location = new Point(3,141);
            label2.Name = "label2";
            label2.Size = new Size(78,37);
            label2.TabIndex = 5;
            label2.Text = "Password:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,20F));
            tableLayoutPanel1.Controls.Add(label1,0,1);
            tableLayoutPanel1.Controls.Add(label3,0,0);
            tableLayoutPanel1.Controls.Add(label2,0,2);
            tableLayoutPanel1.Controls.Add(txtPassword,1,2);
            tableLayoutPanel1.Controls.Add(txtUsername,1,1);
            tableLayoutPanel1.Controls.Add(btnSignUp,1,3);
            tableLayoutPanel1.Controls.Add(btnLogin,2,3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0,0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent,66.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent,33.3333321F));
            tableLayoutPanel1.Size = new Size(378,265);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // label3
            // 
            tableLayoutPanel1.SetColumnSpan(label3,4);
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI",16F,FontStyle.Bold,GraphicsUnit.Point,0);
            label3.ForeColor = Color.DarkRed;
            label3.Location = new Point(3,0);
            label3.Name = "label3";
            label3.Size = new Size(372,104);
            label3.TabIndex = 6;
            label3.Text = "Online XO Game";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // requiredErrorProvider
            // 
            requiredErrorProvider.ContainerControl = this;
            // 
            // LoginAndSignUpForm
            // 
            AutoScaleDimensions = new SizeF(120F,120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(378,291);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginAndSignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginAndSignUpForm";
            Shown += LoginAndSignUpForm_Shown;
            Controls.SetChildIndex(tableLayoutPanel1,0);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)requiredErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnSignUp;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private ErrorProvider requiredErrorProvider;
    }
}