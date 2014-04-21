using System;
using System.Data.SqlClient;

namespace JobTrack.Api.Data.Commands
{
    public class TermehContextException : Exception
    {
        private readonly Exception _exception;
        private readonly bool _isHandled;
        private readonly string _handledMessage;

        public TermehContextException(Exception exception)
        {
            _exception = exception;
            var sqlException = exception.GetBaseException() as SqlException;

            if (sqlException != null)
            {
                var number = sqlException.Number;

                if (number == 547)
                {
                    _isHandled = true;
                    _handledMessage = "Must delete dependant entities before deleting base entity";
                }
                else
                    throw new TermehContextException(_exception);
            }
        }

        public string HandledMessage
        {
            get { return _handledMessage; }
        }

        public bool IsHandled
        {
            get { return _isHandled; }
        }
    }
}