using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C20_Ex02
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }


        public string Player1Name
        {
            get
            { return Player1TextBox.Text; }
        }
        public string Player2Name
        {
            get
            { return Player2TextBox.Text; }
        }

        public int Dimension
        {
            get
            {
                int dimension;
                if (smallDim.Checked == true)
                {
                    dimension = 6;
                }
                else if (mediumDim.Checked == true)
                {
                    dimension = 8;
                }
                else
                {
                    dimension = 10;
                }
                return dimension;
            }
        }

        public int AskOpponent
        {
            get
            {
                int opponentCode;

                if (Player2CheckBox.Checked == true)
                {
                    opponentCode = 2;
                }
                else //Opponenet is PC
                {
                    opponentCode = 1;
                }

                return opponentCode;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Done_Click(object sender, EventArgs e)
        {
            this.Close(); // Can also define this button as close button
        }

        private void Player1TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Player2CheckBox.Checked == true)
            {
                Player2TextBox.Enabled = true;
            }
            if (Player2CheckBox.Checked == false)
            {
                Player2TextBox.Enabled = false;
            }

        }
    }
}
