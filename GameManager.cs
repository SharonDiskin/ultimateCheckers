using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace C20_Ex02
{
    public class GameManager
    {
        private const int k_HumanPlayer = 2;
        private Board m_GameBoard;
        private Player m_Player1;
        private Player m_Player2;
        private Move m_Move;

        public GameManager(ref GameSettingsForm i_GameSettingsForm)
        {
            m_Move = new Move();
            Play(ref i_GameSettingsForm);
        }

        private static void calculateSumOfPointsForPlayers(ref Player io_Player1, ref Player io_Player2)
        {
            io_Player1.NumOfPoints += io_Player1.NumOfPawns + (4 * io_Player1.NumOfKings);
            io_Player2.NumOfPoints += io_Player2.NumOfPawns + (4 * io_Player2.NumOfKings);
        }

        private void initializePlayer1(ref GameSettingsForm i_GameSettingsForm)
        {
            string userName = i_GameSettingsForm.Player1Name;
            m_Player1 = new Player(userName, 0, Cell.eCellSign.PawnX, Cell.eCellSign.KingX);
            m_Player1.Turn = true;
        }

        private void initializePlayer2(ref GameSettingsForm i_GameSettingsForm)
        {
            string userName;
            int opponent = i_GameSettingsForm.AskOpponent;
            if (opponent == k_HumanPlayer)
            {
                userName = i_GameSettingsForm.Player2Name;
            }
            else
            {
                userName = "PC";
            }

            m_Player2 = new Player(userName, 0, Cell.eCellSign.PawnO, Cell.eCellSign.KingO);
            m_Player2.Turn = false;
        }

        private void initializeBoard(ref GameSettingsForm i_GameSettingsForm)
        {
            Board.eBoardDimension boardDimension = (Board.eBoardDimension)i_GameSettingsForm.Dimension;
            m_GameBoard = new Board(boardDimension);
        }

        private static bool playerHasPawnInCell(Player i_Player, Cell i_CellInBoard)
        {
            return i_Player.PawnSign == i_CellInBoard.Sign ||
                   i_Player.KingSign == i_CellInBoard.Sign;
        }

        private static bool gameOver(int i_NumOfPawnsForPlayer1, int i_NumOfPawnsForPlayer2)
        {
            return i_NumOfPawnsForPlayer1 == 0 || i_NumOfPawnsForPlayer2 == 0;
        }

        public void Play(ref GameSettingsForm i_GameSettingsForm)
        {
            initializePlayer1(ref i_GameSettingsForm);
            initializePlayer2(ref i_GameSettingsForm);
            bool userWantsAnotherGameWithSameOpponent;
            do
            {
                userWantsAnotherGameWithSameOpponent = playGame(ref i_GameSettingsForm);
            }
            while (userWantsAnotherGameWithSameOpponent);
        }

        public void ButtonClicked(Point i_Location, EventArgs e)
        {
            if (m_Move.Source.X == -100)
            {
                m_Move.Source = i_Location;
            }
            else // It is the second click
            {
                m_Move.Destination = i_Location;
                bool playerExecutedEat = false;
                if (m_Player1.Turn)
                {
                    if (isLegalMove(m_Player1, m_Move))
                    {
                        giveTurnTo(ref m_Player1, ref m_Player2, ref playerExecutedEat, m_Move);
                    }
                    else
                    {
                        MessageBox.Show("Invalid move!");
                    }
                }

                m_Move.MakeEmpty();
            }
        }

        private bool playGame(ref GameSettingsForm i_GameSettingsForm)
        {
            initializeBoard(ref i_GameSettingsForm);
            distributePawnsToPlayers(m_GameBoard.Dimension);
            Damka myBoard = new Damka(m_GameBoard);
            myBoard.OnClick += ButtonClicked;
            myBoard.UpdateBoard();
            myBoard.ShowDialog();

            bool wantsAnotherGame = true;
            /*
                        m_Player1.Turn = true;
                     //   Move lastMove = Move.MakeEmpty();  // We initialize it to be empty for the first iteration
                        bool inEatingSequence = false;

                        while (!gameOver(m_Player1.NumOfPawns + m_Player1.NumOfKings, m_Player2.NumOfPawns + m_Player2.NumOfKings))
                        {
                            bool playerExecutedEat = false;
                            // UI.PrintGameState(m_Player1, m_Player2, m_GameBoard, lastMove, inEatingSequence);

                            if ((m_Player1.Turn && !m_Player1.HasLegalMoves(m_GameBoard)) || (m_Player2.Turn && !m_Player2.HasLegalMoves(m_GameBoard)))
                            {
                                break;
                            }
                            else if (m_Player1.Turn)
                            {
                              //  lastMove = giveTurnTo(ref m_Player1, ref m_Player2, ref playerExecutedEat);

                               if (m_Player1.WantsToQuit(lastMove))
                                {
                                    m_Player1.NumOfPawns = m_Player1.NumOfKings = 0;
                                }

                                // This check meant to check if there is more to eat in a row
                               m_Player1.Turn = playerExecutedEat && m_Player1.CanEatMore(m_GameBoard, lastMove);
                                m_Player2.Turn = !m_Player1.Turn;
                                inEatingSequence = m_Player1.Turn;
                            }
                            else
                            {
                                lastMove = giveTurnTo(ref m_Player2, ref m_Player1, ref playerExecutedEat);

                                if (m_Player2.WantsToQuit(lastMove))
                                {
                                    m_Player2.NumOfPawns = m_Player2.NumOfKings = 0;
                                }

                                // This check meant to check if there is more to eat in a row
                                m_Player2.Turn = playerExecutedEat && m_Player2.CanEatMore(m_GameBoard, lastMove);
                                m_Player1.Turn = !m_Player2.Turn;
                                inEatingSequence = m_Player2.Turn;
                            }
                        }

                        calculateSumOfPointsForPlayers(ref m_Player1, ref m_Player2);
                        UI.PrintGameState(m_Player1, m_Player2, m_GameBoard, lastMove, inEatingSequence);
                        UI.DisplayScore(m_Player1, m_Player2);
                        bool wantsAnotherGame = UI.AskIfUserWantsAnotherGame();

                     
                    }
            */
            return wantsAnotherGame;
        }

        private void distributePawnsToPlayers(Board.eBoardDimension i_BoardDimension)
        {
            m_Player1.NumOfPawns = m_Player2.NumOfPawns = ((int)i_BoardDimension / 2) * (((int)i_BoardDimension - 2) / 2);
            m_Player1.NumOfKings = m_Player2.NumOfKings = 0;
        }


        private bool isLegalMove(Player i_Player, Move i_Move)
        {
            bool moveIsLegal;

            List<Move> possibleEatingMoves = i_Player.PossibleEatingMoves(m_GameBoard);
            List<Move> possibleNonEatingMoves = i_Player.PossibleNonEatingMoves(m_GameBoard);

            if (possibleEatingMoves.Count > 0)
            {
                moveIsLegal = isMoveInList(possibleEatingMoves, i_Move);
            }
            else if (possibleNonEatingMoves.Count > 0)
            {
                moveIsLegal = isMoveInList(possibleNonEatingMoves, i_Move);
            }
            else
            {
                moveIsLegal = false;
            }

            return  moveIsLegal;
        }

        private bool isMoveInList(List<Move> i_List, Move i_Move)
        {
            bool moveWasFound = false;

            for(int i=0; i<i_List.Count; i++)
            {
                if(i_List[i].Source.X == i_Move.Source.X && i_List[i].Source.Y == i_Move.Source.Y
                    && i_List[i].Destination.X == i_Move.Destination.X && i_List[i].Destination.Y == i_Move.Destination.Y)
                {
                    moveWasFound = true;
                    break;
                }
            }

            return moveWasFound;
        }

        private string choosePcMove(Player i_Player)
        {
            List<Move> possibleEatingMoves = i_Player.PossibleEatingMoves(m_GameBoard);
            List<Move> possibleNonEatingMoves = i_Player.PossibleNonEatingMoves(m_GameBoard);
            Random randomGenerator = new Random();

            string pcMove;
            int indexInList;

            if (possibleEatingMoves.Count > 0)
            {
                indexInList = randomGenerator.Next(possibleEatingMoves.Count);
                //       pcMove = possibleEatingMoves[indexInList];
            }
            else if (possibleNonEatingMoves.Count > 0)
            {
                indexInList = randomGenerator.Next(possibleNonEatingMoves.Count);
                //      pcMove = possibleNonEatingMoves[indexInList];
            }
            else
            {
                pcMove = "Q";
            }

            //return pcMove;
            return "ture";
        }

       
        private void giveTurnTo(ref Player io_Player, ref Player io_Opponent, ref bool io_PlayerExecutedEat, Move i_Move)
        {

            m_GameBoard.MovePawn(i_Move, io_Player);

                if (io_Player.AteOpponent(i_Move))
                {
                    int colIndexToRemove = m_GameBoard.CalculateColIndexOfCellToRemove(i_Move);
                    int rowIndexToRemove = m_GameBoard.CalculateRowIndexOfCellToRemove(i_Move);

                    if (m_GameBoard.m_Grid[rowIndexToRemove, colIndexToRemove].Sign == io_Opponent.PawnSign)
                    {
                        io_Opponent.NumOfPawns--;
                    }
                    else
                    {
                        io_Opponent.NumOfKings--;
                    }

                    m_GameBoard.m_Grid[rowIndexToRemove, colIndexToRemove].PawnInCell = false;
                    io_PlayerExecutedEat = true;
                }
                else
                {
                    io_PlayerExecutedEat = false;
                }

            }

        }
    }


/*
   private bool moveDoNotCrossBorder(string i_Move)
   {
       bool validCoordinate = i_Move.Length == 5 && i_Move.Contains(">");
       for (int i = 0; i < i_Move.Length; i++)
       {
           if (i == 2 && i_Move[i] != '>')
           {
               validCoordinate = false;
               break;
           }

           if (i == 0 || i == 3)
           {
               if (i_Move[i] < 'A' || i_Move[i] > 'A' + (int)m_GameBoard.Dimension - 1)
               {
                   validCoordinate = false;
                   break;
               }
           }
           else if (i == 1 || i == 4)
           {
               if (i_Move[i] < 'a' || i_Move[i] > 'a' + (int)m_GameBoard.Dimension - 1)
               {
                   validCoordinate = false;
                   break;
               }
           }
       }

       return validCoordinate;
   } */