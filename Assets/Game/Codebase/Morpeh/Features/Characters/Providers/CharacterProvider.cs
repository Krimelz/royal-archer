using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Common.Components;
using Game.Codebase.Morpeh.Features.Movement.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using Transform = Game.Codebase.Morpeh.Features.Common.Components.Transform;
using Rigidbody = Game.Codebase.Morpeh.Features.Common.Components.Rigidbody;

namespace Game.Codebase.Morpeh.Features.Characters.Providers
{
    public class CharacterProvider : MonoProvider<Character>
    {
        [SerializeField] private UnityEngine.Rigidbody Rigidbody;

        protected override void Initialize()
        {
            var world = Entity.GetWorld();

            world.GetStash<Speed>().Set(Entity);
            world.GetStash<Moveable>().Set(Entity);
            //world.GetStash<Position>().Set(Entity, new Position { Value = transform.position });
            world.GetStash<Transform>().Set(Entity, new Transform { Value = transform });
            world.GetStash<Rigidbody>().Set(Entity, new Rigidbody { Value = Rigidbody });
        }

        protected override void Deinitialize()
        {
            var world = Entity.GetWorld();

            world.GetStash<Speed>().Remove(Entity);
            world.GetStash<Moveable>().Remove(Entity);
            //world.GetStash<Position>().Remove(Entity);
            world.GetStash<Transform>().Remove(Entity);
            world.GetStash<Rigidbody>().Remove(Entity);
        }
    }
}