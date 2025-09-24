using Game.Codebase.Morpeh.Features.Inputs.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Game.Codebase.Morpeh.Features.Inputs.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class InitializeInputSystem : IInitializer
    {
        private Stash<Input> _inputStash;

        private Entity _inputEntity;

        public World World { get; set; }

        public void OnAwake()
        {
            _inputStash = World.GetStash<Input>();
            _inputEntity = World.CreateEntity();
            _inputStash.Set(_inputEntity, new Input());
        }

        public void Dispose()
        {
            World.RemoveEntity(_inputEntity);
        }
    }
}