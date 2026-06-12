namespace OnlineXOGame_Client.WinForms.Forms {
    partial class BaseForm {
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
            statusStrip = new StatusStrip();
            pbProgressBar = new ToolStripProgressBar();
            lblProgressLabel = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            tsLblUsername = new ToolStripLabel();
            statusStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20,20);
            statusStrip.Items.AddRange(new ToolStripItem[] { pbProgressBar,lblProgressLabel });
            statusStrip.Location = new Point(0,424);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800,26);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // pbProgressBar
            // 
            pbProgressBar.MarqueeAnimationSpeed = 50;
            pbProgressBar.Name = "pbProgressBar";
            pbProgressBar.Size = new Size(100,18);
            pbProgressBar.Style = ProgressBarStyle.Marquee;
            // 
            // lblProgressLabel
            // 
            lblProgressLabel.Name = "lblProgressLabel";
            lblProgressLabel.Size = new Size(92,20);
            lblProgressLabel.Text = "Processing ...";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20,20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsLblUsername });
            toolStrip1.Location = new Point(0,0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RightToLeft = RightToLeft.Yes;
            toolStrip1.Size = new Size(800,25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsLblUsername
            // 
            tsLblUsername.Image = Properties.Resources.icons8_profile_24;
            tsLblUsername.IsLink = true;
            tsLblUsername.Name = "tsLblUsername";
            tsLblUsername.Size = new Size(131,22);
            tsLblUsername.Text = "toolStripLabel1";
            tsLblUsername.Click += tsLblUsername_Click;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(8F,20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800,450);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip);
            Name = "BaseForm";
            Text = "BaseForm";
            Shown += BaseForm_Shown;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblProgressLabel;
        private ToolStripProgressBar pbProgressBar;
        private ToolStrip toolStrip1;
        private ToolStripLabel tsLblUsername;
    }
}