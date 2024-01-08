using static WorkFlowEngine.Program;

namespace WorkFlowEngine
{
    // Create an engine that runs the workflow
    public class WorkFlowEngine
    {
        public void Run(WorkFlow workFlow)
        {
            foreach (var activity in workFlow.GetActivities())
            {
                activity.Execute();
            }
        }
    }
}