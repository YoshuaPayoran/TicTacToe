using System;

namespace TicTacToe
{
    class PvsP
    {
        private static string player1 = "";
        private static string player2 = "";
        private static int raceTo = 0; 
        private static int player1Score = 0;
        private static int player2Score = 0;
        private static char currentPlayerMark = 'X';

        public static void PlayerVsPlayer()
        {
            PvPHeader();
            GetPlayerNames();
            GetRaceToOption();
            WelcomePlayers();

        }

        private static void GetPlayerNames()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Program.PrintWriteCentered("Enter Player 1 Name: ");
            player1 = Console.ReadLine();
            Program.PrintWriteCentered("Enter Player 2 Name: ");
            player2 = Console.ReadLine();
        }

        private static void GetRaceToOption()
        {
            while (raceTo == 0) 
            {
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

        private static void WelcomePlayers()
        {
            Console.Clear();
            PvPHeader();
            Console.ForegroundColor = ConsoleColor.Green;

            // Calculate required width based on the longest text line
            int welcomeLength = $"WELCOME {player1.ToUpper()} AND {player2.ToUpper()}!".Length;
            int championLength = $"FIRST TO GET {raceTo} WINS BECOMES CHAMPION".Length;
            int minContentWidth = Math.Max(welcomeLength, championLength);

            // Set box width (content width + 6 for padding and borders)
            int boxWidth = minContentWidth + 6;
            boxWidth = Math.Max(boxWidth, 38); // Minimum width of 38

            // Create dynamic borders
            string border = "╔" + new string('═', boxWidth) + "╗";
            string middle = "╠" + new string('═', boxWidth) + "╣";
            string end = "╚" + new string('═', boxWidth) + "╝";

            // Create centered content
            string welcome = CenterText($"WELCOME {player1.ToUpper()} AND {player2.ToUpper()}!", boxWidth);
            string champion = CenterText($"FIRST TO GET {raceTo} WINS BECOMES CHAMPION", boxWidth);

            // Draw the box
            Program.PrintCentered(border);
            Program.PrintCentered(welcome);
            Program.PrintCentered(middle);
            Program.PrintCentered(champion);
            Program.PrintCentered(end);

            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintWriteCentered("Press any key to continue...");
            Console.ReadKey();
            StartGameSession();
        }

        private static string CenterText(string text, int boxWidth)
        {
            int totalPadding = boxWidth - text.Length;
            int leftPadding = totalPadding / 2;
            int rightPadding = totalPadding - leftPadding;
            return "║" + new string(' ', leftPadding) + text + new string(' ', rightPadding) + "║";
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

                string currentPlayer = currentPlayerMark == 'X' ? player1 : player2;
                Console.ForegroundColor = currentPlayerMark == 'X' ? ConsoleColor.Blue : ConsoleColor.Red;
                Program.PrintCentered($"{currentPlayer}'s turn ({currentPlayerMark})");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Program.PrintWriteCentered("Enter box number (1-9) or 0 to return to menu: ");

                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Program.PrintWriteCentered("Return to main menu? (Y/N)");
                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    {
                        ResetGameState();
                        Program.Main();
                        return;
                    }
                    continue;
                }

                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
                    {
                        board[choice - 1] = currentPlayerMark;

                        if (GameBoard.CheckWin(board))
                        {
                            HandleWin(currentPlayer, board);
                            if (player1Score >= raceTo || player2Score >= raceTo)
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
                            currentPlayerMark = currentPlayerMark == 'X' ? 'O' : 'X';
                        }
                    }
                    else
                    {
                        ShowInvalidMove();
                    }
                }
                else
                {
                    ShowInvalidMove();
                }
            }
        }

        private static void ResetGameState()
        {
            player1Score = 0;
            player2Score = 0;
            currentPlayerMark = 'X';
            raceTo = 0; 
                        
        }

        private static void DrawScoreHeader()
        {
            int minWidth = $" {player1} {player1Score} │ RACE TO {raceTo} │ {player2Score} {player2} ".Length;
            int boxWidth = Math.Max(minWidth + 2, 38);

            string border = "╔" + new string('═', boxWidth - 2) + "╗";
            string scoreLine = $" {player1} {player1Score} │ RACE TO {raceTo} │ {player2Score} {player2} ";
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

        private static void HandleWin(string player, char[] board)
        {
            Console.Beep();
            
            if (currentPlayerMark == 'X')
                player1Score++;
            else
                player2Score++;

            Console.Clear();
            DrawScoreHeader();

            
            string winText = $"{player.ToUpper()} WINS THIS ROUND!";
            int boxWidth = Math.Max(winText.Length + 10, 38); 

            Console.ForegroundColor = currentPlayerMark == 'X' ? ConsoleColor.Blue : ConsoleColor.Red;
            Program.PrintCentered("╔" + new string('═', boxWidth - 2) + "╗");
            Program.PrintCentered($"{winText.PadLeft((boxWidth - 2 + winText.Length) / 2).PadRight(boxWidth - 2)}");
            Program.PrintCentered("╚" + new string('═', boxWidth - 2) + "╝");

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
            Program.PrintWriteCentered("Press any key to start next round...");
            Console.ReadKey();
        }

        private static char[] ResetBoard()
        {
            return new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
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
            string champion = player1Score > player2Score ? player1 : player2;
            string championText = $"{champion.ToUpper()} IS THE CHAMPION!";

            
            int boxWidth = Math.Max(championText.Length + 10, 38); 

            Console.ForegroundColor = ConsoleColor.Green;

            
            string border = "╔" + new string('═', boxWidth - 2) + "╗";
            Program.PrintCentered(border);
            Program.PrintCentered(CenterText(championText, boxWidth));
            Program.PrintCentered("╚" + new string('═', boxWidth - 2) + "╝");

            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Program.PrintCentered($"Final Scores: {player1} {player1Score} - {player2Score} {player2}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintWriteCentered("Do you want to play again? (Y/N)");

            bool validInput = false;
            while (!validInput)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Y)
                {
                    validInput = true;
                    
                    raceTo = 0;
                    player1Score = 0;  
                    player2Score = 0;  
                    PlayerVsPlayer();
                }
                else if (key == ConsoleKey.N)
                {
                    validInput = true;
                    
                    raceTo = 0;
                    player1Score = 0;
                    player2Score = 0;
                    Program.Main(); 
                }
            }
        }


        public static void PvPHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Program.PrintCentered("██████╗     ██╗   ██╗███████╗    ██████╗  ");
            Program.PrintCentered("██╔══██╗    ██║   ██║██╔════╝    ██╔══██╗ ");
            Program.PrintCentered("██████╔╝    ██║   ██║███████╗    ██████╔╝ ");
            Program.PrintCentered("██╔═══╝     ╚██╗ ██╔╝╚════██║    ██╔═══╝  ");
            Program.PrintCentered("██║          ╚████╔╝ ███████║    ██║      ");
            Program.PrintCentered("╚═╝           ╚═══╝  ╚══════╝    ╚═╝      ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}