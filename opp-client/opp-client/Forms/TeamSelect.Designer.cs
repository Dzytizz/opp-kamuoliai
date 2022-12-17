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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // JoinTeamAButton
            // 
            this.JoinTeamAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinTeamAButton.Location = new System.Drawing.Point(61, 116);
            this.JoinTeamAButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JoinTeamAButton.Name = "JoinTeamAButton";
            this.JoinTeamAButton.Size = new System.Drawing.Size(225, 82);
            this.JoinTeamAButton.TabIndex = 0;
            this.JoinTeamAButton.Text = "Join Team A";
            this.JoinTeamAButton.UseVisualStyleBackColor = true;
            this.JoinTeamAButton.Click += new System.EventHandler(this.JoinTeamAButton_Click);
            // 
            // JoinTeamBButton
            // 
            this.JoinTeamBButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinTeamBButton.Location = new System.Drawing.Point(468, 116);
            this.JoinTeamBButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JoinTeamBButton.Name = "JoinTeamBButton";
            this.JoinTeamBButton.Size = new System.Drawing.Size(228, 82);
            this.JoinTeamBButton.TabIndex = 1;
            this.JoinTeamBButton.Text = "Join Team B";
            this.JoinTeamBButton.UseVisualStyleBackColor = true;
            this.JoinTeamBButton.Click += new System.EventHandler(this.JoinTeamBButton_Click);
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(51, 552);
            this.listBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(635, 68);
            this.listBox.TabIndex = 2;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameButton.Location = new System.Drawing.Point(341, 116);
            this.StartGameButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(75, 41);
            this.StartGameButton.TabIndex = 4;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Red Team Player Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(465, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Blue Team Player Count:";
            // 
            // teamACounter
            // 
            this.teamACounter.AutoSize = true;
            this.teamACounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamACounter.Location = new System.Drawing.Point(59, 73);
            this.teamACounter.Name = "teamACounter";
            this.teamACounter.Size = new System.Drawing.Size(23, 25);
            this.teamACounter.TabIndex = 7;
            this.teamACounter.Text = "0";
            // 
            // teamBCounter
            // 
            this.teamBCounter.AutoSize = true;
            this.teamBCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamBCounter.Location = new System.Drawing.Point(465, 73);
            this.teamBCounter.Name = "teamBCounter";
            this.teamBCounter.Size = new System.Drawing.Size(23, 25);
            this.teamBCounter.TabIndex = 8;
            this.teamBCounter.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(224, 235);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Player Name (Up to 8 characters)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(261, 320);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Player Number (Max 99)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(267, 279);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 22);
            this.textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(267, 359);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.MaxLength = 2;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(221, 22);
            this.textBox2.TabIndex = 12;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(299, 401);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Player Uniform";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "stripes",
            "dots"});
            this.comboBox1.Location = new System.Drawing.Point(267, 441);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 24);
            this.comboBox1.TabIndex = 14;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Defend player",
            "Attack player"});
            this.comboBox2.Location = new System.Drawing.Point(266, 500);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(222, 24);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 480);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Position";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // TeamSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 649);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.teamBCounter);
            this.Controls.Add(this.teamACounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.JoinTeamBButton);
            this.Controls.Add(this.JoinTeamAButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
    }
}