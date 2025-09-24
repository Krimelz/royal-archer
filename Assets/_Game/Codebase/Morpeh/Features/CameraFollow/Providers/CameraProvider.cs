using Game.Codebase.Morpeh.Features.CameraFollow.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using Transform = Game.Codebase.Morpeh.Features.Common.Components.Transform;

namespace Game.Codebase.Morpeh.Features.CameraFollow.Providers
{
    public class CameraProvider : EntityProvider
    {
        public Vector3 Offset;
        public Camera Camera;

        protected override void Initialize()
        {
            var cameras = World.Default.GetStash<MainCamera>();
            var transforms = World.Default.GetStash<Transform>();
            var offsets = World.Default.GetStash<Offset>();

            cameras.Set(Entity, new MainCamera { Value = Camera });
            transforms.Set(Entity, new Transform { Value = transform });
            offsets.Set(Entity, new Offset { Value = Offset });
        }

        protected override void Deinitialize()
        {
            World.Default.RemoveEntity(Entity);
        }
    }
}