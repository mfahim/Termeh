using System;

namespace JobTrack.Api.Data.Queries.Helpers
{
    public class LogCommand
    {
        public string LogMessage { get; set; }
        public DateTime Time { get; set; }

        public LogCommand(string message)
        {
            LogMessage = message;
            Time = DateTime.Now;
        }
    }
}