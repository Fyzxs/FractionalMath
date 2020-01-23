using System;

namespace FractionalMath
{
    internal interface ITextBlobs
    {
        void Instructions();
        void ExitMessage();
    }

    internal sealed class TextBlobs : ITextBlobs
    {
        private const int InputStart = 9;
        private const int ScreenTop = 0;

        public void Instructions()
        {
            int prevPos = Console.CursorTop;
            Console.CursorTop = InstructionsPosition();
            InstructionsBlob();
            Console.CursorTop = InputPosition(prevPos);
        }

        private static int InstructionsPosition()
        {
            int newPos = Console.CursorTop - Console.WindowHeight + 1;
            return newPos < ScreenTop ? ScreenTop : newPos;
        }

        private static int InputPosition(int prevPos)
        {
            return prevPos < InputStart ? InputStart : prevPos;
        }

        private static void InstructionsBlob()
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

        public void ExitMessage()
        {
            Console.WriteLine("Thanks for coming!");
            Console.WriteLine("Hit any key to exit");
            Console.ReadKey();
        }
    }
}