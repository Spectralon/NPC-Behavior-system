using CodeBase.Extensions;
using UnityEngine;

namespace CodeBase.GamePlay.Entities
{
    public class EntityAnimator : MonoBehaviour
    {
        private readonly int _idleStateHash = Animator.StringToHash("Base Layer.Idle");
        private readonly int _1AbilityStateHash = Animator.StringToHash("Base Layer.Ability1");
        private readonly int _2AbilityStateHash = Animator.StringToHash("Base Layer.Ability2");
        private readonly int _3AbilityStateHash = Animator.StringToHash("Base Layer.Ability3");
        private readonly int _deathStateHash = Animator.StringToHash("Base Layer.Death");

        private readonly int _playDeathHash = Animator.StringToHash("die");
        private readonly int _playSkill1Hash = Animator.StringToHash("skill1");
        private readonly int _playSkill2Hash = Animator.StringToHash("skill2");
        private readonly int _playSkill3Hash = Animator.StringToHash("skill3");

        public Animator Animator;
        private int[] _abilities;

        private void Awake()
        {
            if (Animator == null)
                Animator = GetComponent<Animator>();

            _abilities = new[] { _playSkill1Hash, _playSkill2Hash, _playSkill3Hash };
        }

        public void PlaySkill(int index)
        {
            ResetAllTriggers();
            Animator.SetTrigger(_abilities.ElementAtOrFirst(index - 1));
        }

        public void PlayDeath()
        {
            ResetAllTriggers();
            Animator.SetTrigger(_playDeathHash);
        }

        private void ResetAllTriggers()
        {
            if (Animator.runtimeAnimatorController == null)
                return;

            Animator.ResetTrigger(_playDeathHash);

            if (_abilities != null)
            {
                foreach (int trigger in _abilities)
                    Animator.ResetTrigger(trigger);
            }
        }
    }
}