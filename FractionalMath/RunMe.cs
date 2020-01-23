using System;
using FractionalMathLib;

namespace FractionalMath
{
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
}