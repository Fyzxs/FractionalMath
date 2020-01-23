using System;
using FractionalMathLib;

namespace FractionalMath
{
    public class FractionalMathProgram
    {
        public static void Main(string[] args)
        {
            new RunMe().Run();
        }
    }

    internal sealed class RunMe
    {
        private readonly IUserInteraction _ux;
        private readonly ITextBlobs _textBlobs;
        private readonly IProcessRequest _processRequest;

        public RunMe():this(new UserInteraction(), new TextBlobs(), new ProcessRequest()) {}

        private RunMe(IUserInteraction ux, ITextBlobs textBlobs, IProcessRequest processRequest)
        {
            _ux = ux;
            _textBlobs = textBlobs;
            _processRequest = processRequest;
        }

        public void Run()
        {
            _textBlobs.Instructions();
            string input;
            while ("q" != (input = _ux.WaitForInput()))
            {
                try
                {
                    _ux.DisplayResult(_processRequest.ProcessInput(input));
                }
                catch (Exception ex)
                {
                    _ux.DisplayError(ex);
                }

                _textBlobs.Instructions();
            }

            _textBlobs.ExitMessage();
        }


    }

    internal sealed class TextBlobs : ITextBlobs
    {
        public void Instructions()
        {
            int prevPos = Console.CursorTop;
            int newPos = Console.CursorTop - Console.WindowHeight + 1;
            Console.CursorTop = newPos < 0 ? 0 : newPos;
            IntroBlob();
            Console.CursorTop = prevPos;

        }
        private static void IntroBlob()
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

    internal interface ITextBlobs
    {
        void Instructions();
        void ExitMessage();
    }

    internal sealed class UserInteraction : IUserInteraction
    {
        public string WaitForInput()
        {
            Console.Write("? ");
            return Console.ReadLine();
        }

        public void DisplayResult(string answer) => Console.WriteLine($"= {answer}");

        public void DisplayError(Exception ex) => Console.WriteLine($"Unable to Process. {ex.Message}");
    }

    internal interface IUserInteraction
    {
        string WaitForInput();
        void DisplayResult(string answer);
        void DisplayError(Exception ex);
    }
}
