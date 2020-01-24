using UnityEngine;

namespace GOAP
{
    public sealed class World
    {
        public static World Instance
        {
            get => _instance;
        }

        private static readonly World _instance = new World();
        private static WorldStates _worldStates;

        static World()
        {
            _worldStates = new WorldStates();
        }

        private World()
        {

        }

        public WorldStates GetWorld()
        {
            return _worldStates;
        }
    }
}