using Game.Codebase.Infrastructure.Common.Collisions;
using Game.Codebase.Morpeh.Features.Triggers.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using VContainer;
using Sprite = Game.Codebase.Morpeh.Features.Common.Components.Sprite;

namespace Game.Codebase.Morpeh.Features.Triggers.Providers
{
    public class TriggerProvider : EntityProvider
    {
        public TriggerType Type;
        public SpriteRenderer Icon;
        public Collider Collider;
        public TextAsset TextAsset;

        private ICollisionRegistry _collisions;

        [Inject]
        private void Construct(ICollisionRegistry collisions)
        {
            _collisions = collisions;
        }

        protected override void Initialize()
        {
            var triggers = World.Default.GetStash<Trigger>();
            var sprites = World.Default.GetStash<Sprite>();

            triggers.Set(Entity, new Trigger { Value = Type });
            sprites.Set(Entity, new Sprite { Value = Icon });

            _collisions.Register(Collider.GetInstanceID(), Entity);
        }

        protected override void Deinitialize()
        {
            _collisions.Unregister(Collider.GetInstanceID());
            World.Default.RemoveEntity(Entity);
        }
    }
}