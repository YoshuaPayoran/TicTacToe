using System;

namespace TicTacToe
{
    class PlayerVsComp
    {
        private static string playerName = "";
        private static int raceTo = 0;
        private static int playerScore = 0;
        private static int computerScore = 0;
        private static char currentPlayerMark = 'X';
        private static Difficulty currentDifficulty = Difficulty.Easy;

        public static void PlayerVsComputer()
        {
            Console.Clear();
            PvCompHeader();

            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Program.PrintWriteCentered("Enter Your Name: ");
            playerName = Console.ReadLine();

            SelectDifficulty();

            GetRaceToOption();

            WelcomePlayer();
            StartGameSession();
        }

        private static void SelectDifficulty()
        {
            Console.Clear();
            PvCompHeader();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Program.PrintCentered("█▀  ▀█  ▀█  █▀▀ █▀█ █▀▀ █ █   █▄█ █▀█ █▀▄ █▀▀ ");
            Program.PrintCentered("█    █   █  █▀▀ █▀█ ▀▀█  █    █ █ █ █ █ █ █▀▀ ");
            Program.PrintCentered("▀▀  ▀▀▀ ▀▀  ▀▀▀ ▀ ▀ ▀▀▀  ▀    ▀ ▀ ▀▀▀ ▀▀  ▀▀▀ ");
            Console.WriteLine();
            Program.PrintCentered("█▀  ▀▀▄ ▀█  █▄█ █▀▀ █▀▄ ▀█▀ █ █ █▄█   █▄█ █▀█ █▀▄ █▀▀ ");
            Program.PrintCentered("█   ▄▀   █  █ █ █▀▀ █ █  █  █ █ █ █   █ █ █ █ █ █ █▀▀ ");
            Program.PrintCentered("▀▀  ▀▀▀ ▀▀  ▀ ▀ ▀▀▀ ▀▀  ▀▀▀ ▀▀▀ ▀ ▀   ▀ ▀ ▀▀▀ ▀▀  ▀▀▀ ");
            Console.WriteLine();
            Program.PrintCentered("█▀  ▀▀█ ▀█  █ █ █▀█ █▀▄ █▀▄   █▄█ █▀█ █▀▄ █▀▀ ");
            Program.PrintCentered("█    ▀▄  █  █▀█ █▀█ █▀▄ █ █   █ █ █ █ █ █ █▀▀ ");
            Program.PrintCentered("▀▀  ▀▀  ▀▀  ▀ ▀ ▀ ▀ ▀ ▀ ▀▀    ▀ ▀ ▀▀▀ ▀▀  ▀▀▀ ");
            Console.WriteLine();

            while (true)
            {
                Program.PrintWriteCentered("Choose difficulty (1-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        currentDifficulty = Difficulty.Easy;
                        Program.PrintCentered("Easy mode selected! AI will go easy on you.");
                        return;
                    case "2":
                        currentDifficulty = Difficulty.Medium;
                        Program.PrintCentered("Medium mode selected! AI will be decent.");
                        return;
                    case "3":
                        currentDifficulty = Difficulty.Hard;
                        Program.PrintCentered("Hard mode selected! AI will be challenging.");
                        return;
                    default:
                        Program.PrintCentered("Invalid choice! Try again...");
                        break;
                }
            }
        }

        private static void GetRaceToOption()
        {
            while (raceTo == 0)
            {
                Console.Clear();
                PvCompHeader();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Program.PrintCentered("╔══════════════════════════╗");
                Program.PrintCentered("║   CHOOSE RACE-TO VALUE   ║");
                Program.PrintCentered("╠══════════════════════════╣");
                Program.PrintCentered("║ 1. Race to 3 wins        ║");
                Program.PrintCentered("║ 2. Race to 5 wins        ║");
                Program.PrintCentered("║ 3. Race to 7 wins        ║");
                Program.PrintCentered("║ 4. Race to 9 wins        ║");
                Program.PrintCentered("║ 5. Race to 11 wins       ║");
                Program.PrintCentered("║ 6. Race to 13 wins       ║");
                Program.PrintCentered("║ 7. Race to 15 wins       ║");
                Program.PrintCentered("╚══════════════════════════╝");
                Program.PrintWriteCentered("Your choice (1-7): ");

                string choice = Console.ReadLine();
                raceTo = choice switch
                {
                    "1" => 3,
                    "2" => 5,
                    "3" => 7,
                    "4" => 9,
                    "5" => 11,
                    "6" => 13,
                    "7" => 15,
                    _ => 0
                };

                if (raceTo == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Program.PrintWriteCentered("Invalid choice! Please select 1-7");
                    Console.Beep();
                }
            }
        }

        private static void WelcomePlayer()
        {
            Console.Clear();
            PvCompHeader();
            Console.ForegroundColor = ConsoleColor.Green;

            string welcomeText = $"WELCOME {playerName.ToUpper()}!";
            string difficultyText = $"DIFFICULTY: {currentDifficulty.ToString().ToUpper()}";
            string raceText = $"FIRST TO GET {raceTo} WINS BECOMES CHAMPION";

            int boxWidth = Math.Max(
                Math.Max(welcomeText.Length, difficultyText.Length),
                raceText.Length) + 6;
            boxWidth = Math.Max(boxWidth, 38);

            string border = "╔" + new string('═', boxWidth) + "╗";
            string middle = "╠" + new string('═', boxWidth) + "╣";
            string end = "╚" + new string('═', boxWidth) + "╝";

            Program.PrintCentered(border);
            Program.PrintCentered(CenterText(welcomeText, boxWidth));
            Program.PrintCentered(middle);
            Program.PrintCentered(CenterText(difficultyText, boxWidth));
            Program.PrintCentered(middle);
            Program.PrintCentered(CenterText(raceText, boxWidth));
            Program.PrintCentered(end);

            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintWriteCentered("Press any key to continue...");
            Console.ReadKey();
        }

        private static string CenterText(string text, int boxWidth)
        {
            int padding = boxWidth - text.Length;
            int leftPad = padding / 2;
            int rightPad = padding - leftPad;
            return "║" + new string(' ', leftPad) + text + new string(' ', rightPad) + "║";
        }

        public static void StartGameSession()
        {
            char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();
                DrawScoreHeader();
                GameBoard.DrawBoard(board);

                if (currentPlayerMark == 'X') 
                {
                    Program.PrintCentered($"{playerName}'s turn (X)");
                    Program.PrintWriteCentered("Enter box number (1-9) or 0 to return to menu: ");

                    string input = Console.ReadLine();

                    if (input == "0")
                    {
                        if (ConfirmReturnToMenu())
                        {
                            ResetGameState();
                            Program.Main();
                            return;
                        }
                        continue;
                    }

                    if (int.TryParse(input, out int choice) &&
                        choice >= 1 && choice <= 9 &&
                        board[choice - 1] != 'X' && board[choice - 1] != 'O')
                    {
                        board[choice - 1] = 'X';

                        if (GameBoard.CheckWin(board))
                        {
                            HandleWin();

                            if (playerScore >= raceTo)
                            {
                                DeclareChampion();
                                return;
                            }
                            board = ResetBoard();
                        }
                        else if (GameBoard.CheckDraw(board))
                        {
                            HandleDraw(board);
                            board = ResetBoard();
                        }
                        else
                        {
                            currentPlayerMark = 'O'; 
                        }
                    }
                    else
                    {
                        ShowInvalidMove();
                    }
                }
                else 
                {
                    Program.PrintCentered("Computer is thinking... (O)");
                    Thread.Sleep(1000); 

                    int computerMove = GetComputerMove(board, currentDifficulty);
                    board[computerMove] = 'O';

                    if (GameBoard.CheckWin(board))
                    {
                        HandleComputerWin();
                        if (computerScore >= raceTo)
                        {
                            DeclareComputerChampion();
                            return;
                        }
                        board = ResetBoard();
                    }
                    else if (GameBoard.CheckDraw(board))
                    {
                        HandleDraw(board);
                        board = ResetBoard();
                    }
                    else
                    {
                        currentPlayerMark = 'X'; 
                    }
                }
            }
        }

        private static int GetComputerMove(char[] board, Difficulty difficulty)
        {
            if (difficulty == Difficulty.Easy)
            {
                var availableMoves = Enumerable.Range(0, 9)
                    .Where(i => board[i] != 'X' && board[i] != 'O')
                    .ToList();
                return availableMoves[new Random().Next(availableMoves.Count)];
            }
            else if (difficulty == Difficulty.Medium)
            {
                if (new Random().Next(2) == 0) 
                {
                    return FindBestMove(board);
                }
                else
                {
                    var availableMoves = Enumerable.Range(0, 9)
                        .Where(i => board[i] != 'X' && board[i] != 'O')
                        .ToList();
                    return availableMoves[new Random().Next(availableMoves.Count)];
                }
            }
            else
            {
                return FindBestMove(board);
            }
        }

        private static int FindBestMove(char[] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != 'X' && board[i] != 'O')
                {
                    char temp = board[i];
                    board[i] = 'O';
                    if (GameBoard.CheckWin(board))
                    {
                        board[i] = temp;
                        return i;
                    }
                    board[i] = temp;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (board[i] != 'X' && board[i] != 'O')
                {
                    char temp = board[i];
                    board[i] = 'X';
                    if (GameBoard.CheckWin(board))
                    {
                        board[i] = temp;
                        return i;
                    }
                    board[i] = temp;
                }
            }

            if (board[4] != 'X' && board[4] != 'O')
                return 4;

            var corners = new[] { 0, 2, 6, 8 };
            var availableCorners = corners.Where(i => board[i] != 'X' && board[i] != 'O').ToList();
            if (availableCorners.Count > 0)
                return availableCorners[new Random().Next(availableCorners.Count)];

            var availableMoves = Enumerable.Range(0, 9)
                .Where(i => board[i] != 'X' && board[i] != 'O')
                .ToList();
            return availableMoves[new Random().Next(availableMoves.Count)];
        }

        private static void DrawScoreHeader()
        {
            int minWidth = $" {playerName} {playerScore} │ RACE TO {raceTo} │ {computerScore} COMPUTER ".Length;
            int boxWidth = Math.Max(minWidth + 2, 38);

            string border = "╔" + new string('═', boxWidth - 2) + "╗";
            string scoreLine = $" {playerName} {playerScore} │ RACE TO {raceTo} │ {computerScore} COMPUTER ";
            string centeredLine = CenterScoreText(scoreLine, boxWidth);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Program.PrintCentered(border);
            Program.PrintCentered(centeredLine);
            Program.PrintCentered("╚" + new string('═', boxWidth - 2) + "╝");
            Console.WriteLine();
        }

        private static string CenterScoreText(string text, int boxWidth)
        {
            int totalPadding = boxWidth - text.Length;
            int leftPadding = totalPadding / 2;
            return text.PadLeft(text.Length + leftPadding).PadRight(boxWidth);
        }

        private static void HandleWin()
        {
            Console.Beep();
            playerScore++;
            Console.Clear();
            DrawScoreHeader();
            Console.ForegroundColor = ConsoleColor.Blue;
            Program.PrintCentered($"╔══════════════════════════════════════╗");
            Program.PrintCentered($"       {playerName.ToUpper()} WINS THIS ROUND!      ");
            Program.PrintCentered($"╚══════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintWriteCentered("Press any key to continue...");
            Console.ReadKey();
        }

        private static void HandleComputerWin()
        {
            Console.Beep();
            computerScore++;
            Console.Clear();
            DrawScoreHeader();
            Console.ForegroundColor = ConsoleColor.Red;
            Program.PrintCentered($"╔══════════════════════════════════════╗");
            Program.PrintCentered($"        COMPUTER WINS THIS ROUND!       ");
            Program.PrintCentered($"╚══════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintWriteCentered("Press any key to continue...");
            Console.ReadKey();
        }

        private static void HandleDraw(char[] board)
        {
            Console.Beep();
            Console.Clear();
            DrawScoreHeader();
            GameBoard.DrawBoard(board);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Program.PrintCentered("It's a draw! No points awarded.");
            Program.PrintWriteCentered("Press any key to continue...");
            Console.ReadKey();
        }

        private static char[] ResetBoard()
        {
            currentPlayerMark = 'X'; 
            return ['1', '2', '3', '4', '5', '6', '7', '8', '9'];
        }

        private static bool ConfirmReturnToMenu()
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Program.PrintWriteCentered("Return to main menu? (Y/N)");
            return Console.ReadKey(true).Key == ConsoleKey.Y;
        }

        private static void ShowInvalidMove()
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Program.PrintWriteCentered("Invalid move! Try again.");
            Console.ReadKey();
        }

        private static void DeclareChampion()
        {
            Console.Clear();
            string championText = $"{playerName.ToUpper()} IS THE CHAMPION!";
            string scoreText = $"FINAL SCORE: {playerName} {playerScore} - {computerScore} COMPUTER";
            int boxWidth = Math.Max(championText.Length, scoreText.Length) + 10;
            boxWidth = Math.Max(boxWidth, 38);

            Console.ForegroundColor = ConsoleColor.Green;
            Program.PrintCentered("╔" + new string('═', boxWidth - 2) + "╗");
            Program.PrintCentered($"║{championText.PadLeft((boxWidth + championText.Length - 2) / 2).PadRight(boxWidth - 2)}║");
            Program.PrintCentered("╠" + new string('═', boxWidth - 2) + "╣");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Program.PrintCentered($"║{scoreText.PadLeft((boxWidth + scoreText.Length - 2) / 2).PadRight(boxWidth - 2)}║");
            Program.PrintCentered("╚" + new string('═', boxWidth - 2) + "╝");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintWriteCentered("\nPlay again? (Y/N)");

            bool validInput = false;
            while (!validInput)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Y)
                {
                    validInput = true;
                    ResetGameState();
                    PlayerVsComputer(); 
                }
                else if (key == ConsoleKey.N)
                {
                    validInput = true;
                    ResetGameState();
                    Program.Main(); 
                }
            }
        }

        private static void DeclareComputerChampion()
        {
            Console.Clear();
            string championText = "COMPUTER IS THE CHAMPION!";
            string scoreText = $"FINAL SCORE: {playerName} {playerScore} - {computerScore} COMPUTER";
            int boxWidth = Math.Max(championText.Length, scoreText.Length) + 10;
            boxWidth = Math.Max(boxWidth, 38);

            Console.ForegroundColor = ConsoleColor.Red;
            Program.PrintCentered("╔" + new string('═', boxWidth - 2) + "╗");
            Program.PrintCentered($"║{championText.PadLeft((boxWidth + championText.Length - 2) / 2).PadRight(boxWidth - 2)}║");
            Program.PrintCentered("╠" + new string('═', boxWidth - 2) + "╣");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Program.PrintCentered($"║{scoreText.PadLeft((boxWidth + scoreText.Length - 2) / 2).PadRight(boxWidth - 2)}║");
            Program.PrintCentered("╚" + new string('═', boxWidth - 2) + "╝");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintWriteCentered("\nPlay again? (Y/N)");

            bool validInput = false;
            while (!validInput)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Y)
                {
                    validInput = true;
                    ResetGameState();
                    PlayerVsComputer(); 
                }
                else if (key == ConsoleKey.N)
                {
                    validInput = true;
                    ResetGameState();
                    Program.Main(); 
                }
            }
        }

        private static void ResetGameState()
        {
            playerScore = 0;
            computerScore = 0;
            currentPlayerMark = 'X';
            raceTo = 0; // This will force race selection again
        }

        public static void PvCompHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintCentered("██████╗     ██╗   ██╗███████╗     ██████╗ ██████╗ ███╗   ███╗██████╗  ");
            Program.PrintCentered("██╔══██╗    ██║   ██║██╔════╝    ██╔════╝██╔═══██╗████╗ ████║██╔══██╗ ");
            Program.PrintCentered("██████╔╝    ██║   ██║███████╗    ██║     ██║   ██║██╔████╔██║██████╔╝ ");
            Program.PrintCentered("██╔═══╝     ╚██╗ ██╔╝╚════██║    ██║     ██║   ██║██║╚██╔╝██║██╔═══╝  ");
            Program.PrintCentered("██║          ╚████╔╝ ███████║    ╚██████╗╚██████╔╝██║ ╚═╝ ██║██║      ");
            Program.PrintCentered("╚═╝           ╚═══╝  ╚══════╝     ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚═╝      ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}