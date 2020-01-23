using System;
using FractionalMathLib.Exceptions;
using FractionalMathLib.Results.Doubles;
using FractionalMathLib.Results.Strings;

namespace FractionalMath
{
    public class FractionalMathProgram
    {
        public static void Main(string[] args)
        {
            Intro();
            string input;
            while (!string.Equals((input = WaitForInput()), "q", StringComparison.Ordinal))
            {
                try
                {
                    string answer = ProcessInput(input);
                    DisplayResult(answer);
                }
                catch (Exception ex)
                {
                    DisplayError(ex);
                }

                KeepIntroText();
            }
            Console.WriteLine("Thanks for coming!");
            Console.WriteLine("Hit any key to exit");
            Console.ReadKey();
        }

        private static void KeepIntroText()
        {
            int prevPos = Console.CursorTop;
            int newPos = Console.CursorTop - Console.WindowHeight+1;
            Console.CursorTop = newPos < 0 ? 0 : newPos;
            Intro();
            Console.CursorTop = prevPos;

        }

        private static void DisplayResult(string answer)
        {
            Console.WriteLine($"= {answer}");
        }

        private static void DisplayError(Exception ex)
        {
            Console.WriteLine($"Unable to Process. {ex.Message}");
        }

        public static string ProcessInput(string input)
        {
            string[] arguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (arguments.Length != 3) throw new InvalidArgumentsException(arguments.Length);

            return new MixedNumberTextResult(new OperationResult(arguments));
        }

        private static string WaitForInput()
        {
            InputPrompt();
            return Console.ReadLine();
        }

        private static void InputPrompt() => Console.Write("? ");

        private static void Intro()
        {
            Console.WriteLine("Welcome to \"Fractional Math\"!".PadRight(Console.WindowWidth));
            Console.WriteLine("".PadRight(Console.WindowWidth));
            Console.WriteLine("To perform a calculation use the following structure".PadRight(Console.WindowWidth));
            Console.WriteLine("# Legal operators are '*', '/', '+', '-'' (multiply, divide, add, subtract)".PadRight(Console.WindowWidth));
            Console.WriteLine("# Operands and operators shall be separated by one or more spaces. e.g. '? 1/2 * 1/2'".PadRight(Console.WindowWidth));
            Console.WriteLine("# Mixed numbers will be represented by whole_numerator/denominator. e.g. '3_1 / 4'".PadRight(Console.WindowWidth));
            Console.WriteLine("Note: Improper fractions and whole numbers are also allowed as operands ".PadRight(Console.WindowWidth));
            Console.WriteLine("To exit, please enter just the letter 'q'".PadRight(Console.WindowWidth));
            Console.WriteLine("".PadRight(Console.WindowWidth));
        }
    }
}
