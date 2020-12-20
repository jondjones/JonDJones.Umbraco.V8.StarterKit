using Umbraco.Web.Scheduling;
using Umbraco.Core.Logging;
using Umbraco.Core;

namespace TutorialCode.Components
{
    public class MyLogger : RecurringTaskBase
    {
        private ILogger _logger;
        private readonly IRuntimeState _runtimeState;

        public MyLogger(
            IBackgroundTaskRunner<RecurringTaskBase> runner, 
            int delayBeforeWeStart, 
            int howOftenWeRepeat, ILogger logger, 
            IRuntimeState runtimeState)
            : base(runner, delayBeforeWeStart, howOftenWeRepeat)
        {
            _logger = logger;
            _runtimeState = runtimeState;
        }

        public override bool PerformRun()
        {
            _logger.Info<MyLogger>(_runtimeState.ServerRole.ToString());
            return true;
        }

        public override bool IsAsync => false;
    }
}
