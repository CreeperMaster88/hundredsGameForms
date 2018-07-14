namespace hundredsGame
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
            this.components = new System.ComponentModel.Container();
            this.gameRunner = new System.Windows.Forms.Timer(this.components);
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.restartButton = new System.Windows.Forms.Button();
            this.resetButtonFlash = new System.Windows.Forms.Timer(this.components);
            this.resetbuttonsflash = new System.Windows.Forms.Timer(this.components);
            this.resetbuttonflashagainSUCC = new System.Windows.Forms.Timer(this.components);
            this.totalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameRunner
            // 
            this.gameRunner.Enabled = true;
            this.gameRunner.Interval = 10;
            this.gameRunner.Tick += new System.EventHandler(this.gameRunner_Tick);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mainPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(1884, 1061);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.Red;
            this.restartButton.Enabled = false;
            this.restartButton.Font = new System.Drawing.Font("Quartz MS", 72F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.ForeColor = System.Drawing.Color.Lime;
            this.restartButton.Location = new System.Drawing.Point(564, 930);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(524, 119);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "RESTART";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Visible = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // resetButtonFlash
            // 
            this.resetButtonFlash.Enabled = true;
            this.resetButtonFlash.Interval = 200;
            this.resetButtonFlash.Tick += new System.EventHandler(this.resetButtonFlash_Tick);
            // 
            // resetbuttonsflash
            // 
            this.resetbuttonsflash.Enabled = true;
            this.resetbuttonsflash.Interval = 300;
            this.resetbuttonsflash.Tick += new System.EventHandler(this.resetbuttonsflash_Tick);
            // 
            // resetbuttonflashagainSUCC
            // 
            this.resetbuttonflashagainSUCC.Enabled = true;
            this.resetbuttonflashagainSUCC.Interval = 500;
            this.resetbuttonflashagainSUCC.Tick += new System.EventHandler(this.resetbuttonflashagainSUCC_Tick);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(1540, 13);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(13, 13);
            this.totalLabel.TabIndex = 2;
            this.totalLabel.Text = "0";
            this.totalLabel.Click += new System.EventHandler(this.totalLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1884, 1061);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.mainPictureBox);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameRunner;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Timer resetButtonFlash;
        private System.Windows.Forms.Timer resetbuttonsflash;
        private System.Windows.Forms.Timer resetbuttonflashagainSUCC;
        private System.Windows.Forms.Label totalLabel;
    }
}

