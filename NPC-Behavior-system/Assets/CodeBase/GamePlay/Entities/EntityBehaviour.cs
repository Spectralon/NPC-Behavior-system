using CodeBase.StaticData.Entities;
using UnityEngine;

namespace CodeBase.GamePlay.Entities
{
    public class EntityBehaviour : MonoBehaviour, IEntity
    {
        public EntityAnimator Animator;
        public Transform Sprite;
        public GameObject NextTurnPointer;
        public EntityState State => _state;
        private EntityState _state;
        
        public EntityTypeId TypeId { get; set; }
        public string Id { get; set; }
        public int PlaceNumber { get; set; }
        
        public bool IsDead => State.CurrentHp <= 0;
        public bool IsReady => State.CurrentStamina >= State.MaxStamina;
        
        public void InitWithState(EntityState state, bool turn, int placeNumber)
        {
            _state = state;
            PlaceNumber = placeNumber;

            if(turn)
                Rotate(Sprite);
        }

        public void SwitchNextTurnPointer(bool on) => 
            NextTurnPointer.SetActive(on);

        private void Rotate(Transform spriteTransform)
        {
            Vector3 scale = spriteTransform.localScale;
            scale.x = -scale.x;
            spriteTransform.localScale = scale;
        }
    }
}