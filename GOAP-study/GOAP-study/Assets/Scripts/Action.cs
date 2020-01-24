using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP
{
    public abstract class Action : MonoBehaviour
    {
        public string actionName = "Action";
        public float cost = 1.0f;
        public Transform targetPos;
        public GameObject targetTag;

        // How long does this action is gonna take?
        public float duration;

        // For Setting up WorldState using inspector.
        // will use this array to fill up dictionaries
        public WorldState[] preConditions;
        public WorldState[] afterEffects;
        public NavMeshAgent navMeshAgent;

        public Dictionary<string, int> preConditionDict;
        public Dictionary<string, int> afterEffectDict;

        public WorldStates agentBeliefs;
        public bool isRunning = false;

        public Action()
        {
            preConditionDict = new Dictionary<string, int>();
            afterEffectDict = new Dictionary<string, int>();
        }

        private void Awake()
        {
            if (preConditions != null)
            {
                foreach (WorldState state in preConditions)
                {
                    preConditionDict.Add(state.key, state.value);
                }
            }

            if (afterEffects != null)
            {
                foreach (WorldState state in afterEffects)
                {
                    afterEffectDict.Add(state.key, state.value);
                }
            }

            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Determine if this particular action is achievable
        public bool IsAchievable()
        {
            return true;
        }

        public bool IsAchievableGiven(Dictionary<string, int> conditions)
        {
            foreach (var preCondition in preConditionDict)
            {
                // Precondition 확인
                if (!conditions.ContainsKey(preCondition.Key))
                {
                    return false;
                }
            }
            return true;
        }

        public abstract bool PrePerform();
        public abstract bool PostPerform();
    }
}