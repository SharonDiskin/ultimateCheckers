using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C20_Ex02
{
    public partial class Damka : Form
    {
        static Board m_MyBoard;
        public Button[,] m_BtnGrid;
        public delegate void OnClickEvenHandler(Point btnLocation, EventArgs args);
        public event OnClickEvenHandler OnClick;

        public Damka(Board i_Board)
        {
            m_MyBoard = i_Board;
            m_BtnGrid = new Button[m_MyBoard.Size, m_MyBoard.Size];
            m_MyBoard.OnBoardChange += BoardChanged;
            InitializeComponent();
            populateGrid();
            UpdateBoard();
        }

        public Button[,] Grid
        {
            get { return m_BtnGrid; }
        }

        private void populateGrid()
        {
            int buttonSize = 50;

            for (int i = 0; i < m_MyBoard.Size; i++)
            {
                for (int j = 0; j < m_MyBoard.Size; j++)
                {
                    m_BtnGrid[i, j] = new Button();
                    m_BtnGrid[i, j].Height = buttonSize;
                    m_BtnGrid[i, j].Width = buttonSize;
                    m_BtnGrid[i, j].Click += Grid_Button_Click;
                    Controls.Add(m_BtnGrid[i, j]);
                    m_BtnGrid[i, j].Location = new Point(j * buttonSize, i * buttonSize+50);
                    m_BtnGrid[i, j].Tag = new Point(j, i);
                    if ((i % 2 == 0 && j % 2 == 1) || (i % 2 == 1 && j % 2 == 0))
                    {
                        m_BtnGrid[i, j].BackColor = Color.NavajoWhite;
                    }
                    else
                    {
                        m_BtnGrid[i, j].BackColor = Color.SaddleBrown;
                    }
                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Point currLocation = (Point)clickedButton.Tag;

            if (OnClick != null)
            {
                OnClick.Invoke(currLocation, EventArgs.Empty);
            }
        }

        public void BoardChanged(object sender, EventArgs e)
        {
            UpdateBoard();
        }

        public void UpdateBoard()
        {
            for (int i = 0; i < m_MyBoard.Size; i++)
            {
                for (int j = 0; j < m_MyBoard.Size; j++)
                {
                    if (m_MyBoard.Grid[i, j].Sign == Cell.eCellSign.PawnX)
                    {
                        this.Grid[i, j].BackgroundImage = Image.FromFile(@"C:\Users\ronro\source\repos\C20_Ex02 YoniMelki 328788138 SharonDiskin 205379993\C20_Ex02\blackPawn.png");
                    }
                    if (m_MyBoard.Grid[i, j].Sign == Cell.eCellSign.PawnO)
                    {
                        this.Grid[i, j].BackgroundImage = Image.FromFile(@"C:\Users\ronro\source\repos\C20_Ex02 YoniMelki 328788138 SharonDiskin 205379993\C20_Ex02\whitePawn.png");
                    }
                    if (m_MyBoard.Grid[i, j].Sign == Cell.eCellSign.KingX)
                    {
                        this.Grid[i, j].Text = "K";
                    }
                    if (m_MyBoard.Grid[i, j].Sign == Cell.eCellSign.KingO)
                    {
                        this.Grid[i, j].Text = "U";
                    }
                    if(m_MyBoard.Grid[i,j].Sign == Cell.eCellSign.Empty)
                    {
                        this.Grid[i, j].BackgroundImage = null;
                        this.Grid[i,j].Text = " ";
                    }
                }
            }
        }

        private void SmallBoard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
