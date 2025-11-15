using System;
using Game.Codebase.Configs;
using Scellecs.Morpeh;

namespace Game.Codebase.Morpeh.Features.Characters.Components
{
    [Serializable]
    public struct Character : IComponent
    {
        public CharacterConfig Config;
    }
}