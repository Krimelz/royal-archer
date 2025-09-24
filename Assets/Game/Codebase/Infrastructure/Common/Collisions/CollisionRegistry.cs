using System.Collections.Generic;
using Scellecs.Morpeh;

namespace Game.Codebase.Infrastructure.Common.Collisions
{
    public class CollisionRegistry : ICollisionRegistry
    {
        private readonly Dictionary<int, Entity> _entityById = new();

        public void Register(int id, Entity entity)
        {
            _entityById[id] = entity;
        }

        public void Unregister(int id)
        {
            if (_entityById.ContainsKey(id))
            {
                _entityById.Remove(id);
            }
        }

        public bool Get(int id, out Entity entity)
        {
            if (_entityById.TryGetValue(id, out entity))
            {
                return true;
            }

            return false;
        }
    }
}