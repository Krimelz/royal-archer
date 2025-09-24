using Scellecs.Morpeh;
using UnityEngine;

namespace Game.Codebase.Infrastructure.Common.Physics
{
    public interface IPhysicsService
    {
        bool TrySphereOverlap(Vector3 position, float radius, int layer, out Entity entity);
    }
}