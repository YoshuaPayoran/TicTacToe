using System;

namespace TicTacToe
{
    class HowToPlay
    {
        public static void ShowInstructions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintCentered("██╗  ██╗ ██████╗ ██╗    ██╗    ████████╗ ██████╗     ██████╗ ██╗      █████╗ ██╗   ██╗ ");
            Program.PrintCentered("██║  ██║██╔═══██╗██║    ██║    ╚══██╔══╝██╔═══██╗    ██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝ ");
            Program.PrintCentered("███████║██║   ██║██║ █╗ ██║       ██║   ██║   ██║    ██████╔╝██║     ███████║ ╚████╔╝  ");
            Program.PrintCentered("██╔══██║██║   ██║██║███╗██║       ██║   ██║   ██║    ██╔═══╝ ██║     ██╔══██║  ╚██╔╝   ");
            Program.PrintCentered("██║  ██║╚██████╔╝╚███╔███╔╝       ██║   ╚██████╔╝    ██║     ███████╗██║  ██║   ██║    ");
            Program.PrintCentered("╚═╝  ╚═╝ ╚═════╝  ╚══╝╚══╝        ╚═╝    ╚═════╝     ╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. The Game Board:");
            Console.WriteLine("   - 3x3 grid (9 squares numbered 1-9)");
            Console.WriteLine("   - Example:");
            Console.WriteLine("       1 | 2 | 3");
            Console.WriteLine("      -----------");
            Console.WriteLine("       4 | 5 | 6");
            Console.WriteLine("      -----------");
            Console.WriteLine("       7 | 8 | 9");
            Console.WriteLine();

            Console.WriteLine("2. Players:");
            Console.WriteLine("   - Player 1: X");
            Console.WriteLine("   - Player 2/Computer: O");
            Console.WriteLine();

            Console.WriteLine("3. Gameplay Rules:");
            Console.WriteLine("   - Take turns entering a number (1-9)");
            Console.WriteLine("   - Choose an empty square to place your mark");
            Console.WriteLine("   - First to get 3 marks in a row wins the round");
            Console.WriteLine("     • Row: 1-2-3, 4-5-6, or 7-8-9");
            Console.WriteLine("     • Column: 1-4-7, 2-5-8, or 3-6-9");
            Console.WriteLine("     • Diagonal: 1-5-9 or 3-5-7");
            Console.WriteLine();

            Console.WriteLine("4. Match Rules:");
            Console.WriteLine("   - You'll choose a 'Race to X' wins at start");
            Console.WriteLine("   - First player to win X rounds wins the match");
            Console.WriteLine("   - Example: 'Race to 3' means first to win 3 rounds");
            Console.WriteLine();

            Console.WriteLine("5. Game Controls:");
            Console.WriteLine("   - During game: Press 0 to return to menu");
            Console.WriteLine("   - After each round: Continue automatically");
            Console.WriteLine("   - Match ends when a player reaches the target wins");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Program.PrintCentered("Press any key to return to menu...");
            Console.ResetColor();
            Console.ReadKey();
            Program.Main();
        }
    }
}
