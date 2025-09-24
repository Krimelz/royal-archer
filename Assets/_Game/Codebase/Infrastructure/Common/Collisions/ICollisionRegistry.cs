using Scellecs.Morpeh;

namespace Game.Codebase.Morpeh.Common.Collisions
{
    public interface ICollisionRegistry
    {
        void Register(int id, Entity entity);
        void Unregister(int id);
        bool Get(int id, out Entity entity);
    }
}