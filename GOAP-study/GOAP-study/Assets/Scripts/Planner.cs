// Sort through actions and match their effects with other preconditions to construct a plan

// We start by...
//  1.  Fetching all the available actions an agent can currently perform
//      These are given to the Planner, which traverse through all of them
//      to check if some are achievable.

//  Start building a graph which is beginning with an initial node.
//  Initial node's Effect is going to be WorldStates 

//  Then search through all the achievable actions for ones that can be performed
//  given the WorldStates in the initial node.

// Each matching Action creates a new node and a new branch in the graph that is being constructed

//  We then explore each branch for another Action that can be attached 
//  using the preconditions and efects.

//  This process continues down each branch until..
//  1. A Path is satisfied that matches the initial Goal
//  2. Planner runs out of Actions.

//  If a Path is found, that Path becomes the agent's 'Queue of Actions'
//  and then, the agent starts to perform them.

//  Planner is going to link all currently available actions in a plan

//  Action끼리 묶지 말고, Node 클래스를 만들자

using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GOAP
{
    public class Node
    {
        public Node parent;
        public float cost;
        public Dictionary<string, int> state;
        public GOAP.Action action;

        public Node(Node parent, float cost, Dictionary<string, int> allStates, GOAP.Action action)
        {
            this.parent = parent;
            this.cost = cost;
            this.state = new Dictionary<string, int>(allStates);
            this.action = action;
        }
    }

    public class Planner
    {
        public Queue<GOAP.Action> TryBuildPlan(List<GOAP.Action> actions, Dictionary<string, int> goal, WorldState states)
        {
            #region Query usable actions
            List<GOAP.Action> usableActions = new List<GOAP.Action>();

            foreach (GOAP.Action action in actions)
            {
                if (action.IsAchievable())
                {
                    usableActions.Add(action);
                }
            }
            #endregion

            #region Try building graph and find path
            List<Node> leaves = new List<Node>();
            Node initialNode = new Node(null, 0f, World.Instance.GetWorld().GetStates(), null);

            bool isPathFound = BuildGraph(initialNode, leaves, usableActions, goal);

            if (!isPathFound)
            {
                Debug.LogWarning("Couldn't build a plan");
                return null;
            }
            #endregion

            #region Path Found, Find cheapest Node
            Node cheapestNode = null;
            foreach (Node leafNode in leaves)
            {
                if (object.ReferenceEquals(cheapestNode, null))
                {
                    cheapestNode = leafNode;
                }
                else
                {
                    if (leafNode.cost < cheapestNode.cost)
                    {
                        cheapestNode = leafNode;
                    }
                }
            }
            #endregion

            #region Set up the Path and return it
            List<GOAP.Action> result = new List<Action>();
            Node node = cheapestNode;
            while (!object.ReferenceEquals(node, null))
            {
                if (node.action != null)
                {
                    result.Insert(0, node.action);
                }
                    node = node.parent;
            }
            
            Queue<GOAP.Action> actionQueue = new Queue<GOAP.Action>();
            foreach (GOAP.Action action in result)
            {
                actionQueue.Enqueue(action);
            }
            #endregion

            return actionQueue;
        }

        private bool BuildGraph(Node initialNode, List<Node> leaves, List<Action> usableActions, Dictionary<string, int> goal)
        {
            throw new NotImplementedException();
        }
    }
}
