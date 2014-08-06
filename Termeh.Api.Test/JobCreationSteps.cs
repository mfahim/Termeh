using System;
using JobTrack.Api.Data.Commands;
using TechTalk.SpecFlow;

namespace Termeh.Api.Test
{
    [Binding]
    public class JobCreationSteps
    {
        public JobCreationSteps()
        {
        }

        [When(@"I press newJob")]
        public void WhenIPressNewJob()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be a new job on Termeh")]
        public void ThenTheResultShouldBeANewJobOnTermeh()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
