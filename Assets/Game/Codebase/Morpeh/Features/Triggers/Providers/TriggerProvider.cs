using Game.Codebase.Infrastructure.Common.Collisions;
using Game.Codebase.Morpeh.Features.Triggers.Components;
using Scellecs.Morpeh.Providers;
using VContainer;

namespace Game.Codebase.Morpeh.Features.Triggers.Providers
{
    public class TriggerProvider : MonoProvider<Trigger>
    {
        private ICollisionRegistry _collisions;

        [Inject]
        private void Construct(ICollisionRegistry collisions)
        {
            _collisions = collisions;
        }

        protected override void Initialize()
        {
            _collisions.Register(GetData().Collider.GetInstanceID(), Entity);
        }

        protected override void Deinitialize()
        {
            _collisions.Unregister(GetData().Collider.GetInstanceID());
        }
    }
}