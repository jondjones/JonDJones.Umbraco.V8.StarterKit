using Umbraco.Web.Scheduling;
using Umbraco.Core.Logging;
using Umbraco.Core.Composing;
using Umbraco.Core;

namespace TutorialCode.Components
{
    public class ReoccurringTasks : IComponent
    {
        private BackgroundTaskRunner<IBackgroundTask> _backgroundTaskRunner;
        private readonly ILogger _logger;
        private readonly IRuntimeState _runtimeState;
        private const int DELAY_BEFORE_START = 60000; 
        private const int HOW_OFTEN_TO_REPEAT = 60000; 

        public ReoccurringTasks(ILogger logger, IRuntimeState runtimeState)
        {
            _logger = logger;
            _runtimeState = runtimeState;
            _backgroundTaskRunner = new BackgroundTaskRunner<IBackgroundTask>(_logger);
        }

        public void Initialize()
        {
            var task = new MyLogger(_backgroundTaskRunner, DELAY_BEFORE_START, HOW_OFTEN_TO_REPEAT, _logger, _runtimeState);
            _backgroundTaskRunner.TryAdd(task);
        }

        public void Terminate()
        {
        }
    }
}
