using Game.Codebase.Morpeh.Features.Characters.Components;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;

namespace Game.Codebase.Morpeh.Features.Characters.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CharacterProvider : MonoProvider<Character>
    {

    }
}