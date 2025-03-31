using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {

        private static readonly ConsoleColor[] colors = {
            ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green,
            ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.Magenta
        };

        public static void PrintWriteCentered(string text)
        {
            int windowWidth = Console.WindowWidth;
            int centeredPosition = (windowWidth - text.Length) / 2;
            Console.SetCursorPosition(Math.Max(centeredPosition, 0), Console.CursorTop);
            Console.Write(text);
        }

        public static void PrintTextCentered(string text, ConsoleColor color)
        {
            int windowWidth = Console.WindowWidth;
            int centeredPosition = (windowWidth - text.Length) / 2;
            Console.SetCursorPosition(Math.Max(centeredPosition, 0), Console.CursorTop);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintCentered(string text)
        {
            int windowWidth = Console.WindowWidth;
            int centeredPosition = (windowWidth - text.Length) / 2;
            Console.SetCursorPosition(Math.Max(centeredPosition, 0), Console.CursorTop);
            Console.WriteLine(text);
        }

        public static void Main()
        {
            Console.Title = "Tic Tac Toe - Midterm Project";
            ShowMainMenu();
        }

        public static void ShowMainMenu()
        {
            Console.Clear();
            AnimateTitle(); 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            PrintCentered("█▀  ▀█  ▀█  █▀█ █   █▀█ █ █   █▀▀ █▀█ █▄█ █▀▀  ");
            PrintCentered("█    █   █  █▀▀ █   █▀█  █    █ █ █▀█ █ █ █▀▀  ");
            PrintCentered("▀▀  ▀▀▀ ▀▀  ▀   ▀▀▀ ▀ ▀  ▀    ▀▀▀ ▀ ▀ ▀ ▀ ▀▀▀  ");
            Console.WriteLine();
            PrintCentered("█▀  ▀▀▄ ▀█  █ █ █▀█ █ █   ▀█▀ █▀█   █▀█ █   █▀█ █ █ ");
            PrintCentered("█   ▄▀   █  █▀█ █ █ █▄█    █  █ █   █▀▀ █   █▀█  █  ");
            PrintCentered("▀▀  ▀▀▀ ▀▀  ▀ ▀ ▀▀▀ ▀ ▀    ▀  ▀▀▀   ▀   ▀▀▀ ▀ ▀  ▀  ");
            Console.WriteLine();
            PrintCentered("█▀  ▀▀█ ▀█  █▀▄ █▀▀ █ █ █▀▀ █   █▀█ █▀█ █▀▀ █▀▄ █▀▀ ");
            PrintCentered("█    ▀▄  █  █ █ █▀▀ ▀▄▀ █▀▀ █   █ █ █▀▀ █▀▀ █▀▄ ▀▀█ ");
            PrintCentered("▀▀  ▀▀  ▀▀  ▀▀  ▀▀▀  ▀  ▀▀▀ ▀▀▀ ▀▀▀ ▀   ▀▀▀ ▀ ▀ ▀▀▀ ");
            Console.WriteLine();
            PrintCentered("█▀  █ █ ▀█  █▀▀ █ █ ▀█▀ ▀█▀ ");
            PrintCentered("█    ▀█  █  █▀▀ ▄▀▄  █   █  ");
            PrintCentered("▀▀    ▀ ▀▀  ▀▀▀ ▀ ▀ ▀▀▀  ▀  ");
            Console.WriteLine();
            Program.PrintWriteCentered("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlayGame.Start();
                    break;
                case "2":
                    HowToPlay.ShowInstructions();
                    break;
                case "3":
                    Developers.ShowInfo();
                    break;
                case "4":
                    ConfirmExit();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Press any key to try again...");
                    Console.ReadKey();
                    ShowMainMenu();
                    break;
            }
        }

        private static void AnimateTitle()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                DrawTitle(colors[i % colors.Length]);
                Thread.Sleep(300); 
            }
        }

        private static void DrawTitle(ConsoleColor color)
        {
            PrintTextCentered("████████╗██╗ ██████╗    ████████╗ █████╗  ██████╗    ████████╗ ██████╗ ███████╗", color);
            PrintTextCentered("╚══██╔══╝██║██╔════╝    ╚══██╔══╝██╔══██╗██╔════╝    ╚══██╔══╝██╔═══██╗██╔════╝", color);
            PrintTextCentered("   ██║   ██║██║            ██║   ███████║██║            ██║   ██║   ██║█████╗  ", color);
            PrintTextCentered("   ██║   ██║██║            ██║   ██╔══██║██║            ██║   ██║   ██║██╔══╝  ", color);
            PrintTextCentered("   ██║   ██║╚██████╗       ██║   ██║  ██║╚██████╗       ██║   ╚██████╔╝███████╗", color);
            PrintTextCentered("   ╚═╝   ╚═╝ ╚═════╝       ╚═╝   ╚═╝  ╚═╝ ╚═════╝       ╚═╝    ╚═════╝ ╚══════╝", color);
        }

        static void ConfirmExit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Are you sure you want to exit? (y/n): ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y") Environment.Exit(0);
            else ShowMainMenu();
        }
    }
}
