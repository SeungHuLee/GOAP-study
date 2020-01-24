using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Will use LINQ for sorting goals based on their priority

namespace GOAP
{
    public class SubGoal
    {
        public Dictionary<string, int> subGoals;

        /// <summary>
        /// Should this goal be triggered over and over again?
        /// </summary>
        public bool shouldRemove;

        public SubGoal(string key, int value, bool shouldRemove)
        {
            subGoals = new Dictionary<string, int>();
            subGoals.Add(key, value);
            this.shouldRemove = shouldRemove;
        }
    }
    
    public class Agent : MonoBehaviour
    {
        public List<GOAP.Action> actions = new List<GOAP.Action>();
        public Dictionary<SubGoal, int> subGoals = new Dictionary<SubGoal, int>();

        public Planner planner;
        public Queue<GOAP.Action> actionQueue = new Queue<GOAP.Action>();
        public GOAP.Action currentAction;
        public SubGoal currentGoal;

        private void Start()
        {
            GOAP.Action[] acts = GetComponents<GOAP.Action>();

            foreach (var act in acts)
            {
                actions.Add(act);
            }
        }

        private void LateUpdate()
        {
            // Planner is going to 
            // 1. Fetch goals that are needing to be satisfied
            // 2. Get list of actions that are available
            // 3. WorldStates

            // Refer to those resources, Planner is going to build a tree(graph) of all the actions

            // Search through the graph from one end to the other where we come up with a plan
            // which is going to satisfy the given goal.

        }
    }
}
