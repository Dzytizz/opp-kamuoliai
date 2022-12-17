
namespace opp_client
{
    partial class ClientWindow
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
            this.playerIDLabel = new System.Windows.Forms.Label();
            this.logList = new System.Windows.Forms.ListBox();
            this.MainGameLoop = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.stateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playerIDLabel
            // 
            this.playerIDLabel.AutoSize = true;
            this.playerIDLabel.Location = new System.Drawing.Point(12, 9);
            this.playerIDLabel.Name = "playerIDLabel";
            this.playerIDLabel.Size = new System.Drawing.Size(0, 13);
            this.playerIDLabel.TabIndex = 0;
            // 
            // logList
            // 
            this.logList.FormattingEnabled = true;
            this.logList.Location = new System.Drawing.Point(14, 371);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(804, 69);
            this.logList.TabIndex = 1;
            // 
            // MainGameLoop
            // 
            this.MainGameLoop.Enabled = true;
            this.MainGameLoop.Interval = 20;
            this.MainGameLoop.Tick += new System.EventHandler(this.MainGameLoop_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(15, 447);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(803, 20);
            this.chatTextBox.TabIndex = 2;
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Enabled = true;
            this.AnimationTimer.Interval = 50;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(368, 9);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(86, 31);
            this.stateLabel.TabIndex = 3;
            this.stateLabel.Text = "label1";
            // 
            // ClientWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(834, 480);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.logList);
            this.Controls.Add(this.playerIDLabel);
            this.KeyPreview = true;
            this.Name = "ClientWindow";
            this.Text = "ClientWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientWindow_FormClosed);
            this.Load += new System.EventHandler(this.ClientWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerIDLabel;
        private System.Windows.Forms.ListBox logList;
        private System.Windows.Forms.Timer MainGameLoop;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.Label stateLabel;
    }
}

