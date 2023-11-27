using ADO.NET.Models;
using System.Runtime.CompilerServices;

namespace Nov27Practice.Helpers
{
    internal static class InputHelper
    {
        public static string HashString(string text, string salt = "")
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            // Uses SHA256 to create the hash
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", string.Empty);

                return hash;
            }
        }

        public static string PromptAndGetNonEmptyString(string prompt)
        {
            string input = null;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input == string.Empty)
                    ConsoleHelpers.PrintError("Empty input is not allowed!");

            } while (string.IsNullOrWhiteSpace(input) || input == string.Empty);

            return input;
        }

        public static string PromptAndTryGetNonEmptyString(string prompt)
        {
            string input = null;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input == string.Empty)
                    throw ExceptionHelper.InputFormatInvalidException("Empty input is not allowed!");

            } while (string.IsNullOrWhiteSpace(input) || input == string.Empty);

            return input;
        }

        public static int PromptAndTryGetPositiveInt(string prompt = "")
        {
            int input = 0;
            do
            {
                input = Convert.ToInt32(PromptAndTryGetNonEmptyString(prompt));
                if (input < 0)
                    throw ExceptionHelper.InputFormatInvalidException("Positive input is required!");
            } while (input < 0);

            return input;
        }

        public static int PromptAndGetPositiveRangedInt(string prompt, int maxRange)
        {
            int input = 0;
            do
            {
                input = PromptAndTryGetPositiveInt(prompt);

                if (input > maxRange)
                    ConsoleHelpers.PrintError($"Positive input with {maxRange} max value is required!");

            } while (input > maxRange);

            return input;
        }

        public static int PromptAndGetPositiveNzInt(string prompt)
        {
            int input = 0;
            do
            {
                input = Convert.ToInt32(PromptAndGetNonEmptyString(prompt));

                if (input <= 0)
                    ConsoleHelpers.PrintError("Positive non zero input is required!");

            } while (input <= 0);

            return input;
        }

        public static Blog GetBlogFromUser()
        {
            var Title = PromptAndGetNonEmptyString("Enter title: ");
            var Description = PromptAndGetNonEmptyString("Description: ");
            return new Blog() { Title = Title, Description = Description };
        }
        /// <summary>
        /// Prints interactive ui with commands
        /// </summary>
        /// <typeparam name="T">Command Enum type</typeparam>
        /// <param name="commands">Command Enum Array</param>
        /// <param name="printBuffer">Prints Buffer</param>
        /// <param name="header">Prompt header</param>
        /// <returns>Command index From Commands Array</returns>
        public static T DisplayAndGetCommandBySelection<T>
            (T[] commands, string header = "") where T : Enum
        {
            int currentCmdIndex = 0;
            do
            {
                Console.Clear();
                ConsoleHelpers.PrintBuffer();

                if (!string.IsNullOrEmpty(header))
                    ConsoleHelpers.PrintWarning(header + ": ");

                for (int i = 0; i < commands.Length; i++)
                {
                    if (i == currentCmdIndex)
                        ConsoleHelpers.InlineSelectionCursor();
                    else
                        Console.Write("  ");
                    Console.WriteLine(commands[i]);
                }
                var keyPress = Console.ReadKey().Key;

                if (keyPress == ConsoleKey.UpArrow)
                {
                    currentCmdIndex = currentCmdIndex - 1 < 0 ? 0 : currentCmdIndex - 1;
                }

                if (keyPress == ConsoleKey.DownArrow)
                {
                    currentCmdIndex = currentCmdIndex + 1 > commands.Length - 1 ? commands.Length - 1 : currentCmdIndex + 1;
                }

                if (keyPress == ConsoleKey.Enter)
                    return commands[currentCmdIndex];

            } while (true);
        }
    }
}
