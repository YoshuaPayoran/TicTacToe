using System;


namespace TicTacToe
{
    class PlayGame
    {
        public static void Start()
        {
            Console.Clear();
            DrawGameModeTitle();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Program.PrintCentered("█▀  ▀█  ▀█  █▀█ █   █▀█ █ █ █▀▀ █▀▄   █ █ █▀▀   █▀█ █   █▀█ █▀▀ █▀▄   ▄▀ █▀█ █ █ █▀█ ▀▄  ");
            Program.PrintCentered("█    █   █  █▀▀ █   █▀█  █  █▀▀ █▀▄   ▀▄▀ ▀▀█   █▀▀ █   █▀█ █▀▀ █▀▄   █  █▀▀ ▀▄▀ █▀▀  █  ");
            Program.PrintCentered("▀▀  ▀▀▀ ▀▀  ▀   ▀▀▀ ▀ ▀  ▀  ▀▀▀ ▀ ▀    ▀  ▀▀▀   ▀   ▀▀▀ ▀ ▀ ▀▀▀ ▀ ▀    ▀ ▀    ▀  ▀   ▀   ");
            Console.WriteLine();
            Program.PrintCentered("█▀  ▀▀▄ ▀█  █▀█ █   █▀█ █ █ █▀▀ █▀▄   █ █ █▀▀   █▀▀ █▀█ █▄█ █▀█ █ █ ▀█▀ █▀▀ █▀▄   ▄▀  █▀█ █ █ █▀▀ █▀█ █▄█ █▀█ ▀▄  ");
            Program.PrintCentered("█   ▄▀   █  █▀▀ █   █▀█  █  █▀▀ █▀▄   ▀▄▀ ▀▀█   █   █ █ █ █ █▀▀ █ █  █  █▀▀ █▀▄   █   █▀▀ ▀▄▀ █   █ █ █ █ █▀▀  █  ");
            Program.PrintCentered("▀▀  ▀▀▀ ▀▀  ▀   ▀▀▀ ▀ ▀  ▀  ▀▀▀ ▀ ▀    ▀  ▀▀▀   ▀▀▀ ▀▀▀ ▀ ▀ ▀   ▀▀▀  ▀  ▀▀▀ ▀ ▀    ▀  ▀    ▀  ▀▀▀ ▀▀▀ ▀ ▀ ▀   ▀   ");
            Console.WriteLine();
            Program.PrintCentered("█▀  ▀▀█ ▀█  █▀▄ █▀█ █▀▀ █ █   ▀█▀ █▀█   █▄█ █▀█ ▀█▀ █▀█   █▄█ █▀▀ █▀█ █ █ ");
            Program.PrintCentered("█    ▀▄  █  █▀▄ █▀█ █   █▀▄    █  █ █   █ █ █▀█  █  █ █   █ █ █▀▀ █ █ █ █ ");
            Program.PrintCentered("▀▀  ▀▀  ▀▀  ▀▀  ▀ ▀ ▀▀▀ ▀ ▀    ▀  ▀▀▀   ▀ ▀ ▀ ▀ ▀▀▀ ▀ ▀   ▀ ▀ ▀▀▀ ▀ ▀ ▀▀▀ ");
            Console.WriteLine();

            Program.PrintWriteCentered("Choose a mode: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PvsP.PlayerVsPlayer();
                    break;
                case "2":
                    PlayerVsComp.PlayerVsComputer();
                    break;
                case "3":
                    Program.Main();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Press any key to try again...");
                    Console.ReadKey();
                    Start();
                    break;
            }
        }

        private static void DrawGameModeTitle()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintCentered(" ██████╗  █████╗ ███╗   ███╗███████╗    ███╗   ███╗ ██████╗ ██████╗ ███████╗");
            Program.PrintCentered("██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ████╗ ████║██╔═══██╗██╔══██╗██╔════╝");
            Program.PrintCentered("██║  ███╗███████║██╔████╔██║█████╗      ██╔████╔██║██║   ██║██║  ██║█████╗  ");
            Program.PrintCentered("██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║╚██╔╝██║██║   ██║██║  ██║██╔══╝  ");
            Program.PrintCentered("╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ██║ ╚═╝ ██║╚██████╔╝██████╔╝███████╗");
            Program.PrintCentered(" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝    ╚═╝     ╚═╝ ╚═════╝ ╚═════╝ ╚══════╝");
            Console.ResetColor();
        }

    }
}
