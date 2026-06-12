namespace OnlineXOGame_Client.WinForms.Forms.Testing {
    partial class TestingHubClientForm {
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
            btnCell00 = new Button();
            btnCell01 = new Button();
            btnCell02 = new Button();
            btnCell10 = new Button();
            btnCell11 = new Button();
            btnCell12 = new Button();
            btnCell22 = new Button();
            btnCell21 = new Button();
            btnCell20 = new Button();
            lblGameId = new Label();
            lblPlayerXId = new Label();
            lblPlayerOId = new Label();
            lblStatus = new Label();
            lblCurrentTurn = new Label();
            txtGameId = new TextBox();
            txtAccessToken = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // btnCell00
            // 
            btnCell00.Location = new Point(222,150);
            btnCell00.Name = "btnCell00";
            btnCell00.Size = new Size(44,42);
            btnCell00.TabIndex = 0;
            btnCell00.Tag = "0,0";
            btnCell00.UseVisualStyleBackColor = true;
            btnCell00.Click += btnCell_Click;
            // 
            // btnCell01
            // 
            btnCell01.Location = new Point(272,150);
            btnCell01.Name = "btnCell01";
            btnCell01.Size = new Size(44,42);
            btnCell01.TabIndex = 1;
            btnCell01.Tag = "0,1";
            btnCell01.UseVisualStyleBackColor = true;
            btnCell01.Click += btnCell_Click;
            // 
            // btnCell02
            // 
            btnCell02.Location = new Point(322,150);
            btnCell02.Name = "btnCell02";
            btnCell02.Size = new Size(44,42);
            btnCell02.TabIndex = 2;
            btnCell02.Tag = "0,2";
            btnCell02.UseVisualStyleBackColor = true;
            btnCell02.Click += btnCell_Click;
            // 
            // btnCell10
            // 
            btnCell10.Location = new Point(222,198);
            btnCell10.Name = "btnCell10";
            btnCell10.Size = new Size(44,42);
            btnCell10.TabIndex = 3;
            btnCell10.Tag = "1,0";
            btnCell10.UseVisualStyleBackColor = true;
            btnCell10.Click += btnCell_Click;
            // 
            // btnCell11
            // 
            btnCell11.Location = new Point(272,198);
            btnCell11.Name = "btnCell11";
            btnCell11.Size = new Size(44,42);
            btnCell11.TabIndex = 4;
            btnCell11.Tag = "1,1";
            btnCell11.UseVisualStyleBackColor = true;
            btnCell11.Click += btnCell_Click;
            // 
            // btnCell12
            // 
            btnCell12.Location = new Point(322,198);
            btnCell12.Name = "btnCell12";
            btnCell12.Size = new Size(44,42);
            btnCell12.TabIndex = 5;
            btnCell12.Tag = "1,2";
            btnCell12.UseVisualStyleBackColor = true;
            btnCell12.Click += btnCell_Click;
            // 
            // btnCell22
            // 
            btnCell22.Location = new Point(322,246);
            btnCell22.Name = "btnCell22";
            btnCell22.Size = new Size(44,42);
            btnCell22.TabIndex = 6;
            btnCell22.Tag = "2,2";
            btnCell22.UseVisualStyleBackColor = true;
            btnCell22.Click += btnCell_Click;
            // 
            // btnCell21
            // 
            btnCell21.Location = new Point(272,246);
            btnCell21.Name = "btnCell21";
            btnCell21.Size = new Size(44,42);
            btnCell21.TabIndex = 7;
            btnCell21.Tag = "2,1";
            btnCell21.UseVisualStyleBackColor = true;
            btnCell21.Click += btnCell_Click;
            // 
            // btnCell20
            // 
            btnCell20.Location = new Point(222,246);
            btnCell20.Name = "btnCell20";
            btnCell20.Size = new Size(44,42);
            btnCell20.TabIndex = 8;
            btnCell20.Tag = "2,0";
            btnCell20.UseVisualStyleBackColor = true;
            btnCell20.Click += btnCell_Click;
            // 
            // lblGameId
            // 
            lblGameId.AutoSize = true;
            lblGameId.Location = new Point(12,9);
            lblGameId.Name = "lblGameId";
            lblGameId.Size = new Size(78,20);
            lblGameId.TabIndex = 9;
            lblGameId.Text = "lblGameId";
            // 
            // lblPlayerXId
            // 
            lblPlayerXId.AutoSize = true;
            lblPlayerXId.Location = new Point(12,29);
            lblPlayerXId.Name = "lblPlayerXId";
            lblPlayerXId.Size = new Size(88,20);
            lblPlayerXId.TabIndex = 10;
            lblPlayerXId.Text = "lblPlayerXId";
            // 
            // lblPlayerOId
            // 
            lblPlayerOId.AutoSize = true;
            lblPlayerOId.Location = new Point(12,49);
            lblPlayerOId.Name = "lblPlayerOId";
            lblPlayerOId.Size = new Size(90,20);
            lblPlayerOId.TabIndex = 11;
            lblPlayerOId.Text = "lblPlayerOId";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(287,9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(66,20);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "lblStatus";
            // 
            // lblCurrentTurn
            // 
            lblCurrentTurn.AutoSize = true;
            lblCurrentTurn.Location = new Point(287,29);
            lblCurrentTurn.Name = "lblCurrentTurn";
            lblCurrentTurn.Size = new Size(103,20);
            lblCurrentTurn.TabIndex = 13;
            lblCurrentTurn.Text = "lblCurrentTurn";
            // 
            // txtGameId
            // 
            txtGameId.Location = new Point(12,84);
            txtGameId.Name = "txtGameId";
            txtGameId.Size = new Size(125,27);
            txtGameId.TabIndex = 14;
            txtGameId.TextChanged += txtGameId_TextChanged;
            // 
            // txtAccessToken
            // 
            txtAccessToken.Location = new Point(549,2);
            txtAccessToken.Name = "txtAccessToken";
            txtAccessToken.Size = new Size(125,27);
            txtAccessToken.TabIndex = 16;
            txtAccessToken.TextChanged += txtAccessToken_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(680,2);
            button1.Name = "button1";
            button1.Size = new Size(94,29);
            button1.TabIndex = 17;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(143,84);
            button2.Name = "button2";
            button2.Size = new Size(94,29);
            button2.TabIndex = 18;
            button2.Text = "Ok";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(243,84);
            button3.Name = "button3";
            button3.Size = new Size(94,29);
            button3.TabIndex = 19;
            button3.Text = "Join";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // TestingHubClientForm
            // 
            AutoScaleDimensions = new SizeF(8F,20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800,450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtAccessToken);
            Controls.Add(txtGameId);
            Controls.Add(lblCurrentTurn);
            Controls.Add(lblStatus);
            Controls.Add(lblPlayerOId);
            Controls.Add(lblPlayerXId);
            Controls.Add(lblGameId);
            Controls.Add(btnCell20);
            Controls.Add(btnCell21);
            Controls.Add(btnCell22);
            Controls.Add(btnCell12);
            Controls.Add(btnCell11);
            Controls.Add(btnCell10);
            Controls.Add(btnCell02);
            Controls.Add(btnCell01);
            Controls.Add(btnCell00);
            Name = "TestingHubClientForm";
            Text = "TestingHubClientForm";
            Load += TestingHubClientForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCell00;
        private Button btnCell01;
        private Button btnCell02;
        private Button btnCell10;
        private Button btnCell11;
        private Button btnCell12;
        private Button btnCell22;
        private Button btnCell21;
        private Button btnCell20;
        private Label lblGameId;
        private Label lblPlayerXId;
        private Label lblPlayerOId;
        private Label lblStatus;
        private Label lblCurrentTurn;
        private TextBox txtGameId;
        private TextBox txtAccessToken;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}