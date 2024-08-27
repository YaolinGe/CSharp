using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WorkFlowEngine.Program;

namespace WorkFlowEngine
{

    // Create a workflow class that contains a list of activities.
    public class WorkFlow
    {
        private readonly List<IActivity> _activities;

        public WorkFlow()
        {
            _activities = new List<IActivity>();
        }

        public void Add(IActivity activity)
        {
            _activities.Add(activity);
        }

        public void Remove(IActivity activity)
        {
            _activities.Remove(activity);
        }

        public IEnumerable<IActivity> GetActivities()
        {
            return _activities;
        }
    }

}
