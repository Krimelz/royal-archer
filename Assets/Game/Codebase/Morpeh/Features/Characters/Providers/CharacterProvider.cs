using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Common.Components;
using Game.Codebase.Morpeh.Features.Movement.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Transform = Game.Codebase.Morpeh.Features.Common.Components.Transform;

namespace Game.Codebase.Morpeh.Features.Characters.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CharacterProvider : MonoProvider<Character>
    {
        [SerializeField] private float Speed;

        protected override void Initialize()
        {
            var speeds = Entity.GetWorld().GetStash<Speed>();
            var moveables = Entity.GetWorld().GetStash<Moveable>();
            var positions = Entity.GetWorld().GetStash<Position>();
            var transforms = Entity.GetWorld().GetStash<Transform>();
            
            speeds.Set(Entity, new Speed { Value = Speed });
            moveables.Set(Entity);
            positions.Set(Entity, new Position { Value = transform.position });
            transforms.Set(Entity, new Transform { Value = transform });
        }

        protected override void Deinitialize()
        {
            var speeds = Entity.GetWorld().GetStash<Speed>();
            var moveables = Entity.GetWorld().GetStash<Moveable>();
            var positions = Entity.GetWorld().GetStash<Position>();
            var transforms = Entity.GetWorld().GetStash<Transform>();
            
            speeds.Remove(Entity);
            moveables.Remove(Entity);
            positions.Remove(Entity);
            transforms.Remove(Entity);
        }
    }
}