namespace OnlineXOGame_Client.WinForms.Forms.XOGame {
    partial class GameInfoForm {
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
            lblCurrentTurn = new Label();
            lblStatus = new Label();
            lblPlayerO = new Label();
            lblPlayerX = new Label();
            lblGameId = new Label();
            btnCell20 = new Button();
            btnCell21 = new Button();
            btnCell22 = new Button();
            btnCell12 = new Button();
            btnCell11 = new Button();
            btnCell10 = new Button();
            btnCell02 = new Button();
            btnCell01 = new Button();
            btnCell00 = new Button();
            lblWinner = new Label();
            lblCreatedAt = new Label();
            lblStartedAt = new Label();
            lblEndedAt = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label4 = new Label();
            tlpDatesLine = new TableLayoutPanel();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            tlpPlayersLine = new TableLayoutPanel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            tlpXOTable = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            actionsToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            tlpDatesLine.SuspendLayout();
            tlpPlayersLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tlpXOTable.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblCurrentTurn
            // 
            lblCurrentTurn.AutoSize = true;
            lblCurrentTurn.Dock = DockStyle.Fill;
            lblCurrentTurn.Font = new Font("Segoe UI",16F,FontStyle.Bold);
            lblCurrentTurn.Location = new Point(370,0);
            lblCurrentTurn.Name = "lblCurrentTurn";
            lblCurrentTurn.Size = new Size(35,37);
            lblCurrentTurn.TabIndex = 33;
            lblCurrentTurn.Text = "X";
            lblCurrentTurn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblStatus,2);
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI",14F,FontStyle.Bold);
            lblStatus.ForeColor = Color.DarkRed;
            lblStatus.Location = new Point(3,0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(776,32);
            lblStatus.TabIndex = 32;
            lblStatus.Text = "In Progress";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerO
            // 
            lblPlayerO.AutoSize = true;
            lblPlayerO.Dock = DockStyle.Fill;
            lblPlayerO.Font = new Font("Segoe UI",12F,FontStyle.Bold,GraphicsUnit.Point,0);
            lblPlayerO.ForeColor = Color.Black;
            lblPlayerO.Location = new Point(411,0);
            lblPlayerO.Name = "lblPlayerO";
            lblPlayerO.Size = new Size(331,37);
            lblPlayerO.TabIndex = 31;
            lblPlayerO.Text = "ali";
            lblPlayerO.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPlayerX
            // 
            lblPlayerX.AutoSize = true;
            lblPlayerX.Dock = DockStyle.Fill;
            lblPlayerX.Font = new Font("Segoe UI",12F,FontStyle.Bold);
            lblPlayerX.ForeColor = Color.Black;
            lblPlayerX.Location = new Point(33,0);
            lblPlayerX.Name = "lblPlayerX";
            lblPlayerX.Size = new Size(331,37);
            lblPlayerX.TabIndex = 30;
            lblPlayerX.Text = "mahmoud";
            lblPlayerX.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGameId
            // 
            lblGameId.AutoSize = true;
            lblGameId.Dock = DockStyle.Fill;
            lblGameId.Font = new Font("Segoe UI",10F);
            lblGameId.Location = new Point(90,60);
            lblGameId.Name = "lblGameId";
            lblGameId.Size = new Size(689,23);
            lblGameId.TabIndex = 29;
            lblGameId.Text = "lblGameId";
            lblGameId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCell20
            // 
            btnCell20.Dock = DockStyle.Fill;
            btnCell20.Font = new Font("Segoe UI",24F,FontStyle.Bold);
            btnCell20.Location = new Point(3,195);
            btnCell20.Name = "btnCell20";
            btnCell20.Size = new Size(252,92);
            btnCell20.TabIndex = 28;
            btnCell20.Tag = "2,0";
            btnCell20.Text = "O";
            btnCell20.UseVisualStyleBackColor = true;
            btnCell20.Click += btnCell_Click;
            // 
            // btnCell21
            // 
            btnCell21.Dock = DockStyle.Fill;
            btnCell21.Font = new Font("Segoe UI",24F,FontStyle.Bold);
            btnCell21.Location = new Point(261,195);
            btnCell21.Name = "btnCell21";
            btnCell21.Size = new Size(252,92);
            btnCell21.TabIndex = 27;
            btnCell21.Tag = "2,1";
            btnCell21.UseVisualStyleBackColor = true;
            btnCell21.Click += btnCell_Click;
            // 
            // btnCell22
            // 
            btnCell22.Dock = DockStyle.Fill;
            btnCell22.Font = new Font("Segoe UI",24F,FontStyle.Bold);
            btnCell22.Location = new Point(519,195);
            btnCell22.Name = "btnCell22";
            btnCell22.Size = new Size(254,92);
            btnCell22.TabIndex = 26;
            btnCell22.Tag = "2,2";
            btnCell22.Text = "X";
            btnCell22.UseVisualStyleBackColor = true;
            btnCell22.Click += btnCell_Click;
            // 
            // btnCell12
            // 
            btnCell12.Dock = DockStyle.Fill;
            btnCell12.Font = new Font("Segoe UI",24F,FontStyle.Bold);
            btnCell12.Location = new Point(519,99);
            btnCell12.Name = "btnCell12";
            btnCell12.Size = new Size(254,90);
            btnCell12.TabIndex = 25;
            btnCell12.Tag = "1,2";
            btnCell12.UseVisualStyleBackColor = true;
            btnCell12.Click += btnCell_Click;
            // 
            // btnCell11
            // 
            btnCell11.Dock = DockStyle.Fill;
            btnCell11.Font = new Font("Segoe UI",24F,FontStyle.Bold);
            btnCell11.Location = new Point(261,99);
            btnCell11.Name = "btnCell11";
            btnCell11.Size = new Size(252,90);
            btnCell11.TabIndex = 24;
            btnCell11.Tag = "1,1";
            btnCell11.Text = "O";
            btnCell11.UseVisualStyleBackColor = true;
            btnCell11.Click += btnCell_Click;
            // 
            // btnCell10
            // 
            btnCell10.Dock = DockStyle.Fill;
            btnCell10.Font = new Font("Segoe UI",24F,FontStyle.Bold);
            btnCell10.Location = new Point(3,99);
            btnCell10.Name = "btnCell10";
            btnCell10.Size = new Size(252,90);
            btnCell10.TabIndex = 23;
            btnCell10.Tag = "1,0";
            btnCell10.UseVisualStyleBackColor = true;
            btnCell10.Click += btnCell_Click;
            // 
            // btnCell02
            // 
            btnCell02.Dock = DockStyle.Fill;
            btnCell02.Font = new Font("Segoe UI",24F,FontStyle.Bold);
            btnCell02.Location = new Point(519,3);
            btnCell02.Name = "btnCell02";
            btnCell02.Size = new Size(254,90);
            btnCell02.TabIndex = 22;
            btnCell02.Tag = "0,2";
            btnCell02.Text = "O";
            btnCell02.UseVisualStyleBackColor = true;
            btnCell02.Click += btnCell_Click;
            // 
            // btnCell01
            // 
            btnCell01.Dock = DockStyle.Fill;
            btnCell01.Font = new Font("Segoe UI",24F,FontStyle.Bold);
            btnCell01.Location = new Point(261,3);
            btnCell01.Name = "btnCell01";
            btnCell01.Size = new Size(252,90);
            btnCell01.TabIndex = 21;
            btnCell01.Tag = "0,1";
            btnCell01.UseVisualStyleBackColor = true;
            btnCell01.Click += btnCell_Click;
            // 
            // btnCell00
            // 
            btnCell00.Dock = DockStyle.Fill;
            btnCell00.Font = new Font("Segoe UI",24F,FontStyle.Bold);
            btnCell00.Location = new Point(3,3);
            btnCell00.Name = "btnCell00";
            btnCell00.Size = new Size(252,90);
            btnCell00.TabIndex = 20;
            btnCell00.Tag = "0,0";
            btnCell00.Text = "X";
            btnCell00.UseVisualStyleBackColor = true;
            btnCell00.Click += btnCell_Click;
            // 
            // lblWinner
            // 
            lblWinner.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblWinner,2);
            lblWinner.Dock = DockStyle.Fill;
            lblWinner.Font = new Font("Segoe UI",12F);
            lblWinner.Location = new Point(3,32);
            lblWinner.Name = "lblWinner";
            lblWinner.Size = new Size(776,28);
            lblWinner.TabIndex = 34;
            lblWinner.Text = "No Winner";
            lblWinner.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.AutoSize = true;
            lblCreatedAt.Dock = DockStyle.Fill;
            lblCreatedAt.Location = new Point(3,23);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(252,23);
            lblCreatedAt.TabIndex = 35;
            lblCreatedAt.Text = "2025/3/23 14:54";
            lblCreatedAt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStartedAt
            // 
            lblStartedAt.AutoSize = true;
            lblStartedAt.Dock = DockStyle.Fill;
            lblStartedAt.Font = new Font("Segoe UI",10F);
            lblStartedAt.Location = new Point(261,23);
            lblStartedAt.Name = "lblStartedAt";
            lblStartedAt.Size = new Size(252,23);
            lblStartedAt.TabIndex = 36;
            lblStartedAt.Text = "2025/3/23 14:54";
            lblStartedAt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEndedAt
            // 
            lblEndedAt.AutoSize = true;
            lblEndedAt.Dock = DockStyle.Fill;
            lblEndedAt.Font = new Font("Segoe UI",10F);
            lblEndedAt.Location = new Point(519,23);
            lblEndedAt.Name = "lblEndedAt";
            lblEndedAt.Size = new Size(254,23);
            lblEndedAt.TabIndex = 37;
            lblEndedAt.Text = "2025/3/23 14:54";
            lblEndedAt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100F));
            tableLayoutPanel1.Controls.Add(label4,0,2);
            tableLayoutPanel1.Controls.Add(tlpDatesLine,0,4);
            tableLayoutPanel1.Controls.Add(lblStatus,0,0);
            tableLayoutPanel1.Controls.Add(tlpPlayersLine,0,3);
            tableLayoutPanel1.Controls.Add(lblWinner,0,1);
            tableLayoutPanel1.Controls.Add(tlpXOTable,0,5);
            tableLayoutPanel1.Controls.Add(lblGameId,1,2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0,53);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent,100F));
            tableLayoutPanel1.Size = new Size(782,474);
            tableLayoutPanel1.TabIndex = 38;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI",10F);
            label4.Location = new Point(3,60);
            label4.Name = "label4";
            label4.Size = new Size(81,23);
            label4.TabIndex = 42;
            label4.Text = "Game ID:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpDatesLine
            // 
            tlpDatesLine.AutoSize = true;
            tlpDatesLine.ColumnCount = 3;
            tableLayoutPanel1.SetColumnSpan(tlpDatesLine,2);
            tlpDatesLine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,33.3333321F));
            tlpDatesLine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,33.3333359F));
            tlpDatesLine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,33.3333359F));
            tlpDatesLine.Controls.Add(lblCreatedAt,0,1);
            tlpDatesLine.Controls.Add(lblEndedAt,2,1);
            tlpDatesLine.Controls.Add(lblStartedAt,1,1);
            tlpDatesLine.Controls.Add(label1,0,0);
            tlpDatesLine.Controls.Add(label3,2,0);
            tlpDatesLine.Controls.Add(label2,1,0);
            tlpDatesLine.Dock = DockStyle.Fill;
            tlpDatesLine.Location = new Point(3,129);
            tlpDatesLine.Name = "tlpDatesLine";
            tlpDatesLine.RowCount = 2;
            tlpDatesLine.RowStyles.Add(new RowStyle());
            tlpDatesLine.RowStyles.Add(new RowStyle());
            tlpDatesLine.Size = new Size(776,46);
            tlpDatesLine.TabIndex = 41;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI",10F);
            label1.Location = new Point(3,0);
            label1.Name = "label1";
            label1.Size = new Size(252,23);
            label1.TabIndex = 40;
            label1.Text = "CreatedAt";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI",10F);
            label3.Location = new Point(519,0);
            label3.Name = "label3";
            label3.Size = new Size(254,23);
            label3.TabIndex = 42;
            label3.Text = "EndedAt";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI",10F);
            label2.Location = new Point(261,0);
            label2.Name = "label2";
            label2.Size = new Size(252,23);
            label2.TabIndex = 41;
            label2.Text = "StartedAt";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpPlayersLine
            // 
            tlpPlayersLine.AutoSize = true;
            tlpPlayersLine.ColumnCount = 5;
            tableLayoutPanel1.SetColumnSpan(tlpPlayersLine,2);
            tlpPlayersLine.ColumnStyles.Add(new ColumnStyle());
            tlpPlayersLine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50F));
            tlpPlayersLine.ColumnStyles.Add(new ColumnStyle());
            tlpPlayersLine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50F));
            tlpPlayersLine.ColumnStyles.Add(new ColumnStyle());
            tlpPlayersLine.Controls.Add(pictureBox2,4,0);
            tlpPlayersLine.Controls.Add(pictureBox1,0,0);
            tlpPlayersLine.Controls.Add(lblPlayerO,3,0);
            tlpPlayersLine.Controls.Add(lblPlayerX,1,0);
            tlpPlayersLine.Controls.Add(lblCurrentTurn,2,0);
            tlpPlayersLine.Dock = DockStyle.Fill;
            tlpPlayersLine.Location = new Point(3,86);
            tlpPlayersLine.Name = "tlpPlayersLine";
            tlpPlayersLine.RowCount = 1;
            tlpPlayersLine.RowStyles.Add(new RowStyle());
            tlpPlayersLine.Size = new Size(776,37);
            tlpPlayersLine.TabIndex = 40;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = Properties.Resources.icons8_o_24;
            pictureBox2.Location = new Point(748,3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25,31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 40;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.icons8_x_24;
            pictureBox1.Location = new Point(3,3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24,31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            // 
            // tlpXOTable
            // 
            tlpXOTable.ColumnCount = 3;
            tableLayoutPanel1.SetColumnSpan(tlpXOTable,2);
            tlpXOTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,33.3333321F));
            tlpXOTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,33.3333321F));
            tlpXOTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,33.3333321F));
            tlpXOTable.Controls.Add(btnCell00,0,0);
            tlpXOTable.Controls.Add(btnCell01,1,0);
            tlpXOTable.Controls.Add(btnCell22,2,2);
            tlpXOTable.Controls.Add(btnCell21,1,2);
            tlpXOTable.Controls.Add(btnCell20,0,2);
            tlpXOTable.Controls.Add(btnCell02,2,0);
            tlpXOTable.Controls.Add(btnCell10,0,1);
            tlpXOTable.Controls.Add(btnCell11,1,1);
            tlpXOTable.Controls.Add(btnCell12,2,1);
            tlpXOTable.Dock = DockStyle.Fill;
            tlpXOTable.Location = new Point(3,181);
            tlpXOTable.Name = "tlpXOTable";
            tlpXOTable.RowCount = 3;
            tlpXOTable.RowStyles.Add(new RowStyle(SizeType.Percent,33.3333321F));
            tlpXOTable.RowStyles.Add(new RowStyle(SizeType.Percent,33.3333321F));
            tlpXOTable.RowStyles.Add(new RowStyle(SizeType.Percent,33.3333321F));
            tlpXOTable.Size = new Size(776,290);
            tlpXOTable.TabIndex = 39;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20,20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { actionsToolStripMenuItem });
            menuStrip1.Location = new Point(0,25);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(782,28);
            menuStrip1.TabIndex = 39;
            menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            actionsToolStripMenuItem.Size = new Size(148,24);
            actionsToolStripMenuItem.Text = "Leave Game Room";
            actionsToolStripMenuItem.Click += actionsToolStripMenuItem_Click;
            // 
            // GameInfoForm
            // 
            AutoScaleDimensions = new SizeF(8F,20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782,553);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "GameInfoForm";
            Text = "GameInfoForm";
            FormClosing += GameInfoForm_FormClosing;
            Load += GameInfoForm_Load;
            Controls.SetChildIndex(menuStrip1,0);
            Controls.SetChildIndex(tableLayoutPanel1,0);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tlpDatesLine.ResumeLayout(false);
            tlpDatesLine.PerformLayout();
            tlpPlayersLine.ResumeLayout(false);
            tlpPlayersLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tlpXOTable.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblCurrentTurn;
        private Label lblStatus;
        private Label lblPlayerO;
        private Label lblPlayerX;
        private Label lblGameId;
        private Button btnCell20;
        private Button btnCell21;
        private Button btnCell22;
        private Button btnCell12;
        private Button btnCell11;
        private Button btnCell10;
        private Button btnCell02;
        private Button btnCell01;
        private Button btnCell00;
        private Label lblWinner;
        private Label lblCreatedAt;
        private Label lblStartedAt;
        private Label lblEndedAt;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlpXOTable;
        private Label label1;
        private Label label2;
        private Label label3;
        private TableLayoutPanel tlpPlayersLine;
        private TableLayoutPanel tlpDatesLine;
        private Label label4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem actionsToolStripMenuItem;
    }
}