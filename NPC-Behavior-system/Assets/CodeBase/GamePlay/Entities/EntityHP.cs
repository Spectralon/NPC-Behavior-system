using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GamePlay.Entities
{
    public class EntityHP : MonoBehaviour
    {
        public EntityBehaviour Entity;
        public Slider HPBar;

        private void Update()
        {
            if (Entity != null && Entity.State != null) 
                HPBar.value = Entity.State.CurrentHp / Entity.State.MaxHp;
        }
    }
}