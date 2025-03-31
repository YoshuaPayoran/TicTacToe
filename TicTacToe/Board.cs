using System;

namespace TicTacToe
{
    class GameBoard
    {
        public static void DrawBoard(char[] board)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Program.PrintCentered("╔═══════════╦═══════════╦═══════════╗");

            DrawBoardRow(board, 0);
            Program.PrintCentered("╠═══════════╬═══════════╬═══════════╣");

            DrawBoardRow(board, 3);
            Program.PrintCentered("╠═══════════╬═══════════╬═══════════╣");

            DrawBoardRow(board, 6);
            Program.PrintCentered("╚═══════════╩═══════════╩═══════════╝");

            Console.WriteLine();
        }

        private static void DrawBoardRow(char[] board, int startIndex)
        {
            Program.PrintCentered($"║           ║           ║           ║");
            Program.PrintCentered($"║           ║           ║           ║");
            Program.PrintCentered($"║     {board[startIndex]}     ║     {board[startIndex + 1]}     ║     {board[startIndex + 2]}     ║");
            Program.PrintCentered($"║           ║           ║           ║");
            Program.PrintCentered($"║           ║           ║           ║");
        }

        public static bool CheckWin(char[] board)
        {
            return (board[0] == board[1] && board[1] == board[2]) ||
                   (board[3] == board[4] && board[4] == board[5]) ||
                   (board[6] == board[7] && board[7] == board[8]) ||
                   (board[0] == board[3] && board[3] == board[6]) ||
                   (board[1] == board[4] && board[4] == board[7]) ||
                   (board[2] == board[5] && board[5] == board[8]) ||
                   (board[0] == board[4] && board[4] == board[8]) ||
                   (board[2] == board[4] && board[4] == board[6]);
        }

        public static bool CheckDraw(char[] board)
        {
            foreach (char c in board)
            {
                if (c != 'X' && c != 'O') return false;
            }
            return true;
        }
    }
}