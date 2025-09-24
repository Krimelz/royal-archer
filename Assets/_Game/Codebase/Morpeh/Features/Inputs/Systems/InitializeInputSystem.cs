using Scellecs.Morpeh;

namespace Game.Codebase.Morpeh.Features.Inputs.Systems
{
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