using Scellecs.Morpeh;

namespace Game.Codebase.Infrastructure.Common.Collisions
{
    public interface ICollisionRegistry
    {
        void Register(int id, Entity entity);
        void Unregister(int id);
        bool Get(int id, out Entity entity);
    }
}