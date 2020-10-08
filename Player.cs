using System;
using System.Collections.Generic;
using System.Drawing;

namespace C20_Ex02
{
    public class Player
    {
        private readonly Cell.eCellSign r_PawnSign;
        private readonly Cell.eCellSign r_KingSign;
        private string m_Name;
        private int m_NumOfPawns;
        private int m_NumOfKings;
        private int m_AccumulatedPoints;
        private bool m_Turn;

        public Player(string i_PlayerName, int i_NumOfPawns, Cell.eCellSign i_PawnSign, Cell.eCellSign i_KingSign)
        {
            m_Name = i_PlayerName;
            m_NumOfPawns = i_NumOfPawns;
            r_PawnSign = i_PawnSign;
            r_KingSign = i_KingSign;
            m_AccumulatedPoints = 0;
            m_Turn = false;
        }

        public enum eMove
        {
            Right = 1,
            Left = -1,
            Up = -1,
            Down = 1,
            DoubleRight = 2,
            DoubleLeft = -2,
            DoubleUp = -2,
            DoubleDown = 2,
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public int NumOfPawns
        {
            get
            {
                return m_NumOfPawns;
            }

            set
            {
                m_NumOfPawns = value;
            }
        }

        public int NumOfKings
        {
            get
            {
                return m_NumOfKings;
            }

            set
            {
                m_NumOfKings = value;
            }
        }

        public int NumOfPoints
        {
            get
            {
                return m_AccumulatedPoints;
            }

            set
            {
                m_AccumulatedPoints = value;
            }
        }

        public bool Turn
        {
            get
            {
                return m_Turn;
            }

            set
            {
                m_Turn = value;
            }
        }

        public Cell.eCellSign PawnSign
        {
            get
            {
                return r_PawnSign;
            }
        }

        public Cell.eCellSign KingSign
        {
            get
            {
                return r_KingSign;
            }
        }

        public bool AteOpponent(Move i_Move)
        {
            // The logic behind the function is to see if the difference between both row coordinated is 2 in absolute value
            // If the answer is yes we know we skipped over rival tool
            return Math.Abs(i_Move.Source.X - i_Move.Destination.X) == 2;
        }

        public bool WantsToQuit(string i_Move)
        {
            return i_Move == "Q";
        }

        private List<Move> possibleNoneEatingMovesForPlayerX(Board i_Board)
        {
            List<Move> possibleMoves = new List<Move>();

            for (int rowIndex = 0; rowIndex < (int)i_Board.Dimension; rowIndex++)
            {
                for (int colIndex = 0; colIndex < (int)i_Board.Dimension; colIndex++)
                {
                    Cell curCell = i_Board.m_Grid[rowIndex, colIndex];

                    // The following checks meant to check if there are legal moves for PlayerX (forward or backward)
                    if ((curCell.Sign == Cell.eCellSign.PawnX || curCell.Sign == Cell.eCellSign.KingX) &&
                        isEmptyCellInBorder(rowIndex + (int) eMove.Up, colIndex + (int) eMove.Right, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.Right, eMove.Up);
                    }

                    if ((curCell.Sign == Cell.eCellSign.PawnX || curCell.Sign == Cell.eCellSign.KingX) &&
                        isEmptyCellInBorder(rowIndex + (int)eMove.Up, colIndex + (int)eMove.Left, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.Left, eMove.Up);
                    }

                    if(curCell.Sign == Cell.eCellSign.KingX
                       && isEmptyCellInBorder(rowIndex + (int)eMove.Down, colIndex + (int)eMove.Right, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.Right, eMove.Down);
                    }

                    if (curCell.Sign == Cell.eCellSign.KingX
                        && isEmptyCellInBorder(rowIndex + (int)eMove.Down, colIndex + (int)eMove.Left, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.Left, eMove.Down);
                    }
                }
            }

            return possibleMoves;
        }

        private List<Move> possibleNoneEatingMovesForPlayerO(Board i_Board)
        {
            List<Move> possibleMoves = new List<Move>();

            for (int rowIndex = 0; rowIndex < (int)i_Board.Dimension; rowIndex++)
            {
                for (int colIndex = 0; colIndex < (int)i_Board.Dimension; colIndex++)
                {
                    Cell curCell = i_Board.m_Grid[rowIndex, colIndex];

                    // The following checks meant to check if there are legal moves for PlayerO (forward or backward)
                    if ((curCell.Sign == Cell.eCellSign.PawnO || curCell.Sign == Cell.eCellSign.KingO)
                        && isEmptyCellInBorder(rowIndex + (int)eMove.Down, colIndex + (int)eMove.Right, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.Right, eMove.Down);
                    }

                    if ((curCell.Sign == Cell.eCellSign.PawnO || curCell.Sign == Cell.eCellSign.KingO)
                        && isEmptyCellInBorder(rowIndex + (int)eMove.Down, colIndex + (int)eMove.Left, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.Left, eMove.Down);
                    }

                    if (curCell.Sign == Cell.eCellSign.KingO
                        && isEmptyCellInBorder(rowIndex + (int)eMove.Up, colIndex + (int)eMove.Right, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.Right, eMove.Up);
                    }

                    if (curCell.Sign == Cell.eCellSign.KingO 
                        && isEmptyCellInBorder(rowIndex + (int)eMove.Up, colIndex + (int)eMove.Left, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.Left, eMove.Up);
                    }
                }
            }

            return possibleMoves;
        }

        public List<Move> PossibleNonEatingMoves(Board i_Board)
        {
            List<Move> possibleMoves;

            if (r_PawnSign == Cell.eCellSign.PawnX)
            {
                possibleMoves = possibleNoneEatingMovesForPlayerX(i_Board);
            }
            else
            {
                possibleMoves = possibleNoneEatingMovesForPlayerO(i_Board);
            }

            return possibleMoves;
        }

        private List<Move> possibleEatingMovesForPlayerO(Board i_Board)
        {
            List<Move> possibleMoves = new List<Move>();

            for (int rowIndex = 0; rowIndex < (int)i_Board.Dimension; rowIndex++)
            {
                for (int colIndex = 0; colIndex < (int)i_Board.Dimension; colIndex++)
                {
                    Cell curCell = i_Board.m_Grid[rowIndex, colIndex];

                    // The following checks meant to check if there is something to eat in each of the diagonals (forward or backward)
                    if ((curCell.Sign == Cell.eCellSign.PawnO || curCell.Sign == Cell.eCellSign.KingO)
                        && cellWithRivalPawnInBorder(rowIndex + (int)eMove.Down, colIndex + (int)eMove.Left, i_Board)
                        && isEmptyCellInBorder(rowIndex + (int)eMove.DoubleDown, colIndex + (int)eMove.DoubleLeft, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.DoubleLeft, eMove.DoubleDown);
                    }

                    if ((curCell.Sign == Cell.eCellSign.PawnO || curCell.Sign == Cell.eCellSign.KingO)
                        && cellWithRivalPawnInBorder(rowIndex + (int)eMove.Down, colIndex + (int)eMove.Right, i_Board)
                        && isEmptyCellInBorder(rowIndex + (int)eMove.DoubleDown, colIndex + (int)eMove.DoubleRight, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.DoubleRight, eMove.DoubleDown);
                    }

                    if (curCell.Sign == Cell.eCellSign.KingO
                        && cellWithRivalPawnInBorder(rowIndex + (int)eMove.Up, colIndex + (int)eMove.Right, i_Board)
                        && isEmptyCellInBorder(rowIndex + (int)eMove.DoubleUp, colIndex + (int)eMove.DoubleRight, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.DoubleRight, eMove.DoubleUp);
                    }

                    if (curCell.Sign == Cell.eCellSign.KingO
                        && cellWithRivalPawnInBorder(rowIndex + (int)eMove.Up, colIndex + (int)eMove.Left, i_Board)
                        && isEmptyCellInBorder(rowIndex + (int)eMove.DoubleUp, colIndex + (int)eMove.DoubleLeft, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.DoubleLeft, eMove.DoubleUp);
                    }
                }
            }

            return possibleMoves;
        }

        private List<Move> possibleEatingMovesForPlayerX(Board i_Board)
        {
            List<Move> possibleMoves = new List<Move>();

            for (int rowIndex = 0; rowIndex < (int)i_Board.Dimension; rowIndex++)
            {
                for (int colIndex = 0; colIndex < (int)i_Board.Dimension; colIndex++)
                {
                    Cell curCell = i_Board.m_Grid[rowIndex, colIndex];

                    // The following checks meant to check if there is something to eat in each of the diagonals (forward or backward)
                    if ((curCell.Sign == Cell.eCellSign.PawnX || curCell.Sign == Cell.eCellSign.KingX)
                        && cellWithRivalPawnInBorder(rowIndex + (int)eMove.Up, colIndex + (int)eMove.Right, i_Board)
                        && isEmptyCellInBorder(rowIndex + (int)eMove.DoubleUp, colIndex + (int)eMove.DoubleRight, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.DoubleRight, eMove.DoubleUp);
                    }

                    if ((curCell.Sign == Cell.eCellSign.PawnX || curCell.Sign == Cell.eCellSign.KingX)
                        && cellWithRivalPawnInBorder(rowIndex + (int)eMove.Up, colIndex + (int)eMove.Left, i_Board)
                        && isEmptyCellInBorder(rowIndex + (int)eMove.DoubleUp, colIndex + (int)eMove.DoubleLeft, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.DoubleLeft, eMove.DoubleUp);
                    }

                    if (curCell.Sign == Cell.eCellSign.KingX 
                        && cellWithRivalPawnInBorder(rowIndex + (int)eMove.Down, colIndex + (int)eMove.Left, i_Board) 
                        && isEmptyCellInBorder(rowIndex + (int)eMove.DoubleDown, colIndex + (int)eMove.DoubleLeft, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.DoubleLeft, eMove.DoubleDown);
                    }

                    if (curCell.Sign == Cell.eCellSign.KingX
                        && cellWithRivalPawnInBorder(rowIndex + (int)eMove.Down, colIndex + (int)eMove.Right, i_Board)
                        && isEmptyCellInBorder(rowIndex + (int)eMove.DoubleDown, colIndex + (int)eMove.DoubleRight, i_Board))
                    {
                        addMoveToMovesList(ref possibleMoves, colIndex, rowIndex, eMove.DoubleRight, eMove.DoubleDown);
                    }
                }
            }

            return possibleMoves;
        }

        public List<Move> PossibleEatingMoves(Board i_Board)
        {
            List<Move> possibleMoves;

            if (r_PawnSign == Cell.eCellSign.PawnX)
            {
                possibleMoves = possibleEatingMovesForPlayerX(i_Board);
            }
            else
            {
                possibleMoves = possibleEatingMovesForPlayerO(i_Board);
            }

            return possibleMoves;
        }

        public bool CanEatMore(Board i_Board, Move i_Move)
        {
            int coordinateColIndex = i_Move.Source.X;
            int coordinateRowIndex = i_Move.Source.Y;
            Cell curCell = i_Board.m_Grid[coordinateRowIndex, coordinateColIndex];
            bool canEatMore = false;

            // This check meant to check if there is something to eat in each of the diagonals (forward or backward)
            if ((isKingInCell(curCell) || curCell.Sign == Cell.eCellSign.PawnX)
                && cellWithRivalPawnInBorder(coordinateRowIndex + (int)eMove.Up, coordinateColIndex + (int)eMove.Right, i_Board)
                && isEmptyCellInBorder(coordinateRowIndex + (int)eMove.DoubleUp, coordinateColIndex + (int)eMove.DoubleRight, i_Board))
            {
                canEatMore = true;
            }
            else if ((isKingInCell(curCell) || curCell.Sign == Cell.eCellSign.PawnX)
                     && cellWithRivalPawnInBorder(coordinateRowIndex + (int)eMove.Up, coordinateColIndex + (int)eMove.Left, i_Board)
                     && isEmptyCellInBorder(coordinateRowIndex + (int)eMove.DoubleUp, coordinateColIndex + (int)eMove.DoubleLeft, i_Board))
            {
                canEatMore = true;
            }
            else if ((isKingInCell(curCell) || curCell.Sign == Cell.eCellSign.PawnO)
                     && cellWithRivalPawnInBorder(coordinateRowIndex + (int)eMove.Down, coordinateColIndex + (int)eMove.Left, i_Board)
                     && isEmptyCellInBorder(coordinateRowIndex + (int)eMove.DoubleDown, coordinateColIndex + (int)eMove.DoubleLeft, i_Board))
            {
                canEatMore = true;
            }
            else if ((isKingInCell(curCell) || curCell.Sign == Cell.eCellSign.PawnO)
                     && cellWithRivalPawnInBorder(coordinateRowIndex + (int)eMove.Down, coordinateColIndex + (int)eMove.Right, i_Board)
                     && isEmptyCellInBorder(coordinateRowIndex + (int)eMove.DoubleDown, coordinateColIndex + (int)eMove.DoubleRight, i_Board))
            {
                canEatMore = true;
            }

            return canEatMore;
        }

        public bool HasLegalMoves(Board i_Board)
        {
            return PossibleEatingMoves(i_Board).Count > 0 || PossibleNonEatingMoves(i_Board).Count > 0;
        }

        private void addMoveToMovesList(ref List<Move> io_MovesList, int i_ColNum, int i_RowNum, eMove i_MoveInCol, eMove i_MoveInRow)
        {
            Point Source = new Point(i_ColNum, i_RowNum);
            Point Dest = new Point(i_ColNum + (int)i_MoveInCol, i_RowNum + (int) i_MoveInRow);
            Move validMove = new Move(Source, Dest);
            io_MovesList.Add(validMove);
        }

        private bool coordinateInBorder(int i_CoordinateRowIndex, int i_CoordinateColIndex, Board i_Board)
        {
            return i_CoordinateRowIndex >= 0 && i_CoordinateColIndex >= 0
                                             && i_CoordinateRowIndex <= (int)i_Board.Dimension - 1 
                                             && i_CoordinateColIndex <= (int)i_Board.Dimension - 1;
        }

        private bool cellWithRivalPawnInBorder(int i_CoordinateRowIndex, int i_CoordinateColIndex, Board i_Board)
        {
            bool hasRivalPawnInCellInBorder;

            // The cell is out of border, thus there is no rival pawn in this cell
            if (!coordinateInBorder(i_CoordinateRowIndex, i_CoordinateColIndex, i_Board))
            {
                hasRivalPawnInCellInBorder = false;
            }
            else
            {
                if (r_PawnSign == Cell.eCellSign.PawnO)
                {
                    hasRivalPawnInCellInBorder = i_Board.m_Grid[i_CoordinateRowIndex, i_CoordinateColIndex].Sign == Cell.eCellSign.PawnX
                                                 || i_Board.m_Grid[i_CoordinateRowIndex, i_CoordinateColIndex].Sign == Cell.eCellSign.KingX;
                }
                else
                {
                    hasRivalPawnInCellInBorder = i_Board.m_Grid[i_CoordinateRowIndex, i_CoordinateColIndex].Sign == Cell.eCellSign.PawnO
                                                 || i_Board.m_Grid[i_CoordinateRowIndex, i_CoordinateColIndex].Sign == Cell.eCellSign.KingO;
                }
            }

            return hasRivalPawnInCellInBorder;
        }

        private bool isEmptyCellInBorder(int i_CoordinateRowIndex, int i_CoordinateColIndex, Board i_Board)
        {
            return coordinateInBorder(i_CoordinateRowIndex, i_CoordinateColIndex, i_Board)
                   && i_Board.m_Grid[i_CoordinateRowIndex, i_CoordinateColIndex].Sign == Cell.eCellSign.Empty;
        }

        private bool isKingInCell(Cell i_Cell)
        {
            return i_Cell.Sign == Cell.eCellSign.KingX || i_Cell.Sign == Cell.eCellSign.KingO;
        }
    }
}