namespace FourInARowGame
{
    partial class Field
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Field));
            this.restart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.player = new System.Windows.Forms.Label();
            this.playerColor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // restart
            // 
            resources.ApplyResources(this.restart, "restart");
            this.restart.Name = "restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // player
            // 
            resources.ApplyResources(this.player, "player");
            this.player.Name = "player";
            // 
            // playerColor
            // 
            this.playerColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.playerColor, "playerColor");
            this.playerColor.Name = "playerColor";
            // 
            // Field
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.playerColor);
            this.Controls.Add(this.player);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.restart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Field";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label player;
        private System.Windows.Forms.Panel playerColor;
    }
}

