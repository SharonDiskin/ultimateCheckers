namespace C20_Ex02
{
    partial class Damka
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
            this.Player2 = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player2
            // 
            this.Player2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2.AutoSize = true;
            this.Player2.Location = new System.Drawing.Point(219, 26);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(65, 20);
            this.Player2.TabIndex = 1;
            this.Player2.Text = "Player2:";
            // 
            // Player1
            // 
            this.Player1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player1.AutoSize = true;
            this.Player1.Location = new System.Drawing.Point(76, 26);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(65, 20);
            this.Player1.TabIndex = 3;
            this.Player1.Text = "Player1:";
            // 
            // BoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(339, 342);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.Player2);
            this.Name = "BoardForm";
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.SmallBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Player2;
        private System.Windows.Forms.Label Player1;
    }
}