namespace OnlineXOGame_Client.WinForms.Forms.XOGame {
    partial class GamesForm {
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvGames = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            PlayerX = new DataGridViewTextBoxColumn();
            PlayerO = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            CurrentTurn = new DataGridViewTextBoxColumn();
            Winner = new DataGridViewTextBoxColumn();
            Join = new DataGridViewButtonColumn();
            Watch = new DataGridViewButtonColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            txtGameId = new TextBox();
            btnJoin = new Button();
            btnWatch = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            lblCountAll = new Label();
            label8 = new Label();
            label2 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnApplyFilter = new Button();
            label3 = new Label();
            txtWinnerFilter = new TextBox();
            cbGameStatusFilter = new ComboBox();
            btnCreateGame = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGames).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // dgvGames
            // 
            dgvGames.AllowUserToAddRows = false;
            dgvGames.AllowUserToDeleteRows = false;
            dgvGames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGames.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI",9F,FontStyle.Bold,GraphicsUnit.Point,0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvGames.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGames.Columns.AddRange(new DataGridViewColumn[] { Id,PlayerX,PlayerO,Status,CurrentTurn,Winner,Join,Watch });
            dgvGames.Dock = DockStyle.Fill;
            dgvGames.Location = new Point(3,202);
            dgvGames.MultiSelect = false;
            dgvGames.Name = "dgvGames";
            dgvGames.ReadOnly = true;
            dgvGames.RowHeadersWidth = 51;
            dgvGames.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvGames.Size = new Size(776,268);
            dgvGames.TabIndex = 1;
            dgvGames.CellClick += dgvGames_CellClick;
            dgvGames.RowsAdded += dgvGames_RowsAdded;
            dgvGames.RowsRemoved += dgvGames_RowsRemoved;
            // 
            // Id
            // 
            Id.HeaderText = "Game ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 99;
            // 
            // PlayerX
            // 
            PlayerX.HeaderText = "Player X";
            PlayerX.MinimumWidth = 6;
            PlayerX.Name = "PlayerX";
            PlayerX.ReadOnly = true;
            PlayerX.Width = 95;
            // 
            // PlayerO
            // 
            PlayerO.HeaderText = "Player O";
            PlayerO.MinimumWidth = 6;
            PlayerO.Name = "PlayerO";
            PlayerO.ReadOnly = true;
            PlayerO.Width = 96;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 82;
            // 
            // CurrentTurn
            // 
            CurrentTurn.HeaderText = "Current Turn";
            CurrentTurn.MinimumWidth = 6;
            CurrentTurn.Name = "CurrentTurn";
            CurrentTurn.ReadOnly = true;
            CurrentTurn.Width = 127;
            // 
            // Winner
            // 
            Winner.HeaderText = "Winner";
            Winner.MinimumWidth = 6;
            Winner.Name = "Winner";
            Winner.ReadOnly = true;
            Winner.Width = 89;
            // 
            // Join
            // 
            Join.HeaderText = "Join";
            Join.MinimumWidth = 6;
            Join.Name = "Join";
            Join.ReadOnly = true;
            Join.Width = 44;
            // 
            // Watch
            // 
            Watch.HeaderText = "Watch";
            Watch.MinimumWidth = 6;
            Watch.Name = "Watch";
            Watch.ReadOnly = true;
            Watch.Width = 59;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label1,0,0);
            tableLayoutPanel1.Controls.Add(txtGameId,1,0);
            tableLayoutPanel1.Controls.Add(btnJoin,2,0);
            tableLayoutPanel1.Controls.Add(btnWatch,3,0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3,83);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute,20F));
            tableLayoutPanel1.Size = new Size(776,35);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3,0);
            label1.Name = "label1";
            label1.Size = new Size(70,35);
            label1.TabIndex = 2;
            label1.Text = "Game ID:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtGameId
            // 
            txtGameId.Dock = DockStyle.Fill;
            txtGameId.Location = new Point(79,3);
            txtGameId.Name = "txtGameId";
            txtGameId.Size = new Size(507,27);
            txtGameId.TabIndex = 3;
            // 
            // btnJoin
            // 
            btnJoin.Dock = DockStyle.Fill;
            btnJoin.Location = new Point(592,3);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(94,29);
            btnJoin.TabIndex = 0;
            btnJoin.Text = "Join";
            btnJoin.UseVisualStyleBackColor = true;
            btnJoin.Click += btnJoin_Click;
            // 
            // btnWatch
            // 
            btnWatch.Dock = DockStyle.Fill;
            btnWatch.Location = new Point(692,3);
            btnWatch.Name = "btnWatch";
            btnWatch.Size = new Size(81,29);
            btnWatch.TabIndex = 0;
            btnWatch.Text = "Watch";
            btnWatch.UseVisualStyleBackColor = true;
            btnWatch.Click += btnWatch_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4,0,5);
            tableLayoutPanel2.Controls.Add(label2,0,0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1,0,1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3,0,2);
            tableLayoutPanel2.Controls.Add(dgvGames,0,4);
            tableLayoutPanel2.Controls.Add(btnCreateGame,0,3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0,25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent,100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(782,502);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,20F));
            tableLayoutPanel4.Controls.Add(lblCountAll,0,0);
            tableLayoutPanel4.Controls.Add(label8,0,0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3,476);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent,100F));
            tableLayoutPanel4.Size = new Size(776,23);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // lblCountAll
            // 
            lblCountAll.AutoSize = true;
            lblCountAll.Dock = DockStyle.Fill;
            lblCountAll.Font = new Font("Segoe UI",10F,FontStyle.Bold);
            lblCountAll.Location = new Point(743,0);
            lblCountAll.Name = "lblCountAll";
            lblCountAll.Size = new Size(30,23);
            lblCountAll.TabIndex = 7;
            lblCountAll.Text = "45";
            lblCountAll.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI",10F);
            label8.Location = new Point(3,0);
            label8.Name = "label8";
            label8.Size = new Size(734,23);
            label8.TabIndex = 9;
            label8.Text = "# Count All ";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI",16F,FontStyle.Bold);
            label2.ForeColor = Color.DarkRed;
            label2.Location = new Point(3,0);
            label2.Name = "label2";
            label2.Size = new Size(776,80);
            label2.TabIndex = 4;
            label2.Text = "XO Games ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(btnApplyFilter,3,0);
            tableLayoutPanel3.Controls.Add(label3,0,0);
            tableLayoutPanel3.Controls.Add(txtWinnerFilter,1,0);
            tableLayoutPanel3.Controls.Add(cbGameStatusFilter,2,0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3,124);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent,100F));
            tableLayoutPanel3.Size = new Size(776,36);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.AutoSize = true;
            btnApplyFilter.Location = new Point(670,3);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(103,30);
            btnApplyFilter.TabIndex = 0;
            btnApplyFilter.Text = "Apply Filter";
            btnApplyFilter.UseVisualStyleBackColor = true;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3,0);
            label3.Name = "label3";
            label3.Size = new Size(59,36);
            label3.TabIndex = 1;
            label3.Text = "Winner:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtWinnerFilter
            // 
            txtWinnerFilter.Dock = DockStyle.Fill;
            txtWinnerFilter.Location = new Point(68,3);
            txtWinnerFilter.Name = "txtWinnerFilter";
            txtWinnerFilter.Size = new Size(439,27);
            txtWinnerFilter.TabIndex = 2;
            txtWinnerFilter.TextChanged += txtWinnerIdFilter_TextChanged;
            // 
            // cbGameStatusFilter
            // 
            cbGameStatusFilter.Dock = DockStyle.Fill;
            cbGameStatusFilter.FormattingEnabled = true;
            cbGameStatusFilter.Items.AddRange(new object[] { "All","Waiting for players","In progress","Finished" });
            cbGameStatusFilter.Location = new Point(513,3);
            cbGameStatusFilter.Name = "cbGameStatusFilter";
            cbGameStatusFilter.Size = new Size(151,28);
            cbGameStatusFilter.TabIndex = 3;
            cbGameStatusFilter.SelectedIndexChanged += cbGameStatusFilter_SelectedIndexChanged;
            // 
            // btnCreateGame
            // 
            btnCreateGame.AutoSize = true;
            btnCreateGame.Dock = DockStyle.Right;
            btnCreateGame.Font = new Font("Segoe UI",9F,FontStyle.Bold);
            btnCreateGame.Location = new Point(595,166);
            btnCreateGame.Name = "btnCreateGame";
            btnCreateGame.Size = new Size(184,30);
            btnCreateGame.TabIndex = 4;
            btnCreateGame.Text = "Create a game";
            btnCreateGame.UseVisualStyleBackColor = true;
            btnCreateGame.Click += btnCreateGame_Click;
            // 
            // GamesForm
            // 
            AutoScaleDimensions = new SizeF(8F,20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782,553);
            Controls.Add(tableLayoutPanel2);
            Name = "GamesForm";
            Text = "GamesForm";
            Load += GamesForm_Load;
            Shown += GamesForm_Shown;
            Controls.SetChildIndex(tableLayoutPanel2,0);
            ((System.ComponentModel.ISupportInitialize)dgvGames).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvGames;
        private Button btnJoin;
        private Button btnWatch;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox txtGameId;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private Button btnCreateGame;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnApplyFilter;
        private Label label3;
        private TextBox txtWinnerFilter;
        private ComboBox cbGameStatusFilter;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn PlayerX;
        private DataGridViewTextBoxColumn PlayerO;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn CurrentTurn;
        private DataGridViewTextBoxColumn Winner;
        private DataGridViewButtonColumn Join;
        private DataGridViewButtonColumn Watch;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label8;
        private Label lblCountAll;
    }
}