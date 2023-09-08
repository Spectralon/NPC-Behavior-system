using CodeBase.StaticData.Abilities;

namespace CodeBase.GamePlay.AI.Utility
{
    public class CombatAbility
    {
        public string CasterId;
        public AbilityTypeId TypeId;
        public AbilityType Type;
        public TargetType TargetType;
        public bool IsSingleTarget => TargetType is TargetType.Ally or TargetType.Enemy or TargetType.Self;
        public float MaxCooldown;
    }
}