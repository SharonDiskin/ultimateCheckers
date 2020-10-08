namespace C20_Ex02
{
    partial class GameSettingsForm
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
            this.BoardSize = new System.Windows.Forms.Label();
            this.smallDim = new System.Windows.Forms.RadioButton();
            this.mediumDim = new System.Windows.Forms.RadioButton();
            this.LargeDim = new System.Windows.Forms.RadioButton();
            this.Players = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.Player1TextBox = new System.Windows.Forms.TextBox();
            this.Player2CheckBox = new System.Windows.Forms.CheckBox();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.Done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardSize
            // 
            this.BoardSize.AutoSize = true;
            this.BoardSize.Location = new System.Drawing.Point(22, 20);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(91, 20);
            this.BoardSize.TabIndex = 0;
            this.BoardSize.Text = "Board Size:";
            this.BoardSize.Click += new System.EventHandler(this.label1_Click);
            // 
            // smallDim
            // 
            this.smallDim.AutoSize = true;
            this.smallDim.Location = new System.Drawing.Point(50, 45);
            this.smallDim.Name = "smallDim";
            this.smallDim.Size = new System.Drawing.Size(67, 24);
            this.smallDim.TabIndex = 1;
            this.smallDim.TabStop = true;
            this.smallDim.Text = "6 x 6";
            this.smallDim.UseVisualStyleBackColor = true;
            this.smallDim.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // mediumDim
            // 
            this.mediumDim.AutoSize = true;
            this.mediumDim.Location = new System.Drawing.Point(120, 45);
            this.mediumDim.Name = "mediumDim";
            this.mediumDim.Size = new System.Drawing.Size(67, 24);
            this.mediumDim.TabIndex = 2;
            this.mediumDim.TabStop = true;
            this.mediumDim.Text = "8 x 8";
            this.mediumDim.UseVisualStyleBackColor = true;
            this.mediumDim.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // LargeDim
            // 
            this.LargeDim.AutoSize = true;
            this.LargeDim.Location = new System.Drawing.Point(190, 45);
            this.LargeDim.Name = "LargeDim";
            this.LargeDim.Size = new System.Drawing.Size(85, 24);
            this.LargeDim.TabIndex = 3;
            this.LargeDim.TabStop = true;
            this.LargeDim.Text = "10 x 10";
            this.LargeDim.UseVisualStyleBackColor = true;
            this.LargeDim.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Players
            // 
            this.Players.AutoSize = true;
            this.Players.Location = new System.Drawing.Point(27, 70);
            this.Players.Name = "Players";
            this.Players.Size = new System.Drawing.Size(64, 20);
            this.Players.TabIndex = 4;
            this.Players.Text = "Players:";
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Location = new System.Drawing.Point(41, 94);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(69, 20);
            this.Player1.TabIndex = 5;
            this.Player1.Text = "Player 1:";
            this.Player1.Click += new System.EventHandler(this.label2_Click);
            // 
            // Player1TextBox
            // 
            this.Player1TextBox.Location = new System.Drawing.Point(144, 91);
            this.Player1TextBox.Name = "Player1TextBox";
            this.Player1TextBox.Size = new System.Drawing.Size(131, 26);
            this.Player1TextBox.TabIndex = 6;
            this.Player1TextBox.TextChanged += new System.EventHandler(this.Player1TextBox_TextChanged);
            // 
            // Player2CheckBox
            // 
            this.Player2CheckBox.AutoSize = true;
            this.Player2CheckBox.Location = new System.Drawing.Point(43, 123);
            this.Player2CheckBox.Name = "Player2CheckBox";
            this.Player2CheckBox.Size = new System.Drawing.Size(95, 24);
            this.Player2CheckBox.TabIndex = 7;
            this.Player2CheckBox.Text = "Player 2:";
            this.Player2CheckBox.UseVisualStyleBackColor = true;
            this.Player2CheckBox.CheckedChanged += new System.EventHandler(this.Player2CheckBox_CheckedChanged);
            // 
            // Player2TextBox
            // 
            this.Player2TextBox.AccessibleName = "";
            this.Player2TextBox.Enabled = false;
            this.Player2TextBox.Location = new System.Drawing.Point(144, 123);
            this.Player2TextBox.Name = "Player2TextBox";
            this.Player2TextBox.Size = new System.Drawing.Size(131, 26);
            this.Player2TextBox.TabIndex = 8;
            this.Player2TextBox.Text = "[Computer]";
            this.Player2TextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Done
            // 
            this.Done.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Done.Location = new System.Drawing.Point(190, 155);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(87, 27);
            this.Done.TabIndex = 9;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // GameSettingsForm
            // 
            this.AcceptButton = this.Done;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(288, 208);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.Player2CheckBox);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.Players);
            this.Controls.Add(this.LargeDim);
            this.Controls.Add(this.mediumDim);
            this.Controls.Add(this.smallDim);
            this.Controls.Add(this.BoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.Text = "GameSettings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BoardSize;
        private System.Windows.Forms.RadioButton smallDim;
        private System.Windows.Forms.RadioButton mediumDim;
        private System.Windows.Forms.RadioButton LargeDim;
        private System.Windows.Forms.Label Players;
        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.TextBox Player1TextBox;
        private System.Windows.Forms.CheckBox Player2CheckBox;
        private System.Windows.Forms.TextBox Player2TextBox;
        private System.Windows.Forms.Button Done;
    }
}