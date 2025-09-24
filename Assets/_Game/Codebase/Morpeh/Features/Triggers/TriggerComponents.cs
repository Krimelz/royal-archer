using Scellecs.Morpeh;
using System;

namespace Game.Codebase.Morpeh.Features.Triggers
{
    [Serializable] public struct Trigger : IComponent { public TriggerType Value; }
    [Serializable] public struct ActiveTrigger : IComponent { }
}