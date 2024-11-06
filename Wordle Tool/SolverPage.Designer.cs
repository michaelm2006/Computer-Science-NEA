namespace Wordle_Tool
{
    partial class SolverPage
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
            this.NextWordButton = new System.Windows.Forms.Button();
            this.ResetSolverButton = new System.Windows.Forms.Button();
            this.startingWordButton = new System.Windows.Forms.Button();
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
            // NextWordButton
            // 
            this.NextWordButton.Location = new System.Drawing.Point(55, 409);
            this.NextWordButton.Margin = new System.Windows.Forms.Padding(2);
            this.NextWordButton.Name = "NextWordButton";
            this.NextWordButton.Size = new System.Drawing.Size(107, 19);
            this.NextWordButton.TabIndex = 1;
            this.NextWordButton.Text = "next word";
            this.NextWordButton.UseVisualStyleBackColor = true;
            this.NextWordButton.Click += new System.EventHandler(this.NextWordButton_Clicked);
            // 
            // ResetSolverButton
            // 
            this.ResetSolverButton.Location = new System.Drawing.Point(209, 409);
            this.ResetSolverButton.Margin = new System.Windows.Forms.Padding(2);
            this.ResetSolverButton.Name = "ResetSolverButton";
            this.ResetSolverButton.Size = new System.Drawing.Size(107, 19);
            this.ResetSolverButton.TabIndex = 2;
            this.ResetSolverButton.Text = "reset";
            this.ResetSolverButton.UseVisualStyleBackColor = true;
            this.ResetSolverButton.Click += new System.EventHandler(this.ResetSolverButton_Clicked);
            // 
            // startingWordButton
            // 
            this.startingWordButton.Location = new System.Drawing.Point(263, 12);
            this.startingWordButton.Name = "startingWordButton";
            this.startingWordButton.Size = new System.Drawing.Size(98, 23);
            this.startingWordButton.TabIndex = 3;
            this.startingWordButton.Text = "set starting word";
            this.startingWordButton.UseVisualStyleBackColor = true;
            this.startingWordButton.Click += new System.EventHandler(this.startingWordButton_Click);
            // 
            // SolverPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(373, 440);
            this.Controls.Add(this.startingWordButton);
            this.Controls.Add(this.ResetSolverButton);
            this.Controls.Add(this.NextWordButton);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SolverPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Wordle Solver";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SolverPage_FormClosed);
            this.Load += new System.EventHandler(this.SolverPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextWordButton;
        private System.Windows.Forms.Button ResetSolverButton;
        private System.Windows.Forms.Button startingWordButton;
    }
}