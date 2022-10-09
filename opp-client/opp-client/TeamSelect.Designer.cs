namespace opp_client
{
    partial class TeamSelect
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
            this.JoinTeamAButton = new System.Windows.Forms.Button();
            this.JoinTeamBButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.teamACounter = new System.Windows.Forms.Label();
            this.teamBCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // JoinTeamAButton
            // 
            this.JoinTeamAButton.Location = new System.Drawing.Point(46, 94);
            this.JoinTeamAButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.JoinTeamAButton.Name = "JoinTeamAButton";
            this.JoinTeamAButton.Size = new System.Drawing.Size(148, 67);
            this.JoinTeamAButton.TabIndex = 0;
            this.JoinTeamAButton.Text = "Join Team A";
            this.JoinTeamAButton.UseVisualStyleBackColor = true;
            this.JoinTeamAButton.Click += new System.EventHandler(this.JoinTeamAButton_Click);
            // 
            // JoinTeamBButton
            // 
            this.JoinTeamBButton.Location = new System.Drawing.Point(351, 94);
            this.JoinTeamBButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.JoinTeamBButton.Name = "JoinTeamBButton";
            this.JoinTeamBButton.Size = new System.Drawing.Size(148, 67);
            this.JoinTeamBButton.TabIndex = 1;
            this.JoinTeamBButton.Text = "Join Team B";
            this.JoinTeamBButton.UseVisualStyleBackColor = true;
            this.JoinTeamBButton.Click += new System.EventHandler(this.JoinTeamBButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(46, 177);
            this.listBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(454, 69);
            this.listBox.TabIndex = 2;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(244, 94);
            this.StartGameButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(56, 33);
            this.StartGameButton.TabIndex = 4;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Red Team Player Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Blue Team Player Count:";
            // 
            // teamACounter
            // 
            this.teamACounter.AutoSize = true;
            this.teamACounter.Location = new System.Drawing.Point(44, 59);
            this.teamACounter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.teamACounter.Name = "teamACounter";
            this.teamACounter.Size = new System.Drawing.Size(13, 13);
            this.teamACounter.TabIndex = 7;
            this.teamACounter.Text = "0";
            // 
            // teamBCounter
            // 
            this.teamBCounter.AutoSize = true;
            this.teamBCounter.Location = new System.Drawing.Point(349, 59);
            this.teamBCounter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.teamBCounter.Name = "teamBCounter";
            this.teamBCounter.Size = new System.Drawing.Size(13, 13);
            this.teamBCounter.TabIndex = 8;
            this.teamBCounter.Text = "0";
            // 
            // TeamSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 262);
            this.Controls.Add(this.teamBCounter);
            this.Controls.Add(this.teamACounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.JoinTeamBButton);
            this.Controls.Add(this.JoinTeamAButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TeamSelect";
            this.Text = "TeamSelect";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeamSelect_FormClosed);
            this.Load += new System.EventHandler(this.TeamSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button JoinTeamAButton;
        private System.Windows.Forms.Button JoinTeamBButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label teamACounter;
        private System.Windows.Forms.Label teamBCounter;
    }
}