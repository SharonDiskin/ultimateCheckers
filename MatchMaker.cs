using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C20_Ex02
{
    class MatchMaker
    {
        /*
        static Move nextMove;
        public static void PlayRound(Game i_Game, Damka i_Damka)
        {
            nextMove = i_Damka.GetMove();

            if (i_Game.Player1.Turn == true)
            {
                if(validMove(i_Game, i_Game.Player1, ref nextMove))
                {
                    i_Game.Board.MovePawn(nextMove, i_Game.Player1);
                    i_Damka.UpdateBoard();
                }
                else
                {
                    MessageBox.Show("Invalid Move!");
                }
                i_Game.Player1.Turn = false;
            }
        }

        private static bool legalMove(Game i_Game, Player i_Player, ref Move io_Move)
        {
            int sourceColIndex = io_Move.Source.X;
            int sourceRowIndex = io_Move.Source.Y;
            bool moveIsLegal;

            bool sourceCoordinateHavePlayerPawn = playerHasPawnInCell(i_Player, i_Game.Board.m_Grid[sourceRowIndex, sourceColIndex]);

            List<Move> possibleEatingMoves = i_Player.PossibleEatingMoves(i_Game.Board);
            List<Move> possibleNonEatingMoves = i_Player.PossibleNonEatingMoves(i_Game.Board);

            if (possibleEatingMoves.Count > 0)
            {
                moveIsLegal = possibleEatingMoves.Contains(io_Move);
            }
            else 
            {
                moveIsLegal = possibleNonEatingMoves.Contains(io_Move);
            }

            return sourceCoordinateHavePlayerPawn && moveIsLegal;
        }

        private static bool validMove(Game i_Game, Player i_Player, ref Move io_Move)
        {
            bool moveIsValid = legalMove(i_Game, i_Player, ref io_Move);

            return moveIsValid;
        }

        private static bool playerHasPawnInCell(Player i_Player, Cell i_CellInBoard)
        {
            return i_Player.PawnSign == i_CellInBoard.Sign ||
                   i_Player.KingSign == i_CellInBoard.Sign;
        }
        */
    }
}
