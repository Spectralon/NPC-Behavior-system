using UnityEngine;
using Zenject;

namespace CodeBase.GamePlay.UI.Text
{
    public class CombatTextEntity : ICombatTextEntity, IInitializable
    {
        private const string CombatTextPath = "UI/combatText/CombatText";

        public Transform TextRoot { get; set; }
    
        public int RandomX = 50;
        public int RandomY = 50;
        
        private CombatText _combatTextPrefab;

        public void Initialize() => 
            _combatTextPrefab = Resources.Load<CombatText>(CombatTextPath);

        public void SetRoot(Transform root) => 
            TextRoot = root;

        public void PlayText(string text, Color color, Vector3 from)
        {
            Vector3 position = Camera.main.WorldToScreenPoint(from);
      
            position += new Vector3(Random.Range(-RandomX, RandomX), Random.Range(-RandomY, RandomY));

            CombatText combatText = Object.Instantiate(_combatTextPrefab, position, Quaternion.identity, TextRoot);
            combatText.Initialize(text, color);
        }
    }
}