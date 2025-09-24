using Game.Codebase.Morpeh.Features.Triggers.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Game.Codebase.Morpeh.Features.Triggers.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class DisableAllTriggersSystem : IFixedSystem
    {
        private Stash<ActiveTrigger> _triggers;

        public World World { get; set; }

        public void OnAwake()
        {
            _triggers = World
                .GetStash<ActiveTrigger>();
        }

        public void OnUpdate(float deltaTime)
        {
            _triggers.RemoveAll();
        }

        public void Dispose()
        {
        }
    }
}