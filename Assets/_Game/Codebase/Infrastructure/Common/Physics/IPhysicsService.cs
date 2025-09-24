using UnityEngine;
using Scellecs.Morpeh;

namespace Game.Codebase.Morpeh.Common.Physics
{
    public interface IPhysicsService
    {
        bool TrySphereOverlap(Vector3 position, float radius, int layer, out Entity entity);
    }
}