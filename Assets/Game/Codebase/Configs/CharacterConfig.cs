using UnityEngine;

namespace Game.Codebase.Configs
{
    [CreateAssetMenu(fileName = "New Character Config", menuName = "Configs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        public float Speed;
    }
}