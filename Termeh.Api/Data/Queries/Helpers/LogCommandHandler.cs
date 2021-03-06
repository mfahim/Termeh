using ShortBus;
using log4net;

namespace JobTrack.Api.Data.Queries.Helpers
{
    public class LogCommandHandler : ICommandHandler<LogCommand>
    {
        private readonly ILog _logger;

        public LogCommandHandler(ILog logger)
        {
            _logger = logger;
        }

        public void Handle(LogCommand message)
        {
            _logger.Info(string.Format("Message \"{0}\" ", message.LogMessage));
        }
    }
}