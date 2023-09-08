using System.Collections.Generic;
using CodeBase.StaticData.Abilities;

namespace CodeBase.GamePlay.Abilities.Targeting
{
    public interface ITargetPicker
    {
        IEnumerable<string> AvailableTargetsFor(string casterId, TargetType targetType);
    }
}