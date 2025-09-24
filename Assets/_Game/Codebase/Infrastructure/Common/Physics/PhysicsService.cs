using UnityEngine;
using Scellecs.Morpeh;
using Game.Codebase.Morpeh.Common.Collisions;

namespace Game.Codebase.Morpeh.Common.Physics
{
    public class PhysicsService : IPhysicsService
    {
        private static readonly Collider[] OverlapHits = new Collider[8];

        private readonly ICollisionRegistry _collisions;

        public PhysicsService(ICollisionRegistry collisions)
        {
            _collisions = collisions;
        }

        public bool TrySphereOverlap(Vector3 position, float radius, int layer, out Entity entity)
        {
            var hitsCount = UnityEngine.Physics.OverlapSphereNonAlloc(position, radius, OverlapHits, layer);

            entity = default;

            for (int i = 0; i < hitsCount; i++)
            {
                var hit = OverlapHits[i];

                if (_collisions.Get(hit.GetInstanceID(), out entity))
                {
                    return true;
                }
            }

            return false;
        }
    }
}