using UnityEngine;

namespace CodeBase.GamePlay.UI.Text
{
    public interface ICombatTextEntity
    {
        void PlayText(string text, Color color, Vector3 from);
        void SetRoot(Transform root);
    }
}