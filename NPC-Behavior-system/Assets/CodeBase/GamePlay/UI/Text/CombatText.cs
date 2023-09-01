using TMPro;
using UnityEngine;

namespace CodeBase.GamePlay.UI.Text
{
    public class CombatText : MonoBehaviour
    {
        public TextMeshProUGUI Text;

        public void Initialize(string text, Color color)
        {
            Text.text = text;
            Text.color = color;
        }
    }
}