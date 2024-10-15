namespace Wordle_Tool
{
    partial class PracticePage
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
            this.BackButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.leaderboardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(50, 390);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 23);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // leaderboardButton
            // 
            this.leaderboardButton.Location = new System.Drawing.Point(234, 390);
            this.leaderboardButton.Name = "leaderboardButton";
            this.leaderboardButton.Size = new System.Drawing.Size(75, 23);
            this.leaderboardButton.TabIndex = 2;
            this.leaderboardButton.Text = "leaderboard";
            this.leaderboardButton.UseVisualStyleBackColor = true;
            // 
            // PracticePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(1036, 450);
            this.Controls.Add(this.leaderboardButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PracticePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Wordle Practice";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PracticePage_FormClosed);
            this.Load += new System.EventHandler(this.PracticePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button leaderboardButton;
    }
}