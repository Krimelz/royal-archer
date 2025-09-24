using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Common.Components;
using Game.Codebase.Morpeh.Features.Movement.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Sprite = Game.Codebase.Morpeh.Features.Common.Components.Sprite;
using Transform = Game.Codebase.Morpeh.Features.Common.Components.Transform;

namespace Game.Codebase.Morpeh.Features.Characters.Providers
{
    public class CharacterProvider : EntityProvider
    {
        public float Speed = 1f;

        protected override void Initialize()
        {
            var characters = World.Default.GetStash<Character>();
            var moveables = World.Default.GetStash<Moveable>();
            var positions = World.Default.GetStash<Position>();
            var transforms = World.Default.GetStash<Transform>();
            var speeds = World.Default.GetStash<Speed>();
            var sprites = World.Default.GetStash<Sprite>();

            characters.Set(Entity, new Character());
            moveables.Set(Entity, new Moveable());
            positions.Set(Entity, new Position { Value = transform.position });
            transforms.Set(Entity, new Transform { Value = transform });
            speeds.Set(Entity, new Speed { Value = Speed });
        }

        protected override void Deinitialize()
        {
            World.Default.RemoveEntity(Entity);
        }
    }
}