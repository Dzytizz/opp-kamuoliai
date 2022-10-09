
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
            this.button2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.logList.Location = new System.Drawing.Point(14, 268);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(804, 108);
            this.logList.TabIndex = 1;
            // 
            // MainGameLoop
            // 
            this.MainGameLoop.Enabled = true;
            this.MainGameLoop.Interval = 20;
            this.MainGameLoop.Tick += new System.EventHandler(this.MainGameLoop_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(666, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Get game state";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ClientWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList imageList1;
    }
}

