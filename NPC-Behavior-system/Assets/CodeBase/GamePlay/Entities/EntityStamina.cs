using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GamePlay.Entities
{
    public class EntityStamina : MonoBehaviour
    {
        public EntityBehaviour Entity;
        public Slider StaminaBar;

        private void Update()
        {
            if (Entity != null && Entity.State != null) 
                StaminaBar.value = Entity.State.CurrentStamina / Entity.State.MaxStamina;
        }
    }
}