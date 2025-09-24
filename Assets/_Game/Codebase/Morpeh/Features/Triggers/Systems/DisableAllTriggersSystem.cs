using Scellecs.Morpeh;

namespace Game.Codebase.Morpeh.Features.Triggers.Systems
{
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