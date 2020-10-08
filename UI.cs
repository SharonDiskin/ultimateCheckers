using System;

namespace C20_Ex02
{ 
    public class UI
    {
        private static readonly string sr_InvalidUserName = @"Invalid username...
A valid username doesn't contains spaces and its length is maximum 20.
Please Try Again";

        private static readonly string sr_InvalidChoice = "Invalid choice... Please try Again";
        private enum eOpponentOptions
        {
            PC = 1,
            Human = 2
        }

        private enum eContinueOptions
        {
            Yes = 1,
            No = 2
        }

        public static string AskUserName()
        {
            Console.Write("What is your name? ");
            string name;
            do
            {
                name = Console.ReadLine();
            }
            while (!validUserName(name));

            return name;
        }

        public static string AskOpponentUserName()
        {
            Console.Write("What is the opponent's name? ");
            string name;
            do
            {
                name = Console.ReadLine();
            }
            while (!validUserName(name));

            return name;
        }

        public static void WelcomePlayer(string i_UserName)
        {
            string welcomeMessage = string.Format("Welcome {0} and have a good luck!", i_UserName);
            Console.WriteLine(welcomeMessage);
        }

        private static bool validUserName(string i_UserName)
        {
            bool validName = 
                i_UserName.Length <= 20 && 
                i_UserName.Length > 0 && 
                !i_UserName.Contains(" ") && 
                i_UserName != "PC";
            if (!validName)
            {
                Console.WriteLine(UI.sr_InvalidUserName);
            }

            return validName;
        }

        public static Board.eBoardDimension AskBoardDimension()
        {
            int dimension;
            string digit;
            do
            {
                Console.Write("Please enter board dimension (6/8/10): ");
                digit = Console.ReadLine();
            }
            while (!validDimension(digit));

            dimension = int.Parse(digit);
            return (Board.eBoardDimension)dimension;
        }

        private static bool validDimension(string i_Dimension)
        {
            bool valid = i_Dimension == $"{(int)Board.eBoardDimension.Small}" ||
                         i_Dimension == $"{(int)Board.eBoardDimension.Medium}" || 
                         i_Dimension == $"{(int)Board.eBoardDimension.Large}";
            if (!valid)
            {
                Console.WriteLine(sr_InvalidChoice);
            }

            return valid;
        }

        private static bool isValidOpponentChoice(string i_Choice)
        {
            int choice;
            bool isInt, isValidInput;

            isInt = int.TryParse(i_Choice, out choice);
            if(!isInt)
            {
                isValidInput = false;
            }
            else
            {
                isValidInput = choice == (int)eOpponentOptions.PC || choice == (int)eOpponentOptions.Human;
            }

            if (!isValidInput)
            {
                Console.WriteLine(UI.sr_InvalidChoice);
            }
        
            return isValidInput;
        }

        private static bool isValidContinueChoice(string i_Choice)
        {
            int choice;
            bool isInt, isValidInput;

            isInt = int.TryParse(i_Choice, out choice);
            if (!isInt)
            {
                isValidInput = false;
            }
            else
            {
                isValidInput = choice == (int)eContinueOptions.Yes || choice == (int)eContinueOptions.No;
            }

            if (!isValidInput)
            {
                Console.WriteLine(UI.sr_InvalidChoice);
            }

            return isValidInput;
        }

        public static int AskForOpponent()
        {
            string choiceAsString;

            Console.Write(
@"Who will be your opponent for this game ?
1. PC
2. Another Player
");
            do
            { 
                choiceAsString = Console.ReadLine();
            }
            while (!isValidOpponentChoice(choiceAsString));

            return int.Parse(choiceAsString);
        }

        public static bool AskIfUserWantsAnotherGame()
        {
            Console.WriteLine(
@"Do you want another game with this opponent?
1. Yes
2. No");
            string strChoice;
            int choice;
            do
            {
                strChoice = Console.ReadLine();
            }
            while (!isValidContinueChoice(strChoice));

            choice = int.Parse(strChoice);

            return choice == (int)eContinueOptions.Yes;
        }

        public static void GoodBye()
        {
            Console.WriteLine("It was a pleasure :) Goodbye!");
        }

        public static void DisplayScore(Player i_Player1, Player i_Player2)
        {
            string message = 
$@"The game has ended :)
The points are:
{i_Player1.Name} has: {i_Player1.NumOfPoints} points
{i_Player2.Name} has: {i_Player2.NumOfPoints} points";

            Console.WriteLine(message);
        }

        public static void PromptTurn(string i_PlayerName)
        {
            string toPrint = $"{i_PlayerName}'s turn: ";
            Console.Write(toPrint);
        }

        public static void PrintInvalidMove()
        {
            Console.WriteLine("Invalid move..Try Again");
        }

        public static void PrintLastMove(Player i_Player1, Player i_Player2, string i_PlayerMove, bool i_InEatingSequence)
        {
            if (i_PlayerMove.Length == 0)
            {
                return;
            }

            string message;

            if (i_InEatingSequence)
            {
                message = string.Format(
                    "{0}'s move was ({1}): {2}",
                    i_Player1.Turn ? i_Player1.Name : i_Player2.Name,
                    i_Player1.Turn ? i_Player1.PawnSign : i_Player2.PawnSign,
                    i_PlayerMove);
            }
            else
            {
                message = string.Format(
                    "{0}'s move was ({1}): {2}",
                    i_Player1.Turn ? i_Player2.Name : i_Player1.Name,
                    i_Player1.Turn ? i_Player2.PawnSign : i_Player1.PawnSign,
                    i_PlayerMove);
            }

            Console.WriteLine(message);
        }

        public static void PrintGameState(Player io_Player1, Player io_Player2, Board io_GameBoard, string i_LastMove, bool i_inEatingSequence)
        {
            Console.Clear();
            printBoard(io_GameBoard);
            PrintLastMove(io_Player1, io_Player2, i_LastMove, i_inEatingSequence); 
        }

        private static void printBoard(Board i_Board)
        {
            int numOfSeparatorsSign = printRowWithCapitalLetters(i_Board.Dimension);
            int numOfSeparatorLinesToPrint = (int)i_Board.Dimension + 1;
            int numOfPrintedLetter = 0;
            bool needToPrintSeparatorLine = true;

            while (numOfSeparatorLinesToPrint > 0)
            {
                if (needToPrintSeparatorLine)
                {
                    printSeparatorLine(numOfSeparatorsSign);
                    needToPrintSeparatorLine = false;
                    numOfSeparatorLinesToPrint--;
                }
                else
                {
                    printBoardRow((char)('a' + numOfPrintedLetter), numOfPrintedLetter, i_Board);
                    needToPrintSeparatorLine = true;
                    numOfPrintedLetter++;
                }
            }

            printRowWithCapitalLetters(i_Board.Dimension);
        }

        private static void printSeparatorLine(int i_NumOfSignToPrint)
        {
            Console.Write(" ");
            for (int i = 0; i < i_NumOfSignToPrint; i++)
            {
                if (i < i_NumOfSignToPrint - 1)
                {
                    Console.Write('=');
                }
                else
                {
                    Console.WriteLine('=');
                }
            }
        }

        private static int printRowWithCapitalLetters(Board.eBoardDimension i_Dimension)
        {
            Console.Write("  "); // We need it for the separation with the column

            int lengthOfSeparatorRow = 1;

            for (int i = 0; i < (int)i_Dimension; i++)
            {
                char letter = (char)('A' + i);
                string letterToPrint = string.Format(" {0}  ", letter);

                if (i < (int)i_Dimension - 1)
                {
                    Console.Write(letterToPrint);
                }
                else
                {
                    Console.WriteLine(letterToPrint);
                }

                lengthOfSeparatorRow += letterToPrint.Length;
            }

            return lengthOfSeparatorRow;
        }

        private static void printBoardRow(char i_LetterForRow, int i_RowNumber, Board i_Board)
        {
            Console.Write(i_LetterForRow);
            for (int i = 0; i < (int)i_Board.Dimension; i++)
            {
                Console.Write("|" + " " + (char)i_Board.m_Grid[i_RowNumber, i].Sign + " ");
            }

            Console.WriteLine("|" + i_LetterForRow);
        }
    }
}
