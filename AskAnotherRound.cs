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
    public partial class AskAnotherRound : Form
    {
        Damka m_DamkaBoard;
        GameManager.eGameResult m_GameResult;

        public delegate void AnotherGameEventHandler(bool answer, EventArgs args);
        public event AnotherGameEventHandler OnAnotherRound;

        public AskAnotherRound(Damka i_DamkaGame)
        {
            InitializeComponent();
        }

        public GameManager.eGameResult GameResult
        {
            get { return m_GameResult; }
            set
            {
                m_GameResult = value;
                changeLabel1AccordingToResult(m_GameResult);
            }
        }

        private void changeLabel1AccordingToResult(GameManager.eGameResult i_GameResult)
        {
            if (i_GameResult == GameManager.eGameResult.Player1Win)
            {
                label1.Text = "Player 1 Won!";
            }
            else if (i_GameResult == GameManager.eGameResult.Player2Win)
            {
                label1.Text = "Player 2 Won!";
            }
            else
            {
                label1.Text = "Tie!";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (OnAnotherRound != null)
            {
                OnAnotherRound.Invoke(true, EventArgs.Empty);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_DamkaBoard.Close();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
 
        }
    }
}
