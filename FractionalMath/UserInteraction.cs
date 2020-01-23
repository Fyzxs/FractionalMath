using System;

namespace FractionalMath
{
    internal interface IUserInteraction
    {
        string WaitForInput();
        void DisplayResult(string answer);
        void DisplayError(Exception ex);
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
}